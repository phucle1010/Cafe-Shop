using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.LocalStore
{
    class CurrentAccount
    {
        private static CurrentAccount _ins;
        public static CurrentAccount Ins
        {
            get
            {
                if ( _ins == null )
                    _ins = new CurrentAccount();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }
        private string username;
        private CurrentAccount() { 
            this.username = ""; 
        }
        public string getAccount()
        {
            return this.username;
        }
        public void setAccount(string user)
        {
            this.username = user;
        }
    }
}
