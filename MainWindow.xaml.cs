using System;
using System.Windows;
using System.Windows.Controls;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for the MainWindow.xaml file.
    /// This class handles the UI interactions for the BankApp.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Instance of the Bank class to manage bank accounts.
        private Bank myBank = new Bank();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler to remove placeholder text from a TextBox when it gains focus.
        /// </summary>
        private void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Remove placeholder text if the TextBox contains default text.
            if (textBox.Text == "Номер рахунку" || textBox.Text == "Початковий баланс" ||
                textBox.Text == "Номер рахунку для операції" || textBox.Text == "Сума")
            {
                textBox.Text = "";
            }
        }

        /// <summary>
        /// Event handler to add placeholder text back to a TextBox when it loses focus,
        /// if the TextBox is empty.
        /// </summary>
        private void AddText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Check if the TextBox is empty and restore the appropriate placeholder text.
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "AccountNumberTextBox") textBox.Text = "Номер рахунку";
                if (textBox.Name == "InitialBalanceTextBox") textBox.Text = "Початковий баланс";
                if (textBox.Name == "TransactionAccountNumberTextBox") textBox.Text = "Номер рахунку для операції";
                if (textBox.Name == "AmountTextBox") textBox.Text = "Сума";
            }
        }

        /// <summary>
        /// Event handler for the "Create Account" button click.
        /// Attempts to create a new account with the provided account number and initial balance.
        /// </summary>
        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = AccountNumberTextBox.Text;
            if (decimal.TryParse(InitialBalanceTextBox.Text, out decimal initialBalance))
            {
                try
                {
                    // Create a new account in the bank.
                    myBank.CreateAccount(accountNumber, initialBalance);
                    MessageBox.Show("Account created successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating account: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Invalid initial balance.");
            }
        }

        /// <summary>
        /// Event handler for the "Deposit" button click.
        /// Attempts to deposit the specified amount into the provided account.
        /// </summary>
        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = TransactionAccountNumberTextBox.Text;
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                try
                {
                    // Deposit the amount into the specified account.
                    myBank.Deposit(accountNumber, amount);
                    MessageBox.Show("Deposit successful.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error depositing money: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Invalid amount.");
            }
        }

        /// <summary>
        /// Event handler for the "Withdraw" button click.
        /// Attempts to withdraw the specified amount from the provided account.
        /// </summary>
        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            string accountNumber = TransactionAccountNumberTextBox.Text;
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                try
                {
                    // Withdraw the amount from the specified account.
                    myBank.Withdraw(accountNumber, amount);
                    MessageBox.Show("Withdrawal successful.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error withdrawing money: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Invalid amount.");
            }
        }

        /// <summary>
        /// Event handler for the "Show All Accounts" button click.
        /// Displays information about all accounts in the bank.
        /// </summary>
        private void ShowAllAccountsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve and display all accounts information.
                string accounts = myBank.GetAllAccounts();
                MessageBox.Show(accounts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving accounts: {ex.Message}");
            }
        }
    }
}
