using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndrianAlexanderPutraCodingTest
{
    public partial class frmShoppingCart : Form
    {
        public frmShoppingCart()
        {
            InitializeComponent();
        }
        public static void connectionDB() //sql connection from database 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DOKU (Hiring Test)\AndrianAlexanderPutraCodingTest\AndrianAlexanderPutraCodingTest\CalPayDB.mdf";
            con.Open();
        }
        public static DiscountCoupon getKodePromo(string name) //to get the promocode from database
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DOKU (Hiring Test)\AndrianAlexanderPutraCodingTest\AndrianAlexanderPutraCodingTest\CalPayDB.mdf";
            SqlCommand cmd = new SqlCommand("Select * from DiscountCoupon where name = @name", con); //sql query
            cmd.Parameters.AddWithValue("@name", name);
            DiscountCoupon d = null;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string percent;
            if (reader.Read())
            {
                //to check if the percentage is null or not
                if (reader["Percentage"].ToString() == DBNull.Value.ToString())
                    percent = null;
                else
                    percent = reader["Percentage"].ToString();

                d = new DiscountCoupon(Convert.ToInt32(reader["PromoCode"]),
                                    reader["Name"].ToString(),
                                    Convert.ToDouble(percent));
            }
            reader.Close();
            con.Close();
            return d;
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double amount = Convert.ToDouble(tbxAmount.Text); //to get the amount from user and convert it into double
                DiscountCoupon dc = getKodePromo(tbxKodePromo.Text); //get the promo code from database
                if (dc != null) //to check if the promo code is not null
                {
                    double netAmount = amount - (amount * Convert.ToDouble(dc.Percentage)); //to calculate the net amount from percentage
                    tbxOutput.AppendText("Discount: " + dc.Percentage * 100 + "%" + Environment.NewLine + "Amount yang harus dibayar: " + netAmount + Environment.NewLine); //to show the output
                }
                else
                {
                    double netAmount = amount;
                    tbxOutput.AppendText("Discount: " + 0 * 100 + "% (tidak ada promo code)" + Environment.NewLine + "Amount yang harus dibayar: " + netAmount + Environment.NewLine); //to show the output

                }
            }
            catch (Exception ex)
            {
                tbxOutput.AppendText("Invalid Input!" + Environment.NewLine);
            }
        }
    }
}
