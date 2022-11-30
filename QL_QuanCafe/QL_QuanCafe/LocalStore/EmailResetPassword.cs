using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.LocalStore
{
    class EmailResetPassword
    {
        string email;
        private static EmailResetPassword instance;
        public static EmailResetPassword Instance
        {
            get
            {
                if ( instance == null )
                    instance = new EmailResetPassword();
                return EmailResetPassword.instance;
            }
            set
            {
                EmailResetPassword.Instance = value;
            }
        }
        public EmailResetPassword()
        {
            this.email = "";
        }
        public void SetEmail( string email )
        {
            this.email = email;
        }
        public string GetEmail()
        {
            return email;
        }
    }
}
