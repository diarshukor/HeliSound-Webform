using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ChangePassword : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {

   }

   protected void change(object sender, EventArgs e)
   {
      MembershipUser usr = Membership.GetUser(UserName.Text);
      if (usr.ChangePassword(Password.Text, newPassword.Text))
      {
         Response.Redirect("~/Account/Login.aspx");
      }
   }
}