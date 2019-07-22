using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace HangManV1
{
    public partial class HangManFormV1 : Form
    {
        private SQLiteCommand liteCommand = new SQLiteCommand();
        private const string pfad = @"../../Resources/wortliste.txt";
        private int errorCount;
        public static bool gameRunning = false;
        public string userNameLabel = LoginForm.userName;
        private string randWord;
        private string randWordCovered;
        public List<Button> ButtonListForPanel = new List<Button>();
        public HangManFormV1()
        {
            InitializeComponent();
            lblCurrentLogin.Text = "Current Login: " + userNameLabel;
            NewGame();
            gameRunning = true;
            generateButtonsForPanel();
            this.Controls.Add(panelForButtons);
        }
        public void NewGame()
        {
            generateNewWord();
            errorCount = 0;
            pbErrorImages.Image = Image.FromFile(@"../../Resources/0.png");
        }
        public void generateButtonsForPanel()
        {
            int horz = 0;
            int vert = 0;
            for (int i = 0; i < 26; i++)
            {
                ButtonListForPanel.Add(new Button());
                ButtonListForPanel[i] = new Button();
                ButtonListForPanel[i].Visible = true;
                ButtonListForPanel[i].Location = new Point(4 + horz, 4 + vert);
                ButtonListForPanel[i].Size = new Size(24, 24);
                if ((i + 1) % 12 != 0)
                { horz += 30; }
                else { horz = 0; vert += 30; }
                ButtonListForPanel[i].TabIndex = i + 3;
                ButtonListForPanel[i].Text = ((char)(i + 97)).ToString().ToUpper(); ;
                ButtonListForPanel[i].Name = "Button" + ButtonListForPanel[i].Text;
                ButtonListForPanel[i].UseVisualStyleBackColor = true;
                ButtonListForPanel[i].BringToFront();
                ButtonListForPanel[i].Click += new System.EventHandler(this.button_Click);
                panelForButtons.Controls.Add(ButtonListForPanel[i]);
            }

        }
        
        private void button_Click(object sender, EventArgs e)
        {
            //Wenn der Wert des Buttons innerhalb vom lwort vorkommt, replace (index, "_ ", button.Text
            if (sender != null)
            {
                Button button = sender as Button;
                char guessChar = button.Text[0];
                if (randWord.Contains(guessChar.ToString()))
                {
                    char[] temp = randWordCovered.ToCharArray();
                    char[] find = randWord.ToCharArray();
                    
                    for(int i = 0; i < randWord.Length; i++)
                    {
                        if (find[i] == guessChar)
                        {
                            temp[i] = guessChar;
                        }
                    }
                    randWordCovered = new string(temp);
                    displayCoveredWord();
                    if(randWord == randWordCovered)
                    {
                        userWin();
                        DialogResult result = MessageBox.Show("Du hast diese Runde gewonnen!\n Möchtest du eine neue Runde starten?",
                            "Der Kopf bleibt dran!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            lblCoveredWord.Text = "";
                            NewGame();
                        }
                        else
                        {
                            gameRunning = false;
                            Close();
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("Buchstabe nicht vorhanden");
                    errorCount++;
                    if (errorCount >= 10)
                    {
                        userLose();
                        DialogResult result = MessageBox.Show("Du hast diese Runde verloren!\n Möchtest du eine neue Runde starten?",
                            "Der Kopf ist ab!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            errorCount = 0;
                            lblCoveredWord.Text = "";
                            NewGame();
                        }
                        else
                        {
                            gameRunning = false;
                            Close();
                        }
                    }
                    pbErrorImages.Load(@"../../Resources/" + errorCount + ".png");
                    pbErrorImages.Refresh();
                    lblErrorCount.Text = "Error Count: " + errorCount + "/ 10";
                }
            }
        }

        private void generateNewWord()
        {
            List<string> newWords = new List<string>();
            Random randomNumber = new Random();
            string[] replaceChars = new string[] {"Ä", "Ö", "Ü" };
            string[] replaceCharsWith = new string[] { "AE", "OE", "UE" };
            if (newWords.Count < 1)
            {
                if (File.Exists(pfad))
                {
                    try
                    {
                        using (StreamReader dateiStream = File.OpenText(pfad))
                        {
                            string input;
                            while ((input = dateiStream.ReadLine()) != null)
                            {
                                input = input.ToUpper();
                                newWords.Add(input);
                            }
                            dateiStream.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The file could not be read: ", e.Message);
                    }
                }
                for (int i = 0; i < replaceChars.Length; i++)
                {
                    newWords[i].Replace(replaceChars[i], replaceCharsWith[i]);
                }
                randWord = newWords[randomNumber.Next(newWords.Count)];
                randWord = randWord.ToUpper();
                randWordCovered = "";
                errorCount = 0;
                for (int i = 0; i < randWord.Length; i++)
                {
                    randWordCovered += "_";
                }
                displayCoveredWord();
                lblErrorCount.Text = "Error Count: " + errorCount + "/ 10";
                lblSolveWord.Text = "Solve" + "(" + randWord.Length + ")";
                
            }
        }

        private void displayCoveredWord()
        {
            lblCoveredWord.Text = "";
            for (int i = 0; i < randWordCovered.Length; i++)
            {
                lblCoveredWord.Text += randWordCovered.Substring(i, 1);
                lblCoveredWord.Text += " ";
            }
        }
        //Menu-Stipe-Methods
        private void tSNewHsDB_Click(object sender, EventArgs e)
        {
            SqlCommands comm = new SqlCommands();
            comm.deleteDataBase();
        }

        private void tSHighscoreList_Click(object sender, EventArgs e)
        {
            Form HighscoreForm = new Form();
            HighscoreForm.Size = new Size(550, 150);
            DataGridView highscoreGrid = new DataGridView();
            highscoreGrid.Size = new Size(HighscoreForm.Width, HighscoreForm.Height);
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + SqlCommands.dataSource))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM User", connection);

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter();
                dataAdapter.SelectCommand = command;
                DataTable highscoreTable = new DataTable();
                dataAdapter.Fill(highscoreTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = highscoreTable;
                highscoreGrid.DataSource = bSource;
                dataAdapter.Update(highscoreTable);

                HighscoreForm.Controls.Add(highscoreGrid);
                command.Dispose();

            }
            HighscoreForm.Show();
        }

        private void tSNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void userWin()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + SqlCommands.dataSource))
            {
                SQLiteCommand command = new SQLiteCommand("UPDATE User SET win = win +1 WHERE name = '"+ userNameLabel +"'",
                    connection);

                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }
        private void userLose()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + SqlCommands.dataSource))
            {
                SQLiteCommand command = new SQLiteCommand("UPDATE User SET lose = lose +1 WHERE name = '" + userNameLabel + "'",
                    connection);

                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }
        private void tSNewUser_Click(object sender, EventArgs e)
        {
            LoginForm.UserSuccessfullyAuthenticated = false;
            Close();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameRunning = false;
            Close();
        }
        private void HangManFormV1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameRunning = false;
        }
    }
}
