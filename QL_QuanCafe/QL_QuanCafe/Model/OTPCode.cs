using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.Model
{
    class OTPCode
    {
        string OTP;
        private static OTPCode instance;
        public static OTPCode Instance
        {
            get
            {
                if (instance == null)
                    instance = new OTPCode();
                return OTPCode.instance;
            }
            set
            {
                OTPCode.Instance = value;
            }
        }
        public OTPCode() { }
        public void SetOTP(string otp)
        {
            this.OTP = otp;
        }
        public string GetOTP()
        {
            return this.OTP;
        }
    }
}
