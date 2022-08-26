using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Khaqan
{
    public partial class khaqanForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\salman.ahmad\Documents\db.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                string query = "SELECT * FROM Users WHERE Username=@input01 AND Password=@input02;";

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@input01", username.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@input02", password.Text.Trim());

                SqlDataReader result = sqlCommand.ExecuteReader();

                if (result.Read())
                {
                    MessageBox.Show(result.GetValue(1).ToString());
                }

                //if (result == -1)
                //{
                //    MessageBox.Show("Invalid Credentials");
                //}

                //else
                //{
                //    MessageBox.Show(result.ToString());
                //}
            }
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            new DatabaseHandler().RegisterUser
                (
                    username.Text.Trim(),
                    password.Text.Trim(),
                    out int registrationStatus
                );

            if (registrationStatus == -1)
            {
                MessageBox.Show("Error! This username already exists...");
            }

            else if (registrationStatus == 0)
            {
                MessageBox.Show("User Registration Failed...");
            }

            else
            {
                MessageBox.Show("User Registered Sucessfully...");
            }
        }
    }
}