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
            if (!IsPostBack) {
                Response.Write("<center><h1>Read data from a database</h1>");
                Response.Write("<br/>");
                string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                string sqlString = "select * from customers";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                string sqlStringDropDownList = "select distinct Country from customers";
                SqlCommand cmd2 = new SqlCommand(sqlStringDropDownList, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read() == true) {
                    DropDownList1.Items.Add(new ListItem(dr2["Country"].ToString(),
                    dr2["Country"].ToString()));
                }
                dr2.Close();
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            Response.Write("<center><h1>Read data from a database </ h1 ></ center >< hr /> ");
            Response.Write("<br/>");
            String txtValue = TextBox1.Text;
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            string sqlString = "select * from customers where Country=@Country";
            SqlCommand cmd = new SqlCommand(sqlString, con);
            //to prevent sql injection
            cmd.Parameters.AddWithValue("@Country", txtValue);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e) {
            if (IsPostBack) {
                Response.Write("<center><h1>Insert data into the database </ h1 >");
                Response.Write("<br/>");
                String customerIDString = customerID.Text;
                String companyNameString = companyName.Text;
                String contactNameString = contactName.Text;
                String contactTitleString = contactTitle.Text;
                String addressString = address.Text;
                String cityString = city.Text;
                String regionString = region.Text;
                String postCodeString = postCode.Text;
                String countryString = country.Text;
                String phoneString = phone.Text;
                String faxString = fax.Text;

                string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                string sqlString = "insert into customers values (@customerIDString, @companyNameString, @contactNameString, @contactTitleString, @addressString," +
                    "@cityString, @regionString, @postCodeString, @countryString, @phoneString, @faxString";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                //to prevent sql injection
                cmd.Parameters.AddWithValue("@customerIDString", customerIDString);
                cmd.Parameters.AddWithValue("@companyNameString", companyNameString);
                cmd.Parameters.AddWithValue("@contactNameString", contactNameString);
                cmd.Parameters.AddWithValue("@contactTitleString", contactTitleString);
                cmd.Parameters.AddWithValue("@addressString", addressString);
                cmd.Parameters.AddWithValue("@cityString", cityString);
                cmd.Parameters.AddWithValue("@regionString", regionString);
                cmd.Parameters.AddWithValue("@postCodeString", postCodeString);
                cmd.Parameters.AddWithValue("@countryString", countryString);
                cmd.Parameters.AddWithValue("@phoneString", phoneString);
                cmd.Parameters.AddWithValue("@faxString", faxString);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                con.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) {
            if (IsPostBack) {
                Response.Write("<br/>");
                Response.Write("<center><h1>Read data from a database</h1>");
                Response.Write("<br/>");
                String txtValue = DropDownList1.SelectedValue.ToString();
                string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                string sqlString = "select * from customers where Country=@Country";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                cmd.Parameters.AddWithValue("@Country", txtValue);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                con.Close();
            }
        }
    }
}