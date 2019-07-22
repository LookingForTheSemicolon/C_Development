﻿using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HangManV1
{
    public partial class LoginForm : Form
    {
        private static string _userName;
        public static string userName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                if (_userName != "")
                {
                    _userName = "";
                    _userName = value;
                }
            }
        }
        public static bool UserSuccessfullyAuthenticated;
        public LoginForm()
        {
            InitializeComponent();
            fillCombobox();
        }

        void BtnLogin_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + SqlCommands.dataSource))
            {
                SQLiteCommand command = new SQLiteCommand("Select * FROM User WHERE name = '" + comboBoxUsers.Text + "' AND password ='" + txtBoxPassword.Text + "' ", connection);
                
                try
                {
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        userName = getUser();
                        UserSuccessfullyAuthenticated = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Passwort stimmt nicht mit dem User überein");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            
        }
        string getUser()
        {
            userName = "";
            return userName = comboBoxUsers.Text;
        }
        void fillCombobox()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + SqlCommands.dataSource))
            {
                try { 
                    SQLiteCommand command = new SQLiteCommand("Select * FROM User", connection);
                    SQLiteDataReader reader;
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader.GetString(1);
                        comboBoxUsers.Items.Add(name);
                    }
                }catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        void BtnNewUser_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + SqlCommands.dataSource))
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO User (id, name, password, win, lose) VALUES (NULL, '" + comboBoxUsers.Text + "', '" + txtBoxPassword.Text + "', 0, 0)",
                    connection);

                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
            }
            comboBoxUsers.Items.Add(comboBoxUsers.Text);
        }
    }
}
