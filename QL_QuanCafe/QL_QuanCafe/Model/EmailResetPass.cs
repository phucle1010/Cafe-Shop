using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.Model
{
    class EmailResetPass
    {
        string email;
        private static EmailResetPass instance;
        public static EmailResetPass Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmailResetPass();
                return EmailResetPass.instance;
            }
            set
            {
                EmailResetPass.Instance = value;
            }
        }
        public EmailResetPass()
        {
            this.email = "";
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public string GetEmail()
        {
            return email;
        }
    }
}
