using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Rental_System
{
    class User_Login
    {
        private SqlConnection Sqlconn = new SqlConnection(@"Data Source = DHILLON\\SQLEXPRESS01; Initial Catalog = LoginDB; Integrated Security = True");
        private SqlCommand Sqlcmd = new SqlCommand();
        private SqlDataReader SqlReader;
        private string Sqlstr;

        // Methods
        public bool User_Log_method(int userid, string password)
        {
            bool hasRows;
            try
            {
                this.Sqlcmd.Connection = this.Sqlconn;
                Sqlstr = "Select userid, password from register where username =  @UserName  and password =  @Password ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@UserName", userid), new SqlParameter("@Password", password) };
                this.Sqlcmd.Parameters.Add(parameterArray[0]);
                this.Sqlcmd.Parameters.Add(parameterArray[1]);
                this.Sqlcmd.CommandText = this.Sqlstr;
                this.Sqlconn.Open();
                this.SqlReader = this.Sqlcmd.ExecuteReader();
                hasRows = this.SqlReader.HasRows;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                hasRows = false;
            }
            finally
            {
                if (this.SqlReader != null)
                {
                    this.SqlReader.Close();
                }
                if (this.Sqlconn != null)
                {
                    this.Sqlconn.Close();
                }
            }
            return hasRows;
        }

        internal bool User_Log_method(int userid, object text)
        {
            throw new NotImplementedException();
        }
    }
}
