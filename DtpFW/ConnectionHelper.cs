using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DtpFW
{
    public class ConnectionHelper
    {
        private static string _Connection;

        public static string  Connection
        {
            get
            {
                return _Connection;
            }
            set
            {
                _Connection = value;
            }
        }
    }
}
