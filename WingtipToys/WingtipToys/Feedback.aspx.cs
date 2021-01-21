using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys {
    public partial class Feedback : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                FillDropdown();
            }

        }

        protected void FeedbackSubmit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string productName = productDropdown.Text;
                int productID = -1; // assume product ID is smaller than anything in the db
                string s = ConfigurationManager.ConnectionStrings["WingTipToys"].ConnectionString; // database connection details
                SqlConnection con = new SqlConnection(s);
                string sqlString = "select ProductID from Products where ProductName=@productName";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                cmd.Parameters.AddWithValue("@productName", productName);
                con.Open(); // open connectiong
                SqlDataReader dr = cmd.ExecuteReader();
                System.Diagnostics.Debug.WriteLine(dr.ToString());
                if (dr.Read()) // reading the result of the sql query
                {
                    productID = dr.GetInt32(0);
                }
                dr.Close(); // close connection

                int FeedbackID = 0; // default feedbackID
                string sqlString2 = "select MAX(FeedbackID) from Feedback";
                SqlCommand cmd2 = new SqlCommand(sqlString2, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read()) // reading the result of the sql query
                {
                    FeedbackID = dr2.GetInt32(0);
                }
                dr2.Close();

                string sqlString3 = "insert into Feedback values(@feedbackID, @productID, @productName, @emailAddress, @feedback)";
                SqlCommand cmd3 = new SqlCommand(sqlString3, con);
                cmd3.Parameters.AddWithValue("@feedbackID", FeedbackID+1);
                cmd3.Parameters.AddWithValue("@productID", productID);
                cmd3.Parameters.AddWithValue("@productName", productName);
                cmd3.Parameters.AddWithValue("@emailAddress", emailAddress.Text); // Unsafe - not protected against SQL injection
                cmd3.Parameters.AddWithValue("@feedback", feedbackTextBox.Text);
                cmd3.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('Thank you for your feedback!')</script>"); // Confirmation of feedback



            }
        }

        protected void CategoryDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                productDropdown.Items.Clear();
                String txtValue = categoryDropdown.SelectedValue.ToString();
                string s = ConfigurationManager.ConnectionStrings["WingTipToys"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                int categoryID = StringtoID(txtValue);
                if(categoryID == 6)
                {
                    productDropdown.Items.Add("General Feedback");
                }
                System.Diagnostics.Debug.WriteLine("CAATEGORY ID: " + categoryID);
                string sqlString = "select ProductName from Products where CategoryID=@categoryID"; // sql string
                SqlCommand cmd = new SqlCommand(sqlString, con); //execute sql command
                cmd.Parameters.AddWithValue("@categoryID", categoryID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == true) // reading the results of the sql query
                {
                    productDropdown.Items.Add(dr["ProductName"].ToString());
                }
                dr.Close();
                con.Close();
            }
        }
        protected void FillDropdown() // Initial Page load - fill up the dropdown with options
        {
            categoryDropdown.Items.Add("Cars");
            categoryDropdown.Items.Add("Planes");
            categoryDropdown.Items.Add("Trucks");
            categoryDropdown.Items.Add("Ships");
            categoryDropdown.Items.Add("Rockets");
            categoryDropdown.Items.Add("General Feedback");

            productDropdown.Items.Add("Convertible Car");
            productDropdown.Items.Add("Old-time Car");
            productDropdown.Items.Add("Fast Car");
            productDropdown.Items.Add("Super Fast Car");
            productDropdown.Items.Add("Old Style Racer");
        }

        protected int StringtoID(string s) // helper method to choose which category to select
        {
            switch (s)
            {
                case "Cars":
                    return 1;
                case "Planes":
                    return 2;
                case "Trucks":
                    return 3;
                case "Ships":
                    return 4;
                case "Rockets":
                    return 5;
                case "General Feedback":
                default: // return 6 if the string doesnt match
                    return 6;
            } 
        }
    }
}