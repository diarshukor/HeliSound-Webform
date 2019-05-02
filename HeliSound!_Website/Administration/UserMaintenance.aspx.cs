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

public partial class Administration_UserMaintenance : System.Web.UI.Page
{
   SqlConnection conn =
new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
#pragma warning disable CS0414 // The field 'UserMaintenance.isDoubleName' is assigned but its value is never used
   bool isDoubleName = false;
#pragma warning restore CS0414 // The field 'UserMaintenance.isDoubleName' is assigned but its value is never used
   protected void Page_Load(object sender, EventArgs e)
   {
      if (!IsPostBack) gvbind();

   }
   protected void gvbind()
   {


            GridView1.DataSource = Membership.GetAllUsers();
            GridView1.DataBind();

   }


   protected void saveitem_Click(object sender, EventArgs e)
   {
      
   }
}