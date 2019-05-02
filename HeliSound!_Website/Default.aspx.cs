using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      MembershipCreateStatus xx = new MembershipCreateStatus();
      var s = Membership.CreateUser("dshukor@gmail.com","Password","dshukor@gmail.com","How old are you?", "30", true, out xx);
      string[] vs = new string[1] { "dshukor@gmail.com" };
      //Roles.AddUsersToRole(vs, "Administrator");
    }
}