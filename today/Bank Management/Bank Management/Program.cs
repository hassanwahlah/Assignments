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
        Console.WriteLine($"Hi {Account_holder_name}! Amount {deposit_amt} sucessfully deposited in your bank account '{Account_number}' New Balance is: " + Balance);
        Console.WriteLine();
    }

    public virtual void Withdraw(int withdraw_amt)
    {
        Balance = Balance - withdraw_amt;
        Console.WriteLine($"Hi {Account_holder_name}! Amount {withdraw_amt} sucessfully withdrawl from your bank account '{Account_number}' New Balance is: " + Balance);
        Console.WriteLine();
    }

    public void DisplayAccountInfo()
    {
        Console.WriteLine("Account Number: " + Account_number + "\nName: " + Account_holder_name + "\nBalance: " + Balance);
        Console.WriteLine();
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
    public List<BankAccount> BankAccounts { get; set; }

    public Bank()
    {
        BankAccounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount bankaccount)
    {
        BankAccounts.Add(bankaccount);
        Console.WriteLine($"Hi {bankaccount.Account_holder_name}! Your account {bankaccount.Account_number} sucessfully added.");
        Console.WriteLine();
    }

    public void DepositToAccount(string account_number, int amt)
    {
        foreach (var acc in BankAccounts)
        {
            if (acc.Account_number == account_number)
            {
                acc.Deposit(amt);
                break;
            }
        }
    }

    public void WithdrawlFromAccount(string account_number, int amt)
    {
        foreach (var acc in BankAccounts)
        {
            if (acc.Account_number == account_number)
            {
                acc.Withdraw(amt);
                break;
            }
        }
    }
}



class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        SavingsAccount Acc1 = new SavingsAccount("4470", "Hassan", 46000, 5000);
        CheckingAccount Acc2 = new CheckingAccount("9933", "Ahmad", 62000);

        bank.AddAccount(Acc1);
        bank.AddAccount(Acc2);

        Acc1.DisplayAccountInfo();
        Acc2.DisplayAccountInfo();

        

        bank.DepositToAccount("4470", 7000);
        bank.WithdrawlFromAccount("4470", 13000);
        



        Console.ReadLine();

       
       ////  bank.WithdrawFromAccount();
    }
}
