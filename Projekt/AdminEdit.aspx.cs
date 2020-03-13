using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Projekt
{

    public partial class AdminEdit : System.Web.UI.Page
    {
        string idProduct = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            reader("produkty");
        }

        private void Press(object sender, EventArgs e)

        {
            Button butt = (Button)sender;
            //lbEdit.Text = butt.Attributes["idProduct"];
            idProduct = butt.Attributes["idProduct"].ToString();
            Panel1.Visible = false;
            Panel2.Visible = true;

            TB1.Text = butt.Attributes["nazwa"];
            RadioButtonList1.SelectedValue = butt.Attributes["rodzaj"]; 
            TextBox2.Text = butt.Attributes["cena"];
            TextBox3.Text = butt.Attributes["rozmiary"];
            TextBox5.Text = butt.Attributes["kolory"];
            TextBox6.Text = butt.Attributes["obcas"];
            TextBox7.Text = butt.Attributes["material"];
            TextBox8.Text = butt.Attributes["komenatrz"];

            lbEdit.Text = idProduct;


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

        public int Update(string toDo)
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

                //var button = new Button();
                //button.CssClass
                //button.Click += new EventHandler(Edit);

                var name = new HtmlGenericControl("p") { InnerText = reader["nazwa"].ToString() };
                name.Attributes["class"] = "nameP";

                var rodzaj = new HtmlGenericControl("p") { InnerText = reader["rodzaj"].ToString() };
                rodzaj.Attributes["class"] = "rodzajP";

                var cena = new HtmlGenericControl("p") { InnerText = reader["cena"].ToString() + " zł"};
                cena.Attributes["class"] = "cenaP";

                var button = new Button();
                button.Text = "Edytuj";
                button.CssClass = "buttons";
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

                container.Controls.Add(name);
                container.Controls.Add(rodzaj);
                container.Controls.Add(cena);
                container.Controls.Add(button);


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


        protected void btEdit_Click(object sender, EventArgs e)
        {

            //UPDATE
            if (Session["admin"] != null)
            {
                string nazwa = TB1.Text;
                string rodzaj = RadioButtonList1.SelectedItem.Value.ToString();
                string cena = TextBox2.Text;
                string rozmiary = TextBox3.Text;
                string kolory = TextBox5.Text;
                string obcas = TextBox6.Text;
                string material = TextBox7.Text;
                string dod = TextBox8.Text;

               
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                System.IO.Directory.CreateDirectory(Server.MapPath("product") + "\\");
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0) && lbEdit.Text != "0")
                {

                    string SaveLocation = Server.MapPath("product") + "\\" + filename;
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(SaveLocation);
                        Update("UPDATE `produkty` SET `nazwa`='"+nazwa+"',`rodzaj`='"+rodzaj+"'," +
                   "`cena`="+cena+",`rozmiary`='"+rozmiary+"',`zdjecie`='"+filename+"',`kolory`='"+kolory+"'," +
                   "`obcas`="+obcas+",`material`='"+material+"',`komentarz`='"+dod+"' where id = " + lbEdit.Text);


                    }
                    catch (Exception ex)
                    {
                        lbEdit.Text = "Error: " + ex.Message;
                    }
                }
                else if (lbEdit.Text != "0")
                {
                    

                    Update("UPDATE `produkty` SET `nazwa`='" + nazwa + "',`rodzaj`= '" + rodzaj + "' ," +
                     "`cena`= " + cena + ",`rozmiary`='" + rozmiary + "',`kolory`='" + kolory + "'," +
                     "`obcas`=" + obcas + ",`material`='" + material + "',`komentarz`= '" + dod + "' where id = " + lbEdit.Text);
                }
                else
                {
                    lbEdit.Text = "Błąd, popraw dane";
                }

                lbEdit.Text = "EDYTYOWANO";
                Response.Redirect("AdminEdit.aspx");
            }
            else
            {
                lbEdit.Text = "Sesja wygasła, zaloguj się ponownie na konto administratora";
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