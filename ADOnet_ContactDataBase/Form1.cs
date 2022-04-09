using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADOnet_ContactDataBase
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        DataSet dataSet = null;
        string path = @"Server=DESKTOP-440KLQF\SQLEXPRESS;Database=ContactDataBase;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
            Update();

        }

        private void UserInsert(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                SqlConnection conn = new SqlConnection(path);
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(@"INSERT INTO [User](FirstName, SurName, LastName, BirthDay, PhoneNumber, AddedData) VALUES (@FirstName, @SecondName, @LastName, @Birthday, @PhoneNumber, @AddedData)", conn);
                    command.Parameters.AddWithValue("FirstName", textBox1.Text);
                    command.Parameters.AddWithValue("SecondName", textBox2.Text);
                    command.Parameters.AddWithValue("LastName", textBox3.Text);
                    command.Parameters.AddWithValue("Birthday", textBox4.Text);
                    command.Parameters.AddWithValue("PhoneNumber", textBox5.Text);
                    command.Parameters.AddWithValue("AddedData", textBox6.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Inserted in Database");
                    FieldsClear();
                }
                catch (Exception)
                {
                    conn.Close();
                    Update();
                }
            }
        }


        private void ShowAll(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=DESKTOP-440KLQF\SQLEXPRESS;Database=ContactDataBase;Trusted_Connection=True;");
            conn.Open();
            string command = "Select * from[User];";
            SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0].DefaultView;
        }
        private void UserUpdate(object sender, EventArgs e)
        {
            Update();
        }
        private void Update()
        {
            SqlConnection conn = new SqlConnection(path);
            try
            {
                conn.Open();
                string command = "Select * from[User];";
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                //dataGridView1.DataSource = dataSet.Tables[0].DefaultView;
            }
            finally
            {
                conn.Close();
            }
        }

        private void FieldsClear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
            
