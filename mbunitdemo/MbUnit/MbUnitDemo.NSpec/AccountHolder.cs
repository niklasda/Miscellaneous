using System.Collections.Generic;
using System.Text;

namespace MbUnitDemo.NSpec
{
    public class AccountHolder
    {
        public string Name
        {
            get { return _name; }
        }

        public Account[] AccountsHeld
        {
            get { return _accounts.ToArray(); }
        }

        private readonly string _name;
        private readonly List<Account> _accounts;

        public AccountHolder(string name)
        {
            _name = name;
            _accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Holder:'{0}' Accounts:[", Name);

            int num = 1;
            foreach (var account in _accounts)
            {
                if (num < _accounts.Count)
                    sb.AppendFormat("{0}:{1}, ", num, account.Balance);
                else
                    sb.AppendFormat("{0}:{1}", num, account.Balance);
                num++;
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}