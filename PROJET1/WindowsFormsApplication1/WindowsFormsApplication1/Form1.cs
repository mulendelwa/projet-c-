using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        SqlConnection sqlConnection;
        MySqlConnection mySqlConnection;
        OdbcConnection progressConnection;
        string selectedConnection;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("SQL Server");
            comboBox1.Items.Add("MySQL");
            comboBox1.Items.Add("Progress");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Remplir la ComboBox avec les options de connexion
            
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            String noms = nom.Text;
            String postnoms = postnom.Text;
            String matricules = matricule.Text;
            String adresss = adresse.Text;




            string connectionString = "";
            switch (selectedConnection)
            {
                case "SQL Server":
                    connectionString = @"Data Source=DESTIN\DESTIN;Initial Catalog=etudi;Integrated Security=True";
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();

                    // Insertion des informations des étudiants
                    SqlCommand cmd = new SqlCommand("INSERT INTO etudi (nom, postnom, matricule, adresse) VALUES (@noms, @postnoms, @matricules, @adress )", sqlConnection);
                    cmd.Parameters.AddWithValue("@noms", noms);
                    cmd.Parameters.AddWithValue("@postnoms", postnoms);
                    cmd.Parameters.AddWithValue("@matricules", matricules);
                    cmd.Parameters.AddWithValue("@adress", adresss);
                    cmd.ExecuteNonQuery();

                    sqlConnection.Close();
                    MessageBox.Show("est inserer avec succes Sur SQL server");
                    break;
                case "MySQL":
                    connectionString = "server=localhost;user id=root;password=  ;database= etudi";
                    mySqlConnection = new MySqlConnection(connectionString);
                    mySqlConnection.Open();

                    // Insertion des informations des étudiants
                    MySqlCommand myCmd = new MySqlCommand("INSERT INTO etudi (nom, postnom, matricule, adresse) VALUES (@noms, @postnoms, @matricules, @adress )", mySqlConnection);
                    myCmd.Parameters.AddWithValue("@noms", noms);
                    myCmd.Parameters.AddWithValue("@postnoms", postnoms);
                    myCmd.Parameters.AddWithValue("@matricules", matricules);
                    myCmd.Parameters.AddWithValue("@adress", adresss);
                    myCmd.ExecuteNonQuery();

                    mySqlConnection.Close();
                    MessageBox.Show("est inserer avec succes Sur MySQL");
                    break;
                case "Progress":
                    connectionString = "Driver={Progress OpenEdge 11.7 Driver};Dsn=DSNName;Uid=UserName;Pwd=Password;";
                    progressConnection = new OdbcConnection(connectionString);
                    progressConnection.Open();

                    // Insertion des informations des étudiants
                    OdbcCommand progressCmd = new OdbcCommand("INSERT INTO Etudiants (Nom, Prenom) VALUES ('John', 'Doe')", progressConnection);
                    progressCmd.ExecuteNonQuery();

                    progressConnection.Close();
                    break;
                default:
                    MessageBox.Show("Veuillez sélectionner une base de données");
                    break;
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedConnection = comboBox1.SelectedItem.ToString();
        }
    }
}
