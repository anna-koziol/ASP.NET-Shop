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
    public partial class AdminAdd : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null) {
                messageAdd.Text = "Sesja wygasła, zaloguj się ponownie na konto administratora";
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
                //"Error";
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

        protected void addProduct_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                messageAdd.Text = "DODANO PRODUKT";
                string nazwa = TB1.Text;
                string rodzaj = "Szpilki";

                if (RadioButtonList1.SelectedItem != null)
                {
                    rodzaj = RadioButtonList1.SelectedItem.Value.ToString();
                }

                string cena = TextBox2.Text;
                string rozmiary = TextBox3.Text;
                string kolory = TextBox5.Text;
                string obcas = TextBox6.Text;
                string material = TextBox7.Text;
                string dod = TextBox8.Text;

                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                System.IO.Directory.CreateDirectory(Server.MapPath("product") + "\\");
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {

                    string SaveLocation = Server.MapPath("product") + "\\" + filename;
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(SaveLocation);
                        Insert("INSERT INTO `produkty`" +
                            "(`id`, `nazwa`, `rodzaj`, `cena`, `rozmiary`, `zdjecie`, `kolory`, `obcas`, `material`, `komentarz`)" +
                            " VALUES ('','" + nazwa + "','" + rodzaj + "'," + cena + ",'" + rozmiary + "','" + filename + "','" + kolory + "','" + obcas + "','" + material + "','" + dod + "')");

                        TB1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox5.Text = "";
                        TextBox6.Text = "";
                        TextBox7.Text = "";
                        TextBox8.Text = "";
                    }
                    catch (Exception ex)
                    {
                        messageAdd.Text = "Error: " + ex.Message;
                    }
                }
                else
                {
                    messageAdd.Text = "Nie wybrano zdjęcia...";
                }

            }

            else
            {
                messageAdd.Text = "Sesja wygasła, zaloguj się ponownie na konto administratora";
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