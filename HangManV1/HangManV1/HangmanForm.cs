using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Collections.Generic;
using System.IO;

namespace HangManV1
{
    public partial class HangmanForm : Form
    {
        
        public HangmanForm()
        {
            InitializeComponent();
        }
        
        int errorCount = 0;
        Label coveredWord = new Label();
        Label word = new Label();
        Label errors = new Label();
        Panel btnPanel = new Panel();
        PictureBox pBox = new PictureBox();
        string loesungsWort = "beispielsweise";

        StringBuilder verdecktesWort = new StringBuilder();
        public void GenerateGame()
        {

            errors.Text = "Fehler: " + errorCount + "/ 10";
            errors.Location = new Point(30, 159);
            errors.Font = new Font("Arial", 10, FontStyle.Bold);

            coveredWord.Location = new Point(130, 129);
            coveredWord.Size = new Size(300, 100);
            coveredWord.Font = new Font("Arial", 10, FontStyle.Bold);

            word.Text = "Gesucht: ";
            word.Location = new Point(30, 129);
            word.Font = new Font("Arial", 12, FontStyle.Bold);

            btnPanel.Location = new Point(0, 200);
            btnPanel.Size = new Size(500, 400);

            pBox.Image = Image.FromFile(@"../../Resources/0.png");


            Button[] btnArray = new Button[26];
            String[] btnChar = new String[26];

            for (int i = 0, x = 0, y = 0; i < 26; i++, x++)
            {
                if (i % 10 == 0)
                {
                    y++;
                    x = 0;
                }

                btnArray[i] = new Button();
                btnArray[i].Visible = true;
                btnArray[i].Location = new System.Drawing.Point(16 + x * 30, 80 + y * 27);
                btnArray[i].Size = new System.Drawing.Size(27, 27);
                btnArray[i].TabIndex = i + 4;
                btnArray[i].Text = ((char)(i + 97)).ToString();
                btnArray[i].Name = "Button" + btnArray[i].Text;
                btnArray[i].UseVisualStyleBackColor = true;
                btnArray[i].Click += new System.EventHandler(buttonClick);
                btnPanel.Controls.Add(btnArray[i]);
            }
            //Click-Event for each Button
            void buttonClick(object sender, EventArgs e)
            {
                Button button = sender as Button;
                int charIndex = loesungsWort.IndexOf(button.Text);
                if (charIndex != -1)
                {
                    verdecktesWort[charIndex] = button.Text[0];
                    coveredWord.Text = string.Join(" ", verdecktesWort);

                    if (verdecktesWort.ToString() == loesungsWort)
                    {
                        DialogResult result = MessageBox.Show("Du hast diese Runde gewonnen!\n Möchtest du eine neue Runde starten?", 
                            "Der Kopf bleibt dran!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            errorCount = 0;
                            GenerateGame();
                        }
                        else
                        {
                            Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Buchstabe nicht vorhanden");
                    errorCount++;
                    checkErrors(errorCount);
                    
                }
                
            }
            Controls.Add(pBox);
            Controls.Add(word);
            Controls.Add(btnPanel);
            Controls.Add(coveredWord);
            Controls.Add(errors);
        }
        public void checkErrors(int errorCounter)
        {
            errors.Text = "Fehler: " + errorCounter + "/ 10";
            if (errorCounter < 10)
            {
                pBox.Load(@"../../Resources/" + errorCounter + ".png");
                pBox.Refresh();
                errors.Text = "Fehler: " + errorCounter + "/ 10";
            }
            else
            {
                DialogResult result = MessageBox.Show("Du hast diese Runde verloren!\n Möchtest du eine neue Runde starten?", 
                    "Der Kopf ist ab!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    errorCount = 0;
                    GenerateGame();
                }
                else
                {
                    Close();
                }
            }
        }
    }
}