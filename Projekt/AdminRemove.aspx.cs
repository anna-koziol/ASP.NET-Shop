using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Projekt
{
    public partial class AdminRemove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                reader("produkty");
            }
            else
            {
                lbRemove.Text = "Sesja wygasła, zaloguj się ponownie na konto administratora";
            }
        }

        private void Press(object sender, EventArgs e)

        {
            Button butt = (Button)sender;
            Remove("DELETE FROM `produkty` WHERE id=" + butt.Attributes["idProduct"] + ";");
            Response.Redirect("AdminRemove.aspx");
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

        public int Remove(string toDo)
        {

            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = toDo;
            MySqlDataReader reader = command.ExecuteReader();

            return 1;

        }

        public int reader(string where)
        {
            bool ReaderEmpty = true;

            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * FROM " + where;
            MySqlDataReader reader = command.ExecuteReader();

            string nazwa = "False";

            while (reader.Read())
            {
                ReaderEmpty = false;
                var container = new HtmlGenericControl("div");
                container.Attributes["class"] = "productContainer";

                var name = new HtmlGenericControl("p") { InnerText = reader["nazwa"].ToString() };
                name.Attributes["class"] = "nameP";

                var rodzaj = new HtmlGenericControl("p") { InnerText = reader["rodzaj"].ToString() };
                rodzaj.Attributes["class"] = "rodzajP";

                var cena = new HtmlGenericControl("p") { InnerText = reader["cena"].ToString() + " zł" };
                cena.Attributes["class"] = "cenaP";

                var button = new Button();
                button.Text = "Usuń";
                button.CssClass = "buttons";
                button.ID = reader["id"].ToString();
                button.Attributes["idProduct"] = reader["id"].ToString();

                button.Click += new EventHandler(Press);

                container.Controls.Add(name);
                container.Controls.Add(rodzaj);
                container.Controls.Add(cena);
                container.Controls.Add(button);

                PanelRemove.Controls.Add(container);
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


        protected void backAdmin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }

        protected void LogOut_Click1(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Response.Redirect("Main.aspx");
        }
    }
}