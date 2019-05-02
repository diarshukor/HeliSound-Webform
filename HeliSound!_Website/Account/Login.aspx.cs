using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : Page
{
   protected void Page_Load(object sender, EventArgs e)
   {

   }


   protected void LoginButton_Click(object sender, EventArgs e)
   {
      // Get the email address entered
      TextBox EmailTextBox = Login1.FindControl("UserName") as TextBox;
      string email = EmailTextBox.Text.Trim();

      // Verify that the username/password pair is valid
      if (Membership.ValidateUser(Login1.UserName, Login1.Password))
      {
         // Username/password are valid, check email
         MembershipUser usrInfo = Membership.GetUser(Login1.UserName);
         if (usrInfo != null && string.Compare(usrInfo.Email, email, true) == 0)
         {
            lblMsg.Text = "LOGGED IN";
         }
         else
         {
            // Email address is invalid...
         }
      }
      else
      {
         // Username/password are not valid...
      }
   }
}