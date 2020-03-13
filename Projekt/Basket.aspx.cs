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
    public partial class Basket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtBuy.Visible = false;
            if (Session["login"] != null)
            {
                Hello.Text = "Witaj " + Session["name"].ToString() + ". Oto Twój koszyk: ";

                var id = Session["login"];
                reader("SELECT * FROM produkty, orders WHERE produkty.id = orders.id_Product AND orders.nick = " + id);
            }
            else
            {
                Response.Redirect("CheckLoginRegister.aspx");
            }
            
        }

        public int RemoveProduct(string toDo)
        {

            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = toDo;
            MySqlDataReader reader = command.ExecuteReader();

            return 1;

        }

        private void Remove(object sender, EventArgs e)
        {
            LinkButton butt = (LinkButton)sender;
            var id_Order = butt.Attributes["id_Order"];
            RemoveProduct("DELETE FROM `orders` WHERE id_Order=" + id_Order + ";");
            Response.Redirect("Basket.aspx");
        }

        //SELECT * FROM produkty, orders WHERE produkty.id = orders.id_Product AND orders.nick = 17


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


        public int reader(string where)
        {
            int cenaAll = 0;
            bool ReaderEmpty = true;

            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = where;
            MySqlDataReader reader = command.ExecuteReader();

            string nazwa = "False";
            Session["cena"] = 0;
            Session["Products"] = 0;

            while (reader.Read())
            {
                ReaderEmpty = false;
                var container = new HtmlGenericControl("div");
                container.Attributes["class"] = "productContainer";

                var img = new HtmlGenericControl("div");
                img.Attributes["style"] = "background-image: url(./product/" + reader["zdjecie"].ToString() + ")";
                img.Attributes["class"] = "productImg";


                var button = new LinkButton();
                button.Text = "<i class='fas fa-trash'></i>";
                button.CssClass = "buttonBasket";
                button.ID = reader["id_Order"].ToString();
                button.Attributes["id_Order"] = reader["id_Order"].ToString();
                button.Click += new EventHandler(Remove);

                Session["Products"] += reader["id_Product"].ToString() + ",";

                var cena = new HtmlGenericControl("p") { InnerText = "Nazwa: " + reader["nazwa"].ToString() };
                cena.Attributes["class"] = "productDescription";

                var des = new HtmlGenericControl("p") { InnerText = "Cena: " + reader["cena"].ToString() + " zł" };
                cenaAll += Convert.ToInt32(reader["cena"].ToString());
                des.Attributes["class"] = "productDescription";

                var brand = new HtmlGenericControl("p") { InnerText = "Wybrany rozmiar:  " + reader["size"].ToString() };
                brand.Attributes["class"] = "productDescription";

                var kom = new HtmlGenericControl("div") { InnerText = reader["komentarz"].ToString() };
                kom.Attributes["class"] = "productKom";

                img.Controls.Add(button);
                container.Controls.Add(img);
                container.Controls.Add(cena);
                container.Controls.Add(des);
                container.Controls.Add(brand);
                container.Controls.Add(kom);



                PanelBasket.Controls.Add(container);
            }
            Session["price"] = cenaAll.ToString();
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

        public int KuponCheck(string where)
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
                Session["numberKupon"] = reader["ile"].ToString();

            }
            if (ReaderEmpty)
            {
                return 4; // nie ma takiego kuponu
            }
            return 1;
        }


        protected void BtPrice_Click(object sender, EventArgs e)
        {
           
            var kupon = Kupon.Text;
            int minus = 0;


                KuponCheck("SELECT * FROM `kupony` WHERE `kod` = '" + kupon + "'");
                if (Session["numberKupon"] != null)
                {
                    minus = Int32.Parse(Session["numberKupon"].ToString());
                }


                float cena = Convert.ToInt32(Session["price"]);
                double rabat = (100 - minus);
                double cenaRabat = cena * (rabat/100);

                Summary.Text = "Suma: " + cenaRabat.ToString() + " zł (Przed rabatem: " + cena + " zł)";


                if (RBDostawy.Text == "Kurier Poczta Polska - 10 zł")
                {
                    cenaRabat += 10;
                    cena += 10;

                }
                if (RBDostawy.Text == "Kurier DPD - 11 zł")
                {
                    cenaRabat += 11;
                    cena += 11;
                }
                if (RBDostawy.Text == "Kurier DHL - 15 zł")
                {
                    cenaRabat += 15;
                    cena += 15;
                }
                if (RBDostawy.Text == "Paczkomaty InPost - 12zł")
                {
                    cenaRabat += 12;
                    cena += 12;
                }

                SumaryDostawa.Text = "Suma z dostawą: " + cenaRabat.ToString() + " zł (Przed rabatem: " + cena + " zł)";
                Session["priceRD"] = cenaRabat.ToString();

            BtBuy.Visible = true;

        }

        protected void BtBuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("Order.aspx");
        }

        protected void LinkBBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
        
    }
}