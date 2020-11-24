using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAdo {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Response.Write("<center><h1>Read data from a database </ h1 ></ center >< hr /> ");
            Response.Write("<br/>");
            // step 1 Read connection string
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            //step 2 - create a sqlconnection
            SqlConnection con = new SqlConnection(s);
            // setup query string
            string sqlString = "select * from customers";
            // setup sql command object
            SqlCommand cmd = new SqlCommand(sqlString, con);
            //open the connection
            con.Open();
            //execute the command
            //use cmd.ExecuteReader() for SELECT statement.
            //use cmd.ExecuteScalar for return of count or single numbers.

            SqlDataReader dr = cmd.ExecuteReader();
            //use cmd.ExecuteNonQuery() for INSERT, UPDATE, DELETE.
            //Setup datasource for GridView
            GridView1.DataSource = dr;
            //Bind datasource to GridView
            GridView1.DataBind();
            //close datareader
            dr.Close();
            //close the connection
            con.Close();
        }
    }
}