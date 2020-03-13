using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Projekt
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private MySqlConnection connect()
        {

            string myconnection =
              "Server=localhost;" +
              //"Port=8080;" +
              "Database=renee;" +
              "User=root;" +
              "Password=;" +
              "SslMode=none; ";

            MySqlConnection connection = new MySqlConnection(myconnection);

            try
            {

                connection.Open();
                return connection;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //"Error";
            }
            return null;
        }

        public int Reader(string where)
        {
            bool ReaderEmpty = true;
            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = where;
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReaderEmpty = false;
            }
            if (ReaderEmpty)
            {
                return -21; // nie ma tkaiego loginu
            }
            return 1;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if(Session["admin"] != null)  { Response.Redirect("AdminAdd.aspx");  }
            else   { LInfo.Text = "Sesja wygasła, zaloguj się";}
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null) { Response.Redirect("AdminEdit.aspx"); }
            else { LInfo.Text = "Sesja wygasła, zaloguj się"; }
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)  {  Response.Redirect("AdminRemove.aspx"); }
            else { LInfo.Text = "Sesja wygasła, zaloguj się";  }
        }

        protected void btOrders_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null) { Response.Redirect("AdminOrders.aspx"); }
            else { LInfo.Text = "Sesja wygasła, zaloguj się"; }
        }
    }

}