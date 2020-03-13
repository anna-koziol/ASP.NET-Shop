using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

//przechodzenie Response.Redirect("nazwaoliku.aspx");
//logowanie sesje:
//stworznenie Session["nazwa"] = "wartość"; id zalogowanego użytkownika;
//usuwanie sesji Session.Remove(), Session["nazwa"] = null;
// wartośc Session["nazwa"]/ Session["nazwa"].ToString();
// zalogowany? if(Session["nazwa"] != null){jesteś zalogowana }
//
namespace Projekt
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            connect();
            reader("SELECT * FROM produkty");
            PanelMain.Visible = true;
            PanelProductOne.Visible = false;

            if (Session["login"] != null) {
                LInfo.Text = Session["login"].ToString();
            }
            else {
                LInfo.Text = "Nie jesteś zalogowany";
                testID.Text = "Musisz  być zalogowany aby wykonywać zakupy";
            }
            //reder()
            //klikasz na wyszukaj ==> Session["nazwa"] stwórz
            //if(Session["nazwaszukana"] != null){ reder(wyrażenie msql.. Session["nazwa"] = null)}
        }


        private void Press(object sender, EventArgs e)

        {
            LinkButton butt = (LinkButton)sender;
            LInfo.Text = butt.Attributes["nazwa"];
            PanelProductOne.Visible = true;
            PanelMain.Visible = false;

            Session["nameProduct"] = butt.Attributes["nazwa"].ToString();
            Session["idProduct"] = butt.Attributes["idProduct"].ToString();

            //GENEROWANIE SZCZEGÓŁÓW PRRODUKTU
            var containerOne = new HtmlGenericControl("div");
            containerOne.Attributes["class"] = "productOneContainer";

            var containerText = new HtmlGenericControl("div");
            containerText.Attributes["class"] = "containerText";

            var img = new HtmlGenericControl("div");
            img.Attributes["style"] = "background-image: url(./product/" + butt.Attributes["zdjecie"].ToString() + ")";
            img.Attributes["class"] = "productImgBig";


            var nazwa = new HtmlGenericControl("p") { InnerText = "Nazwa: " + butt.Attributes["nazwa"].ToString() };
            nazwa.Attributes["class"] = "productDescription";

            string[] rozmiaryArray = butt.Attributes["rozmiary"].ToString().Split(',');
            HtmlGenericControl selectPage = new HtmlGenericControl("select");
            selectPage.Attributes.Add("id", "selectPage");

            switch (rozmiaryArray.Length)
            {
                case 1:
                    var list = new List<string> { rozmiaryArray[0] };
                    list.Sort();
                    DropDownList1.DataSource = list;
                    DropDownList1.DataBind();
                    break;
                case 2:
                    list = new List<string> { rozmiaryArray[0], rozmiaryArray[1] };
                    list.Sort();
                    DropDownList1.DataSource = list;
                    DropDownList1.DataBind();
                    break;
                case 3:
                    list = new List<string> { rozmiaryArray[0], rozmiaryArray[1], rozmiaryArray[2] };
                    list.Sort();
                    DropDownList1.DataSource = list;
                    DropDownList1.DataBind();
                    break;
                case 4:
                    list = new List<string> { rozmiaryArray[0], rozmiaryArray[1], rozmiaryArray[2], rozmiaryArray[3] };
                    list.Sort();
                    DropDownList1.DataSource = list;
                    DropDownList1.DataBind();
                    break;
                case 5:
                    list = new List<string> { rozmiaryArray[0], rozmiaryArray[1], rozmiaryArray[2], rozmiaryArray[3], rozmiaryArray[4] };
                    list.Sort();
                    DropDownList1.DataSource = list;
                    DropDownList1.DataBind();
                    break;
                case 6:
                    list = new List<string> { rozmiaryArray[0], rozmiaryArray[1], rozmiaryArray[2], rozmiaryArray[3], rozmiaryArray[4], rozmiaryArray[5] };
                    list.Sort();
                    DropDownList1.DataSource = list;
                    DropDownList1.DataBind();
                    break;
                case 7:
                    list = new List<string> { rozmiaryArray[0], rozmiaryArray[1], rozmiaryArray[2], rozmiaryArray[3], rozmiaryArray[4], rozmiaryArray[5], rozmiaryArray[6] };
                    list.Sort();
                    DropDownList1.DataSource = list;
                    DropDownList1.DataBind();
                    break;
            }
            

            var rodzaj = new HtmlGenericControl("p") { InnerText = "Rodzaj: " + butt.Attributes["rodzaj"].ToString() };
            rodzaj.Attributes["class"] = "productDescription";

            var cena = new HtmlGenericControl("p") { InnerText = "Cena: " + butt.Attributes["cena"].ToString() + " zł" };
            cena.Attributes["class"] = "productDescription";

            var rozmairy = new HtmlGenericControl("p") { InnerText = "Rozmiary: " };
            rozmairy.Attributes["class"] = "productDescription";

            var kolory = new HtmlGenericControl("p") { InnerText = "Kolor: " + butt.Attributes["kolory"].ToString() };
            kolory.Attributes["class"] = "productDescription";

            var obcas = new HtmlGenericControl("p") { InnerText = "Obcas: " + butt.Attributes["obcas"].ToString() };
            obcas.Attributes["class"] = "productDescription";

            var material = new HtmlGenericControl("p") { InnerText = "Materiał: " + butt.Attributes["material"].ToString() };
            material.Attributes["class"] = "productDescription";

            var komentarz = new HtmlGenericControl("p") { InnerText = "Komentarz: " + butt.Attributes["komentarz"].ToString() };
            komentarz.Attributes["class"] = "productDescription";

            containerOne.Controls.Add(img);

            containerText.Controls.Add(nazwa);
            containerText.Controls.Add(rodzaj);
            containerText.Controls.Add(cena);
            containerText.Controls.Add(rozmairy);
            containerText.Controls.Add(kolory);
            containerText.Controls.Add(obcas);
            containerText.Controls.Add(material);
            containerText.Controls.Add(komentarz);

            containerOne.Controls.Add(containerText);

            ProductDetails.Controls.Add(containerOne);

        }


        private MySqlConnection connect()
        {
            Test.Text = "Connecting 1..."; 
            string myconnection =
              "Server=localhost;" +
               //"Port=8080;" +
              "Database=renee;" +
              "User=root;" +
              "Password=;"+
              "SslMode=none; ";
            
            MySqlConnection connection = new MySqlConnection(myconnection);
          
            try
            {
                Test.Text = "Connecting 2...";
                connection.Open();
                Test.Text = "Connected";
                return connection;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Test.Text = "Error";
            }
            return null;
        }


        public int reader(string where)
        {

            bool ReaderEmpty = true;

            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText =  where;
            MySqlDataReader reader = command.ExecuteReader();

            string nazwa = "False";

            while (reader.Read())
            {
                ReaderEmpty = false;
                var container = new HtmlGenericControl("div");
                container.Attributes["class"] = "productContainer";

                var img = new HtmlGenericControl("div");
                img.Attributes["style"] = "background-image: url(./product/" + reader["zdjecie"].ToString() + ")";
                img.Attributes["class"] = "productImg";


                var button = new LinkButton();
                button.Text = "<i class='fas fa-angle-double-right'></i>";
                button.CssClass = "buttonBasket";
                button.ID = reader["id"].ToString();
                button.Attributes["idProduct"] = reader["id"].ToString();
                button.Attributes["nazwa"] = reader["nazwa"].ToString();
                button.Attributes["rodzaj"] = reader["rodzaj"].ToString();
                button.Attributes["cena"] = reader["cena"].ToString();
                button.Attributes["rozmiary"] = reader["rozmiary"].ToString();
                button.Attributes["zdjecie"] = reader["zdjecie"].ToString();
                button.Attributes["kolory"] = reader["kolory"].ToString();
                button.Attributes["obcas"] = reader["obcas"].ToString();
                button.Attributes["material"] = reader["material"].ToString();
                button.Attributes["komentarz"] = reader["komentarz"].ToString();

                button.Click += new EventHandler(Press);

                var cena = new HtmlGenericControl("p") { InnerText = "Nazwa: " + reader["nazwa"].ToString() };
                cena.Attributes["class"] = "productDescription";

                var des = new HtmlGenericControl("p") { InnerText = "Cena: " + reader["cena"].ToString() + " zł"};
                des.Attributes["class"] = "productDescription";

                var brand = new HtmlGenericControl("p") { InnerText = "Rodzaj:  " + reader["rodzaj"].ToString() };
                brand.Attributes["class"] = "productDescription";

                var kom = new HtmlGenericControl("div") { InnerText = reader["komentarz"].ToString() };
                kom.Attributes["class"] = "productKom";

                img.Controls.Add(button);
                container.Controls.Add(img);
                container.Controls.Add(cena);
                container.Controls.Add(des);
                container.Controls.Add(brand);
                container.Controls.Add(kom);



                PanelProduct.Controls.Add(container);
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Logowanie
            Response.Redirect("CheckLoginRegister.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //Koszyk
            LInfo.Text = "2";
            Response.Redirect("Basket.aspx");
            //SELECT * FROM produkty, orders WHERE produkty.id = orders.id_Product AND orders.nick = 17

        }


        protected void ShowByCategory_Click(object sender, EventArgs e)
        {
            //SORTOWANIE
            if (RadioButtonList1.SelectedItem != null)
            {
                if (RadioButtonList1.SelectedItem.Value.ToString() != "Wszystko")
                {
                    LInfo.Text = RadioButtonList1.SelectedItem.Value.ToString();
                    PanelProduct.Controls.Clear();
                    reader("SELECT * FROM produkty WHERE rodzaj = '" + RadioButtonList1.SelectedItem.Value.ToString() + "'");
                }
                else
                {
                    //wszystko
                    PanelProduct.Controls.Clear();
                    reader("SELECT * FROM produkty");
                }
                
            }
            else
            {
                //wszystko
                PanelProduct.Controls.Clear();
                reader("SELECT * FROM produkty");
            }
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

        protected void Buy_Click(object sender, EventArgs e)
        {
            string size = DropDownList1.SelectedValue;
            
            if (Session["login"] != null && Session["nameProduct"] != null && Session["idProduct"] != null)
            {
                Insert("INSERT INTO `orders`(`id_Order`, `name`, `nick`, `size`, `count`, `id_Product`) VALUES ('','" + Session["nameProduct"].ToString() + "','" + Session["login"].ToString() + "','" + size + "'," + 1 + ",'" + Session["idProduct"].ToString() + "')");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Dodano do koszyka');", true);
            }
            else
            {
                testID.Text = "Musisz  być zalogowany aby wykonywać zakupy";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Musisz  być zalogowany!');", true);
            }

        }

        protected void LinkBBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}