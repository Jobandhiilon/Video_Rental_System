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
    class Video
    {
        private SqlConnection Conn = new SqlConnection(@"Data Source=DHILLON\SQLEXPRESS;Initial Catalog=DbLogin;Integrated Security=True");
        private SqlCommand Cmd = new SqlCommand();
        private SqlDataReader SqlReader;
        private string Str;

        // for adding the video
        public void Add_video(string Rating_TextBox, string Title_TextBox, string Year_TextBox, string Rental_Cost_TextBox, string Copies_TextBox, string Plot_TextBox, string Genre_TextBox)
        {
            this.Cmd.Parameters.Clear();
            try
            {
                this.Cmd.Parameters.Clear();
                this.Cmd.Connection = this.Conn;
                this.Str = "Insert into Movies(Rating,Title,Year,Rental_Cost,Copies,Plot,Genre) Values(@Rating, @Title, @Year, @Rental_Cost, @Copies, @Plot, @Genre)";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@Rating", Rating_TextBox), new SqlParameter("@Title", Title_TextBox), new SqlParameter("@Year", Year_TextBox), new SqlParameter("@Rental_Cost", Rental_Cost_TextBox), new SqlParameter("@Copies", Copies_TextBox), new SqlParameter("@Plot", Plot_TextBox), new SqlParameter("@Genre", Genre_TextBox) };
                this.Cmd.Parameters.Add(parameterArray[0]);
                this.Cmd.Parameters.Add(parameterArray[1]);
                this.Cmd.Parameters.Add(parameterArray[2]);
                this.Cmd.Parameters.Add(parameterArray[3]);
                this.Cmd.Parameters.Add(parameterArray[4]);
                this.Cmd.Parameters.Add(parameterArray[5]);
                this.Cmd.Parameters.Add(parameterArray[6]);
                this.Cmd.CommandText = this.Str;
                this.Conn.Open();
                this.Cmd.ExecuteNonQuery();
                this.Conn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                this.Conn.Close();
            }
        }

        // below code is for deleting the video
        public void Delete_video(int MovieID)
        {
            try
            {
                Cmd.Parameters.Clear();
                this.Cmd.Connection = this.Conn;
                this.Str = "Delete from Movies where MovieID like @MovieID";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID) };
                this.Cmd.Parameters.Add(parameterArray[0]);
                this.Cmd.CommandText = this.Str;
                this.Conn.Open();
                this.Cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            { 
                if (this.Conn != null)
                {
                    this.Conn.Close();
                }
            }
        }
        //below code is for update video data in tables
        public DataTable LoadvideoData()
        {
            DataTable table = new DataTable();
            try
            {
                this.Cmd.Connection = this.Conn;
                this.Str = "Select * from Movies";
                this.Cmd.CommandText = this.Str;
                this.Conn.Open();
                this.SqlReader = this.Cmd.ExecuteReader();
                if (this.SqlReader.HasRows)
                {
                    table.Load(this.SqlReader);
                }
                this.Conn.Close();
                return table;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                this.Conn.Close();
                return null;
            }
        }
        // below code is for upate rented movies in tables
        public DataTable LoadRentedData()
        {
            DataTable table = new DataTable();
            try
            {
                this.Cmd.Connection = this.Conn;
                this.Str = "Select RMID,MovieIDFK,CustIDFK,DateRented,DateReturned from RentedMovies";
                this.Cmd.CommandText = this.Str;
                this.Conn.Open();
                this.SqlReader = this.Cmd.ExecuteReader();
                if (this.SqlReader.HasRows)
                {
                    table.Load(this.SqlReader);
                }
                this.Conn.Close();
                return table;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                this.Conn.Close();
                return null;
            }
        }
        // below code is for checking the customer who rented most movies
        public DataTable LoadCustomerRankData()
        {
            DataTable table = new DataTable();
            try
            {
                this.Cmd.Connection = this.Conn;
                this.Str = "Select * from CustRatting ORDER BY Cnt DESC";
                this.Cmd.CommandText = this.Str;
                this.Conn.Open();
                this.SqlReader = this.Cmd.ExecuteReader();
                if (this.SqlReader.HasRows)
                {
                    table.Load(this.SqlReader);
                }
                this.Conn.Close();
                return table;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                this.Conn.Close();
                return null;
            }
        }
        // below code is for checking the most rented movie
        public DataTable LoadMovieRankData()
        {
            DataTable table = new DataTable();
            try
            {
                this.Cmd.Connection = this.Conn;
                this.Str = "Select * from MovieRatting ORDER BY Cnt DESC";
                this.Cmd.CommandText = this.Str;
                this.Conn.Open();
                this.SqlReader = this.Cmd.ExecuteReader();
                if (this.SqlReader.HasRows)
                {
                    table.Load(this.SqlReader);
                }
                this.Conn.Close();
                return table;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                this.Conn.Close();
                return null;
            }
        }



        //below code is for update the video
        public void Update_video(int MovieID, string Rating, string Title, string Year, int Rental_Cost, string Copies, string Plot, string Genre)
        {
            try
            {
                Cmd.Parameters.Clear();
                Cmd.Connection = Conn;
                Str = "Update Movies Set Rating = @Rating, Title = @Title, Year = @Year, Rental_Cost = @Rental_Cost, Copies = @Copies, Plot= @Plot, Genre = @Genre where MovieID = @MovieID";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID), new SqlParameter("@Rating", Rating), new SqlParameter("@Title", Title), new SqlParameter("@Year", Year), new SqlParameter("@Rental_Cost", Rental_Cost), new SqlParameter("@Copies", Copies), new SqlParameter("@Plot", Plot), new SqlParameter("@Genre", Genre) };
                Cmd.Parameters.Add(parameterArray[0]);
                Cmd.Parameters.Add(parameterArray[1]);
                Cmd.Parameters.Add(parameterArray[2]);
                Cmd.Parameters.Add(parameterArray[3]);
                Cmd.Parameters.Add(parameterArray[4]);
                Cmd.Parameters.Add(parameterArray[5]);
                Cmd.Parameters.Add(parameterArray[6]);
                Cmd.Parameters.Add(parameterArray[7]);
                Cmd.CommandText = Str;
                Conn.Open();
                Cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Conn != null)
                {
                    this.Conn.Close();
                }
            }
        }

    }
}
