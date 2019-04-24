using System;
using System.Data.SqlClient;

namespace AT
{
    class Universaler
    {
        public static SqlConnection conn;
        public static string password;
        //
        public static string sername;
        public static string dataname;
        public static string logname;
        public static string datapass;
      
        public static SqlConnection Communicate()
        {
            try
        {
            if (sername == null || dataname == null || logname == null || datapass == null)
                {
                    conn = new SqlConnection("Server=.;Initial Catalog=ATService;uid=sa;pwd=sa"); 
                }else
                {                
                    conn = new SqlConnection("Server="+Universaler.sername+";Initial Catalog="+Universaler.dataname+";uid="+Universaler.logname+";pwd="+Universaler.datapass); 
                }
        }catch(Exception ex)
        {
            ex.Message.ToString();
        }
            return conn;
        }
       
    }
    
}
