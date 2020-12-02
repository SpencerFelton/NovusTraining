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
                fillDropdown();
            }

        }

        protected void feedbackSubmit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string productName = productDropdown.Text;
                int productID = -1;
                string s = ConfigurationManager.ConnectionStrings["WingTipToys"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                string sqlString = "select ProductID from Products where ProductName=@productName";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                cmd.Parameters.AddWithValue("@productName", productName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                System.Diagnostics.Debug.WriteLine(dr.ToString());
                if (dr.Read())
                {
                    productID = dr.GetInt32(0);
                }
                dr.Close();

                int FeedbackID = 0;
                string sqlString2 = "select MAX(FeedbackID) from Feedback";
                SqlCommand cmd2 = new SqlCommand(sqlString2, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
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


            }
        }

        protected void categoryDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                productDropdown.Items.Clear();
                String txtValue = categoryDropdown.SelectedValue.ToString();
                string s = ConfigurationManager.ConnectionStrings["WingTipToys"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                int categoryID = stringtoID(txtValue);
                if(categoryID == 6)
                {
                    productDropdown.Items.Add("General Feedback");
                }
                System.Diagnostics.Debug.WriteLine("CAATEGORY ID: " + categoryID);
                string sqlString = "select ProductName from Products where CategoryID=@categoryID";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                cmd.Parameters.AddWithValue("@categoryID", categoryID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    productDropdown.Items.Add(dr["ProductName"].ToString());
                }
                dr.Close();
                con.Close();
            }
        }
        protected void fillDropdown() // Initial Page load
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

        protected int stringtoID(string s)
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
                default:
                    return 6;
            } 
        }
    }
}