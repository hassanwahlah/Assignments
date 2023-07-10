using System;
using System.Collections.Generic;

public class BankAccount
{
    public string Account_number { get; set; }
    public string Account_holder_name { get; set; }
    public int Balance { get; set; }

    public BankAccount(string account_number, string account_holder_name, int balance)
    {
        Account_number = account_number;
        Account_holder_name = account_holder_name;
        Balance = balance;
    }

    public virtual void Deposit(int deposit_amt)
    {
        Balance = Balance + deposit_amt;
    }

    public virtual void Withdraw(int withdraw_amt)
    {
        Balance = Balance - withdraw_amt;
    }

    public void DisplayAccountInfo()
    {
        Console.WriteLine("Account Number: " + Account_number + "\nName: " + Account_holder_name + "\nBalance: " + Balance);
    }
}

public class SavingsAccount : BankAccount 
{
     public int interestRate { get; set; }

    public SavingsAccount(string Account_number, string Account_holder_name, int Balance, int InterestRate) : base(Account_number, Account_holder_name, Balance)
    {
        interestRate = InterestRate;
    }    
}

class CheckingAccount : BankAccount
{
    public CheckingAccount(string Account_number, string Account_holder_name, int Balance)
        : base(Account_number, Account_holder_name, Balance)
    {
    }

    public override void Withdraw(int amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Sorry! Low balance");
        }
        else
        {
            base.Withdraw(amount);
        }
    }
}

public class Bank
{
    private List<BankAccount> BankAccounts { get; set; }

    public Bank()
    {
        BankAccounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount bankaccount)
    {
        BankAccounts.Add(bankaccount);
        Console.WriteLine("Account sucessfully created.");
    }

    // public void DepositToAccount(t)
    // {
    //     
    // } 
}


    
class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        SavingsAccount saving1 = new SavingsAccount("3456", "Hassan", 5000, 5000);
        CheckingAccount checking1 = new CheckingAccount("3456", "Hassan", 5000);

        
        BankAccount abc = new BankAccount("3456", "Hassan", 5000);
       bank.AddAccount(abc);
    //   bank.DepositToAccount("34567" ,5000);
    //  bank.AddAccount(savingsaccount);
    //  bank.AddAccount(checkingaccount);
    //  bank.DepositToAccount();
    //  bank.WithdrawFromAccount();
    }
}
