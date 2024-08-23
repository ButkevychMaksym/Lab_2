using System;
using System.Collections.Generic;

namespace BankApp
{
    /// <summary>
    /// Represents a simple banking system that manages multiple accounts.
    /// </summary>
    public class Bank
    {
        // Dictionary to store accounts, where the key is the account number and the value is the balance.
        private Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();

        /// <summary>
        /// Creates a new bank account with the specified account number and initial balance.
        /// </summary>
        /// <param name="accountNumber">The unique number of the account to be created.</param>
        /// <param name="initialBalance">The initial balance for the account.</param>
        public void CreateAccount(string accountNumber, decimal initialBalance)
        {
            // Check if the account already exists
            if (accounts.ContainsKey(accountNumber))
            {
                throw new Exception("Account already exists.");
            }
            // Add the new account to the dictionary
            accounts[accountNumber] = initialBalance;
        }

        /// <summary>
        /// Deposits the specified amount into the specified account.
        /// </summary>
        /// <param name="accountNumber">The account number where the deposit will be made.</param>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(string accountNumber, decimal amount)
        {
            // Check if the account exists
            if (!accounts.ContainsKey(accountNumber))
            {
                throw new Exception("Account not found.");
            }
            // Add the amount to the account balance
            accounts[accountNumber] += amount;
        }

        /// <summary>
        /// Withdraws the specified amount from the specified account.
        /// </summary>
        /// <param name="accountNumber">The account number from which the money will be withdrawn.</param>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdraw(string accountNumber, decimal amount)
        {
            // Check if the account exists
            if (!accounts.ContainsKey(accountNumber))
            {
                throw new Exception("Account not found.");
            }
            // Check if there are sufficient funds
            if (accounts[accountNumber] < amount)
            {
                throw new Exception("Insufficient funds.");
            }
            // Subtract the amount from the account balance
            accounts[accountNumber] -= amount;
        }

        /// <summary>
        /// Retrieves information about all accounts in the bank.
        /// </summary>
        /// <returns>A string containing details of all accounts and their balances.</returns>
        public string GetAllAccounts()
        {
            // If no accounts exist, return a message
            if (accounts.Count == 0)
            {
                return "No accounts found.";
            }

            // Build a string with account details
            string result = "Accounts:\n";
            foreach (var account in accounts)
            {
                result += $"Account Number: {account.Key}, Balance: {account.Value}\n";
            }
            return result;
        }
    }
}
