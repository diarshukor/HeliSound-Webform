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

public partial class Administration_Roles : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      if (!IsPostBack) gvbind();

   }
   protected void gvbind()
   {
      GridView1.DataSource=Roles.GetAllRoles();
      GridView1.DataBind();

   }

}