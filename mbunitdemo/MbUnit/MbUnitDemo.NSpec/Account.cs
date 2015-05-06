using System;

namespace MbUnitDemo.NSpec
{
    public class Account
    {
        private int _accountBalance;

        public Account(int accountBalance)
        {
            _accountBalance = accountBalance;
        }

        public int Balance
        {
            get { return _accountBalance; }
            set { _accountBalance = value; }
        }

        public void TransferTo(Account account, int amount)
        {
            if (_accountBalance > 0)
            {
                account.Balance = account.Balance + amount;
                Balance = Balance - amount;
            }
        }

        public void Withdraw(int amount)
        {
            if (amount > Balance)
                throw new ArgumentException("Amount exceeds balance", "amount");

            Balance -= amount;
        }

        public void Deposit(int amount)
        {
            // not implemented yet, do nothing for now
        }

        public override string ToString()
        {
            return string.Format("[Balance: {0}]", Balance);
        }
    }




}
