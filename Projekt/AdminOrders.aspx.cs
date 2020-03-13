using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Projekt
{
    public partial class AdminOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reader("1");
            /*string s = btn.Attributes["produkt"].ToString();
            string[] words = s.Split(' ');
            foreach (string word in words)
            {
                //LInfo.Text += word + " <br/>";
                //int id = Int32.Parse(word);
                var res = word.Trim(); // "hello world"
                if (res != "")
                {
                    //Reader2("SELECT * FROM `produkty` WHERE `id`=" + res + "");
                }
            }*/
        }

        public int reader(string where)
        {
            bool ReaderEmpty = true;

            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * FROM `ordersdone`, `login` WHERE login.id = ordersdone.id_User";
            MySqlDataReader reader = command.ExecuteReader();

            string nazwa = "False";

            while (reader.Read())
            {
                ReaderEmpty = false;
                var container = new HtmlGenericControl("div");
                container.Attributes["class"] = "productContainer";

                //var button = new Button();
                //button.CssClass
                //button.Click += new EventHandler(Edit);

                var name = new HtmlGenericControl("p") { InnerText = "Zamawiający: "+reader["nick"].ToString() };
                name.Attributes["class"] = "nameP";

                var rodzaj = new HtmlGenericControl("p") { InnerText = "Email: " + reader["mail"].ToString() };
                rodzaj.Attributes["class"] = "rodzajP";

                var cena = new HtmlGenericControl("p") { InnerText = "Do zapłaty: " + reader["price"].ToString() + " zł" };
                cena.Attributes["class"] = "cenaP";

                var prod = new HtmlGenericControl("p") { InnerText = "Zamówione produkty: " + reader["products"].ToString() + "" };
                prod.Attributes["class"] = "cenaP";

                var button = new Button();
                button.Text = "Edytuj";
                button.CssClass = "buttons";
                button.ID = reader["id_orderdone"].ToString();
                button.Attributes["email"] = reader["mail"].ToString();
                button.Click += new EventHandler(Press);

                var buttonDel = new Button();
                buttonDel.Text = "Usuń";
                buttonDel.CssClass = "buttons";
                buttonDel.Attributes["id_order"] = reader["id_orderdone"].ToString();
                buttonDel.Click += new EventHandler(PressDel);

                container.Controls.Add(name);
                container.Controls.Add(rodzaj);
                container.Controls.Add(cena);
                container.Controls.Add(prod);
                container.Controls.Add(button);
                container.Controls.Add(buttonDel);



                Panel1.Controls.Add(container);
            }
            if (ReaderEmpty)
                return 2;
            else
            {
                if (nazwa == "True")
                    return 3;
                else
                    return 1;
            }
        }

        private void Press(object sender, EventArgs e)

        {
            Button butt = (Button)sender;
            //lbEdit.Text = butt.Attributes["idProduct"];
            Panel2.Visible = false;
            Panel3.Visible = true;
            Button1.Attributes["clickid"] = butt.ID;
            Button1.Attributes["email"] = butt.Attributes["email"];

        }

        private void PressDel(object sender, EventArgs e)
        {
            Button butt = (Button)sender;
            //lbEdit.Text = butt.Attributes["idProduct"];
            string id = butt.Attributes["id_order"].ToString();
            LInfo.Text = id;
            Insert("DELETE FROM `ordersdone` WHERE `id_orderdone` = " + id + " ");
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
            catch (MySql.Data.MySqlClient.MySqlException ex) { }
            return null;
        }

        protected void backAdmin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }

        protected void LogOut_Click1(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Response.Redirect("Main.aspx");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {

                using (SmtpClient client = new SmtpClient())
                {

                    var credential = new NetworkCredential
                    {
                        UserName = "",
                        Password = ""
                    };
                    client.Credentials = credential;
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;

                    var message = new MailMessage();
                    message.To.Add(new MailAddress(Button1.Attributes["email"].ToString()));
                    message.From = new MailAddress("");
                    message.Subject = "Zmiana statusu Twojego zamówienia";
                    message.IsBodyHtml = true;
                    message.Body = "<!DOCTYPE html>" +
                    "<body> " +
                        "<div id = 'mailBd' style='font-size: 20px'>" +
                            "Cześć, Twoje zamówienie właśnie zmieniło status na: <b>" + RadioButtonList1.SelectedValue + "</b>" +
                        "</div>" +
                    "</body> " +
                    "</html>";

                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                LInfo.Text = "You can not send messages (" + ex.Message + ")";
            }

            Panel2.Visible = true;
            Panel3.Visible = false;

        }
    }

}