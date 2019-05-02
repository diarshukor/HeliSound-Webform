using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : Page
{
   SqlConnection conn =
    new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
   string[] useradmin = { "dshukor@gmail.com" };
   protected void Page_Load(object sender, EventArgs e)
   {
      //Roles.CreateRole("Administrator");
      //Roles.AddUsersToRole(useradmin, "Administrator");
   }

}