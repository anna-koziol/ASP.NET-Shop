using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Projekt
{
    public partial class CheckLoginRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                form1.Visible = false;
                form2.Visible = true;
                lName.Text = "Twój nick: " + Session["name"].ToString();
                var img = new HtmlGenericControl("img");
                img.Attributes["src"] = "./img/"+ Session["img"].ToString();
                img.Attributes["class"] = "userImg";

                PanelImg.Controls.Add(img);
            }
            else
            {
                form1.Visible = true;
                form2.Visible = false;

            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session["login"] = null;
            Session["name"] = null;
            Session["img"] = null;

            Response.Redirect("Main.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }


    }
}