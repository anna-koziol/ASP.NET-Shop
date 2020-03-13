using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Projekt
{
    public partial class Register : System.Web.UI.Page
    {

        public static System.Web.UI.ScriptResourceMapping ScriptResourceMapping { get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
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


        public int Reader(string toDo)
        {
            bool ReaderEmpty = true;
            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = toDo;
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReaderEmpty = false;
            }
            if (ReaderEmpty)
            {
                return 0; // nie ma tkaiego loginu
            }

            return 1;
           
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


        //HASHOWANIE HASŁA
        private const int SaltSize = 16;
        private const int HashSize = 20;

        public static string Hash(string password, int iterations)
        {

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
            var base64Hash = Convert.ToBase64String(hashBytes);

            return string.Format("$MYHASH$V1${0}${1}", iterations, base64Hash);
        }


        public static string Hash(string password)
        {
            return Hash(password, 10000);
        }

        public static bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$MYHASH$V1$");
        }

        public static bool Verify(string password, string hashedPassword)
        {
            // Check hash
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            // Extract iteration and Base64 string
            var splittedHashString = hashedPassword.Replace("$MYHASH$V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            // Get hash bytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            // Get salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Get result
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }


    protected void Button1_Click(object sender, EventArgs e)
        {
            string login = TB1.Text;
            string pass = TB2.Text;
            string mail = TB3.Text;

            string filename = Path.GetFileName(FU1.PostedFile.FileName);

            int ret = Reader("SELECT * FROM `login` WHERE `nick` = '" + login + "'");

            if (ret == 0)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("img") + "\\");
                if ((FU1.PostedFile != null) && (FU1.PostedFile.ContentLength > 0))
                {

                    string SaveLocation = Server.MapPath("img") + "\\" + filename;
                    try
                    {
                        //HASHOWANIE HASŁA
                        var passwordHASH = Hash(pass);

                        FU1.PostedFile.SaveAs(SaveLocation);
                        Insert("INSERT INTO `login`(`id`, `nick`, `password`, `mail`, `photo`) VALUES ('', '" + login + "','" + passwordHASH + "','" + mail + "','" + filename + "')");
                        message.Text = "Brawo, dołączyłeś do renee";

                        //WYSYŁANIE KUPONU
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
                                message.To.Add(new MailAddress(mail));

                                message.From = new MailAddress("");
                                message.Subject = "RENEE dziękujemy za rejestracje";
                                message.IsBodyHtml = true;

                                message.Body = "<!DOCTYPE><html> <body> <div style='font-size: 20px'>  <b>" +
                                login + " witaj w RENEE, </b> dziękujęmy za dołączenie do naszego sklepu." +
                                " Otrzymujesz kod na kolejne zakupy - 10%! Podczas składania zamówienia wpisz:" +
                                " register10 </div></body></html>";
                                client.Send(message);
                            }
                        }
                        catch (Exception ex)
                        {
                            //BŁĄD
                        }
                        Response.Redirect("Main.aspx");

                    }
                    catch (Exception ex)
                    {
                        message.Text = "Error: " + ex.Message;
                    }
                }
                else
                {
                    message.Text = "Nie wybrano zdjęcia...";
                }
            }
            else
            {
                NickValid.Text = "Ten nick jest już zajęty";
            }


        }
    }
}