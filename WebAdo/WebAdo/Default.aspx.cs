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
                addDataToDropdown();
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

        protected void Button1_Click(object sender, EventArgs e) { // Read record from db
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

        protected void Button2_Click(object sender, EventArgs e) { // Add record to db
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
                    "@cityString, @regionString, @postCodeString, @countryString, @phoneString, @faxString)";
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

                //Console.WriteLine(cmd.Parameters);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                showAllFromCustomers();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) { // Update a record in db
            if (IsPostBack) {
                Response.Write("<center><h1>Update data in the database. For no change to a field, enter the same value as in the database</ h1 >");
                Response.Write("<br/>");

                String customerIDString = customerIDUpdate.Text;
                String companyNameString = companyNameUpdate.Text;
                String contactNameString = contactNameUpdate.Text;
                String contactTitleString = contactTitleUpdate.Text;
                String addressString = addressUpdate.Text;
                String cityString = cityUpdate.Text;
                String regionString = regionUpdate.Text;
                String postCodeString = postCodeUpdate.Text;
                String countryString = countryUpdate.Text;
                String phoneString = phoneUpdate.Text;
                String faxString = faxUpdate.Text;

                string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);

                string sqlString = "update Customers set CompanyName = @companyNameString, ContactName = @contactNameString, ContactTitle = @contactTitleString, " +
                    "Address = @addressString, City = @cityString, Region = @regionString, PostalCode = @postCodeString, Country = @countryString, Phone = @phoneString," +
                    "Fax = @faxString where CustomerID = @customerIDString";

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

                //Console.WriteLine(cmd.Parameters);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                showAllFromCustomers();
            }
        }

        protected void Button4_Click(object sender, EventArgs e) {// Delete from db
            if (IsPostBack) {
                Response.Write("<center><h1>Delete record in the database by CustomerID</ h1 >");
                Response.Write("<br/>");
                String customerIDString = TextBox2.Text;

                string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);

                string sqlString = "delete from customers where CustomerID = @customerIDString";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                //to prevent sql injection
                cmd.Parameters.AddWithValue("@customerIDString", customerIDString);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                showAllFromCustomers();
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

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e) {
            String txtValue = DropDownList2.SelectedValue.ToString();
            Console.WriteLine(txtValue);
            hideAllElements();
            switch (txtValue) {
                case "Create":
                    Button2.Visible = true;
                    customerID.Visible = true;
                    companyName.Visible = true;
                    contactName.Visible = true;
                    contactTitle.Visible = true;
                    address.Visible = true;
                    city.Visible = true;
                    region.Visible = true;
                    postCode.Visible = true;
                    country.Visible = true;
                    phone.Visible = true;
                    fax.Visible = true;
                    break;
                case "Read":
                    TextBox1.Visible = true;
                    Button1.Visible = true;
                    DropDownList1.Visible = true;
                    break;
                case "Update":
                    Button3.Visible = true;
                    customerIDUpdate.Visible = true;
                    companyNameUpdate.Visible = true;
                    contactNameUpdate.Visible = true;
                    contactTitleUpdate.Visible = true;
                    addressUpdate.Visible = true;
                    cityUpdate.Visible = true;
                    regionUpdate.Visible = true;
                    postCodeUpdate.Visible = true;
                    countryUpdate.Visible = true;
                    phoneUpdate.Visible = true;
                    faxUpdate.Visible = true;
                    break;
                case "Delete":
                    Button4.Visible = true;
                    TextBox2.Visible = true;
                    break;
                default:
                    break;
            }
        }

        protected void showAllFromCustomers() {
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            string sqlString = "select * from customers";
            SqlCommand cmd = new SqlCommand(sqlString, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            con.Close();
        }

        protected void hideAllElements() {
            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;

            DropDownList1.Visible = false;

            TextBox1.Visible = false;
            TextBox2.Visible = false;

            customerID.Visible = false;
            companyName.Visible = false;
            contactName.Visible = false;
            contactTitle.Visible = false;
            address.Visible = false;
            city.Visible = false;
            region.Visible = false;
            postCode.Visible = false;
            country.Visible = false;
            phone.Visible = false;
            fax.Visible = false;
        }

        protected void addDataToDropdown() {
            DropDownList2.Items.Add("Create");
            DropDownList2.Items.Add("Read");
            DropDownList2.Items.Add("Update");
            DropDownList2.Items.Add("Delete");
        }
    }
}