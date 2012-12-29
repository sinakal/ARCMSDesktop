using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ARCMSDesktop
{
    class Connect
    {
        public SqlConnection conn = new SqlConnection("Data Source=Owner-PC\\SQLEXPRESS;Initial Catalog=ARCMS;Integrated Security =SSPI");
    }
}
