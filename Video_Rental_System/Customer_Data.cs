using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Rental_System
{
    class Customer_Data
    {
        // Fields
        private SqlConnection Sqlconn = new SqlConnection(@"Data Source=DHILLON\SQLEXPRESS;Initial Catalog=DbLogin;Integrated Security=True");
        private SqlCommand Sqlcmd = new SqlCommand();
        private SqlDataReader SqlReader;
        private string Sqlstr;

        // Methods
        public void Add_Customer(string FirstName_TextBox, string LastName_TextBox, string Address_TextBox, string Phone_TextBox)
        {
            this.Sqlcmd.Parameters.Clear();
            try
            {
                this.Sqlcmd.Parameters.Clear();
                this.Sqlcmd.Connection = this.Sqlconn;
                this.Sqlstr = "Insert into Customer(FirstName,LastName,Address,Phone) Values(@FirstName, @LastName, @Address, @Phone)";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@FirstName", FirstName_TextBox), new SqlParameter("@LastName", LastName_TextBox), new SqlParameter("@Address", Address_TextBox), new SqlParameter("@Phone", Phone_TextBox) };
                this.Sqlcmd.Parameters.Add(parameterArray[0]);
                this.Sqlcmd.Parameters.Add(parameterArray[1]);
                this.Sqlcmd.Parameters.Add(parameterArray[2]);
                this.Sqlcmd.Parameters.Add(parameterArray[3]);
                this.Sqlcmd.CommandText = this.Sqlstr;
                this.Sqlconn.Open();
                this.Sqlcmd.ExecuteNonQuery();
                this.Sqlconn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                this.Sqlconn.Close();
            }
        }

        public void Delete_Customer(int CustomerID)
        {
            try
            {
                Sqlcmd.Parameters.Clear();
                this.Sqlcmd.Connection = this.Sqlconn;
                this.Sqlstr = "Delete from Customer where CustID like @CustomerID";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustomerID", CustomerID) };
                this.Sqlcmd.Parameters.Add(parameterArray[0]);
                this.Sqlcmd.CommandText = this.Sqlstr;
                this.Sqlconn.Open();
                this.Sqlcmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Sqlconn != null)
                {
                    this.Sqlconn.Close();
                }
            }
        }

        public DataTable LoadCustomerData()
        {
            DataTable table = new DataTable();
            try
            {
                this.Sqlcmd.Connection = this.Sqlconn;
                this.Sqlstr = "Select * from Customer";
                this.Sqlcmd.CommandText = this.Sqlstr;
                this.Sqlconn.Open();
                this.SqlReader = this.Sqlcmd.ExecuteReader();
                if (this.SqlReader.HasRows)
                {
                    table.Load(this.SqlReader);
                }
                this.Sqlconn.Close();
                return table;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                this.Sqlconn.Close();
                return null;
            }
        }

        public void Update_Customer(int CustomerID, string FirstName, string LastName, string Address, int Phone)
        {
            try
            {
                this.Sqlcmd.Parameters.Clear();
                this.Sqlcmd.Connection = this.Sqlconn;
                this.Sqlstr = "Update Customer Set FirstName = @FirstName, LastName = @Lastname, Address = @Address, Phone = @Phone where CustID = @CustomerID";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustomerID", CustomerID), new SqlParameter("@FirstName", FirstName), new SqlParameter("@LastName", LastName), new SqlParameter("@Address", Address), new SqlParameter("@Phone", Phone) };
                this.Sqlcmd.Parameters.Add(parameterArray[0]);
                this.Sqlcmd.Parameters.Add(parameterArray[1]);
                this.Sqlcmd.Parameters.Add(parameterArray[2]);
                this.Sqlcmd.Parameters.Add(parameterArray[3]);
                this.Sqlcmd.Parameters.Add(parameterArray[4]);
                this.Sqlcmd.CommandText = this.Sqlstr;
                this.Sqlconn.Open();
                this.Sqlcmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Sqlconn != null)
                {
                    this.Sqlconn.Close();
                }
            }
        }

    }
}
