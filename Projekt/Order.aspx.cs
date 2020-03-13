using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt
{
    public partial class Order : System.Web.UI.Page
    {
        public static System.Web.UI.ScriptResourceMapping ScriptResourceMapping { get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["login"] != null && Session["Products"] != null && Session["priceRD"] != null)
            {
                PriceFull.Text = "RAZEM DO ZAPŁATY " + Session["priceRD"].ToString() + " ZŁ";
            }
            else
            {
                Err.Text = "BŁĄD!";
                Response.Redirect("Login.aspx");
            }
            

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

            }
            return null;
        }

        public int Insert(string toDo)
        {

            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = toDo;
            MySqlDataReader reader = command.ExecuteReader();

            return 1;

        }

        protected void BuyFull_Click(object sender, EventArgs e)
        {
            //DODANIE DO BAZY
            if (Session["login"] != null && Session["Products"] != null)
            {
                Insert("INSERT INTO `ordersdone`(`id_orderdone`, `id_User`, `products`, `price`, `state`) VALUES ('','" + Session["login"] + "','" + Session["Products"] + "','" + Session["priceRD"] + "','Zamówienie opłacone, zaczynamy proces komplementacji')");
                //usunięcie z orders
                Insert("DELETE FROM `orders` WHERE `nick` = " + Session["login"]);

                //Mail
                mail("x");

                Session["Products"] = null;
                Response.Redirect("Main.aspx");
            }
            else
            {
                Err.Text = "BŁĄD!";
            }

        }

        public int mail(string where)
        {
            bool ReaderEmpty = true;

            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT login.mail FROM `orders`, `login` WHERE login.id = "+ Session["login"];
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                ReaderEmpty = false;
            
                Session["mailAddres"] =  reader["mail"].ToString();


            }
            if (ReaderEmpty)
                return 2;
            else
            {
                try
                {
                    using (SmtpClient client = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = " ",
                            Password = ""
                        };
                        client.Credentials = credential;
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.EnableSsl = true;

                        var message = new MailMessage();
                        message.To.Add(new MailAddress(Session["mailAddres"].ToString()));

                        message.From = new MailAddress("");
                        message.Subject = "RENEE dziękujemy za zakupy";
                        message.IsBodyHtml = true;

                        message.Body = "<!DOCTYPE><html> <body> <div style='font-size: 20px'>  <b>" +
                         Session["name"] + ", </b> dziękujęmy za zrobienie zakupów w naszym sklepie" +
                        "</div></body></html>";
                        client.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    //BŁĄD
                }
                Response.Redirect("Main.aspx");

                return 1;
            }
        }

    }
}