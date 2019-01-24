using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp6
{
    public partial class LoginForm : Form
    {


        private string receivedConnectionString = "";
        private bool LoggedIn = false;
        private Form1 ParentForm;
        private bool RegisterButtonPressed = false;
        public LoginForm(string _connectionString, Form1 _parentForm)
        {
            InitializeComponent();
            this.ParentForm = _parentForm;
            receivedConnectionString = _connectionString;
            if(WindowsFormsApp6.Properties.Settings.Default.chkRememberIsChecked)
            {
                chkRemember.Checked = true;
                txtUsername.Text = WindowsFormsApp6.Properties.Settings.Default.Username;
                txtPassword.Text = WindowsFormsApp6.Properties.Settings.Default.Password;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection _connection = new MySqlConnection(receivedConnectionString);
            _connection.Open();
            if(_connection.State == ConnectionState.Open)
            {
                string sql_string = string.Format("SELECT * FROM users WHERE `Username`=\"{0}\" and `Password`=\"{1}\"", txtUsername.Text, txtPassword.Text);
                MySqlCommand command = new MySqlCommand(sql_string, _connection);
                MySqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bool dbAdmin = bool.Parse(reader["Admin"].ToString());
                        LoggedIn = true;
                        if(chkRemember.Checked == true)
                        {
                            WindowsFormsApp6.Properties.Settings.Default.chkRememberIsChecked = true;
                            WindowsFormsApp6.Properties.Settings.Default.Password = txtPassword.Text;
                            WindowsFormsApp6.Properties.Settings.Default.Username = txtUsername.Text;
                            WindowsFormsApp6.Properties.Settings.Default.Save();
                        }
                        this.ParentForm.Show();
                        this.Close();
                    }
                }
                else
                {
                    LoggedIn = false;
                    MessageBox.Show("Invalid username or password!", "Invalid fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _connection.Close();    
            }

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoggedIn)
            {
                this.Hide();
            }
            else
            {
                Application.Exit();
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtRegisterPassword.Text == txtRegisterConfirmPassword.Text)
            {
                MySqlConnection _connection = new MySqlConnection(receivedConnectionString);
                _connection.Open();

                if (_connection.State == ConnectionState.Open)
                {
                    #region Check if an user with the specified username/email already exist
                    string sql_string = string.Format("SELECT * FROM users WHERE `Username`=\"{0}\" OR `Email`=\"{1}\"", txtRegisterUsername.Text, txtRegisterEmail.Text);
                    MySqlCommand _command = new MySqlCommand(sql_string, _connection);
                    MySqlDataReader reader = _command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _connection.Close();
                        MessageBox.Show("An user already exists with the specified details (username/password)");
                        txtRegisterUsername.Clear();
                        txtRegisterEmail.Clear();
                        return;
                    }
                    #endregion
                    reader.Close();

                    #region Create new account if username/email account does not exist already
                    sql_string = string.Format("INSERT INTO users VALUES(null, \"{0}\", \"{1}\", \"{2}\", 0)", txtRegisterUsername.Text, txtRegisterPassword.Text, txtRegisterEmail.Text);
                    _command = new MySqlCommand(sql_string, _connection);
                    _command.ExecuteNonQuery();
                    #endregion

                    WindowsFormsApp6.Properties.Settings.Default.Password = txtRegisterPassword.Text;
                    WindowsFormsApp6.Properties.Settings.Default.Username = txtRegisterUsername.Text;
                    WindowsFormsApp6.Properties.Settings.Default.Save();

                    MessageBox.Show("Account created successfully!");
                    _connection.Close();
                    LoggedIn = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("\"Password\" field is not the same as \"Confirm password\" field", "Cannot continue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
        }

    }
}
