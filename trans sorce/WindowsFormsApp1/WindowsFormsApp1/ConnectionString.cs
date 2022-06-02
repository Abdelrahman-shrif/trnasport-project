using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    class ConnectionString
    {
        public static string Getconnectionstring()
        {
            string connection = string.Empty;
            string domain = (AppDomain.CurrentDomain.BaseDirectory).ToString();

            string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= " + domain + "TransportDb.mdf;" + "Integrated Security=True;Connect Timeout=15;";
            connection = connect;
          
            return connection;

        }
    }
}
