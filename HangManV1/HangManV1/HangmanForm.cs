using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace HangManV1
{
    public partial class HangmanForm : Form
    {
        public HangmanForm()
        {
            InitializeComponent();
        }
        int errorCount = 0;


        private void btnStart_Click(object sender, EventArgs e)
        {
            GenerateGame();
        }
        public void GenerateGame()
        {
            int hor = 30;
            int ver = 30;
            Button[] btnArray = new Button[26];
            String[] btnChar = new String[26];
            string loesungsWort = "numerisch";

            StringBuilder verdecktesWort = new StringBuilder(loesungsWort);

            for (int i = 0; i < verdecktesWort.Length; i++)
            {
                verdecktesWort[i] = '_';
            }

            Label coveredWord = new Label();
            coveredWord.Location = new Point(130, 129);
            coveredWord.Size = new Size(300, 100);
            coveredWord.Text = string.Join(" ", verdecktesWort);

            Label word = new Label();
            word.Text = "Gesucht wird: ";
            word.Location = new Point(30, 129);

            Panel btnPanel = new Panel();
            btnPanel.Location = new Point(0, 330);
            btnPanel.Size = new Size(500, 400);

            PictureBox pBox = new PictureBox();
            pBox.Location = new Point(550, 100);
            pBox.Image = Image.FromFile("C:/Users/Dennis/source/repos/Test/Test/Resources/" + errorCount + ".png");
            pBox.Size = new Size(400, 400);

            Controls.Add(pBox);
            Controls.Add(word);
            Controls.Add(btnPanel);
            Controls.Add(coveredWord);

            #region 25 characters
            for (int i = 0, c = 97; i < btnChar.Length; i++)
            {
                char ascii = (char)c;
                btnChar[i] = ascii.ToString();
                c++;
            }
            #endregion
            #region 26Buttonsa-z
            for (int i = 0; i < btnArray.Length; i++)
            {
                btnArray[i] = new Button();
                btnArray[i].Size = new Size(30, 30);
                btnArray[i].Location = new Point(hor, ver);
                btnArray[i].Click += new EventHandler(buttonClick);
                if ((i + 1) % 13 != 0) { hor += 30; }
                else { hor = 30; ver += 30; }
                btnArray[i].Text = btnChar[i];
                btnArray[i].Name = btnChar[i];
                btnPanel.Controls.Add(btnArray[i]);
            }
            #endregion 26Buttonsa-z
            //Click-Event for each Button
            void buttonClick(object sender, EventArgs e)
            {
                Button button = sender as Button;
                int charIndex = loesungsWort.IndexOf(button.Text);
                if (charIndex != -1)
                {
                    verdecktesWort[charIndex] = button.Text[0];
                    //button.Visible = !button.Visible;
                }
                else
                {
                    MessageBox.Show("Buchstabe nicht vorhanden");
                    errorCount++;

                    pBox.Load("C:/Users/Dennis/source/repos/Test/Test/Resources/" + errorCount + ".png");
                    pBox.Refresh();
                    return;
                }


                coveredWord.Text = string.Join(" ", verdecktesWort);
            }


        }

        private void Hangman_Load(object sender, EventArgs e)
        {

        }
    }
}