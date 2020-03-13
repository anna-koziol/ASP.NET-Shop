using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt
{
    public partial class Login : System.Web.UI.Page
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

                // bool check = Verify(TB2.Text, reader["password"].ToString());
                var check = Register.Verify(TB2.Text, reader["password"].ToString());
                if (check)
                {
                    if (reader["nick"].ToString() == "admin")
                    {
                        Session["admin"] = true;
                        return 0; //admin
                    }
                    else
                    {
                        Session["login"] = reader["id"].ToString();
                        Session["name"] = reader["nick"].ToString();
                        Session["img"] = reader["photo"].ToString();
                        return 2; //jest i sie zgadza
                    }
                    
                }
                else {
                    return 3; //nie zgAdza sie hasło
                }
            }
            if (ReaderEmpty) {
                return 4; // nie ma tkaiego loginu
            }
            return 1;
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = TB1.Text;
            string pass = TB2.Text;
            int ret = Reader("SELECT * FROM `login` WHERE `nick` = '"+login+"'");
            if (ret == -1) {
                LInfo.Text = "brak połączenia z bazą";
            }
            else if (ret == 2)
            {
                LInfo.Text = "zalogowano";
                Response.Redirect("Main.aspx");
            }
            else if (ret == 3)
            {
                LInfo.Text = "hasło sie nie zgadza";

            }
            else if (ret == 4)
            {
                LInfo.Text = "nie ma takiego użytkownika";

            }
            else if (ret == 0)
            {
                Response.Redirect("AdminPage.aspx");
            }
        }
    }
}