using System;

namespace BankApp
{
    /// <summary>
    /// Represents a single bank account with basic functionality.
    /// </summary>
    public class BankAccount
    {
        // Read-only properties for the account number and the interest rate.
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        public decimal InterestRate { get; private set; }

        /// <summary>
        /// Initializes a new instance of the BankAccount class.
        /// </summary>
        /// <param name="accountNumber">The unique number of the account.</param>
        /// <param name="initialBalance">The initial balance of the account.</param>
        /// <param name="interestRate">The interest rate for the account.</param>
        public BankAccount(string accountNumber, decimal initialBalance, decimal interestRate)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            InterestRate = interestRate;
        }

        /// <summary>
        /// Deposits the specified amount into the account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(decimal amount)
        {
            // Ensure the deposit amount is positive
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Your account {AccountNumber} has been credited with {amount} UAH. Current balance: {Balance} UAH.");
            }
            else
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
            }
        }

        /// <summary>
        /// Withdraws the specified amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdraw(decimal amount)
        {
            // Ensure the withdrawal amount is positive and that there are sufficient funds
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"You have withdrawn {amount} UAH from account {AccountNumber}. Current balance: {Balance} UAH.");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        /// <summary>
        /// Applies the interest rate to the balance and updates the account.
        /// </summary>
        public void ApplyInterest()
        {
            if (InterestRate > 0)
            {
                decimal interest = Balance * InterestRate / 100;
                Balance += interest;
                Console.WriteLine($"Interest applied to account {AccountNumber}. Added {interest} UAH. Current balance: {Balance} UAH.");
            }
        }

        /// <summary>
        /// Displays account information, including balance and interest rate.
        /// </summary>
        public void ShowAccountInfo()
        {
            Console.WriteLine($"Account information for {AccountNumber}:");
            Console.WriteLine($"Balance: {Balance} UAH.");
            Console.WriteLine($"Interest rate: {InterestRate}%");
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a new bank account object with initial values
            BankAccount account = new BankAccount("98765", 5000.0m, 3.5m);

            // Show initial account information
            account.ShowAccountInfo();

            // Perform deposit and withdrawal operations
            account.Deposit(1500.0m);
            account.Withdraw(1000.0m);

            // Apply interest to the account balance
            account.ApplyInterest();

            // Show updated account information
            account.ShowAccountInfo();
        }
    }
}
