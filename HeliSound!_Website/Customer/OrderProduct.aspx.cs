using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class Customer_OrderProduct : System.Web.UI.Page
{
   private double sum;
   // status positive products only
   private List<string> listofsuppliers = new List<string>() { "" };
   private List<string> listofcategories = new List<string>() { "" };
   private List<string> listofproducts = new List<string>() { "" };
   private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
   private bool isDD = false;
   private bool categoryLast;
   private string price;
   private List<string> months = new List<string>() { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
   private List<string> years = new List<string>() { "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", };
   private List<string> provinces = new List<string>() { "ON", "AB", "NB", "NV", "PEI", "BC", "SA","MA", "QC"};

   protected void Page_Load(object sender, EventArgs e)
   {
      suppliers.EnableViewState = true;
      if(!IsPostBack)
      {
         month.DataSource = months;
            month.DataBind();
         year.DataSource = years;
         year.DataBind();
         province.DataSource = provinces;
         province.DataBind();
         //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
         SqlCommand sqlCommand = new SqlCommand();
         sqlCommand.CommandType = CommandType.StoredProcedure;

         sqlCommand.CommandText = "sp_getSuppliers";
         //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
         sqlCommand.Connection = conn;
         sqlCommand.Connection.Open();
         sqlCommand.ExecuteNonQuery();
         SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
         DataSet ds = new DataSet();
         da.Fill(ds);

         foreach (DataTable table in ds.Tables)
         {
            foreach (DataRow row in table.Rows)
            {
               foreach (object item in row.ItemArray)
               {
                  listofsuppliers.Add(item.ToString());
               }
            }
         }
         suppliers.DataSource = listofsuppliers;
         suppliers.DataBind();
         sqlCommand.Connection.Close();
      }
      this.suppliers.SelectedIndexChanged += new System.EventHandler(Suppliers_SelectedIndexChanged);

      if (category.SelectedIndex > 0)
      {
         if (products.Text != null) gvbind();
         SqlCommand sqlCommand1 = new SqlCommand();
         //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
         sqlCommand1.CommandText = "sp_getProductforDropdown";
         sqlCommand1.Connection = conn;
         sqlCommand1.CommandType = CommandType.StoredProcedure;
         //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
         sqlCommand1.Parameters.AddWithValue("@supplier", suppliers.SelectedItem.Text.ToString());
         sqlCommand1.Parameters.AddWithValue("@category", category.SelectedItem.Text.ToString());

         sqlCommand1.Connection.Open();

         sqlCommand1.ExecuteNonQuery();
         isDD = false;
         SqlDataAdapter da = new SqlDataAdapter(sqlCommand1);
         DataSet ds = new DataSet();
         da.Fill(ds);
         foreach (DataTable table in ds.Tables)
         {
            foreach (DataRow row in table.Rows)
            {
               foreach (object item in row.ItemArray)
               {
                  listofproducts.Add(item.ToString());
               }
            }
         }
         sqlCommand1.Connection.Close();

         products.DataSource = listofproducts;
         products.DataBind();
      }
      
   }


   protected void Suppliers_SelectedIndexChanged(object sender, EventArgs e)
   {
      //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
      SqlCommand sqlCommand = new SqlCommand();
      categoryLast = true;
      sqlCommand.CommandType = CommandType.StoredProcedure;

      sqlCommand.CommandText = "sp_getCategory";
      sqlCommand.Parameters.AddWithValue("@supplier", suppliers.SelectedItem.Text.ToString());
      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
      sqlCommand.Connection = conn;
      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      foreach (DataTable table in ds.Tables)
      {
         foreach (DataRow row in table.Rows)
         {
            foreach (object item in row.ItemArray)
            {
               listofcategories.Add(item.ToString());
            }
         }
      }
      sqlCommand.Connection.Close();
      category.DataSource = listofcategories;
      category.DataBind();
   }

   protected void gvbind()
   {
      //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
      SqlCommand sqlCommand2 = new SqlCommand();

      sqlCommand2.CommandType = CommandType.StoredProcedure;

      sqlCommand2.CommandText = "sp_LookUpandAdd";
      sqlCommand2.Parameters.AddWithValue("@supplier", suppliers.Text.ToString());
      sqlCommand2.Parameters.AddWithValue("@category", category.Text.ToString());
      sqlCommand2.Parameters.AddWithValue("@product", products.Text.ToString());
      sqlCommand2.Connection = conn;
      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
      sqlCommand2.Connection.Open();
      sqlCommand2.ExecuteNonQuery();
      sqlCommand2.Connection.Close();

      SqlDataAdapter da = new SqlDataAdapter(sqlCommand2);
      DataSet ds = new DataSet();
      da.Fill(ds);
      if (ds.Tables[0].Rows.Count > 0)
      {
         GridView1.DataSource = ds;
         GridView1.DataBind();
      }
   }



   protected void saveitem_Clicks(object sender, EventArgs e)
   {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Connection = conn;
      sqlCommand.CommandText = "sp_savebilling";

      foreach (GridViewRow s in GridView1.Rows)
      {

            sqlCommand.Connection.Open();
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@user", User.Identity.Name.ToString());
            sqlCommand.Parameters.AddWithValue("@supplier", s.Cells[2].Text.ToString());
            sqlCommand.Parameters.AddWithValue("@Category", s.Cells[3].Text.ToString());
            sqlCommand.Parameters.AddWithValue("@price", ((double.Parse(s.Cells[4].Text)) * 1.13).ToString());
            sqlCommand.Parameters.AddWithValue("@description", "...");
            sqlCommand.Parameters.AddWithValue("@contact", name.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@product", (string)s.Cells[1].Text.ToString());
            sqlCommand.Parameters.AddWithValue("@house", housenumber.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@street", street.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@apt", apt.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@city", city.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@province", province.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@creditname", name.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@ccnumber", CCNumber.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@securitycode", int.Parse(securitycode.Text.ToString()));
            sqlCommand.Parameters.AddWithValue("@month", month.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@year", int.Parse(year.Text.ToString()));
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();

         
         price = s.Cells[4].Text;
         sum = double.Parse(price);
      }
      sum = sum * 1.13;

      if (sum > 0)
      {
        

         odrplaced.Visible = true;
         odrplaced.Text = "Items have been ordered at price of" + sum +" $ !!!";
         sum = 0;
      }
   }





}
