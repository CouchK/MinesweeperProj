﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class frmMain : Form
    {
        Board board;
        Button[,] buttons;
        int SIZE;
        int seconds, minutes;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            board = new Board();
            SIZE = board.GetBoardSize();
            seconds = 0; 
            minutes = 0;

            //Set smiley face
            btnStart.BackgroundImage = Minesweeper.Properties.Resources.happy;

            //Create game board
            DisplayBoard();

            //Start timer
            gameTimer.Start();
        }

        public void DisplayBoard()
        {
            //Create buttons
            buttons = new Button[SIZE, SIZE];

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Name = (i+1) + " " + (j+1);
                    buttons[i, j].Height = 120;
                    buttons[i, j].Width = 120;
                    buttons[i, j].Padding = new Padding(5);
                    buttons[i, j].BackColor = Color.DarkGray;
                    buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    //Add a button click event handler
                    buttons[i, j].Click += new EventHandler(ButtonClick);
                  
                    //Add button to form
                    gameGrid.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string position = clickedButton.Name.Substring(0);

            string[] temp = position.Split(" ");
            int x = int.Parse(temp[0]);
            int y = int.Parse(temp[1]);

            bool bombCheck = board.isBomb(x,y);

            //Game over if bomb is clicked - game over
            if(bombCheck)
            {
                //Stop Timer
                gameTimer.Stop();

                //Disable buttons and reveal all bombs
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        buttons[i, j].Enabled = false;

                        if (board.isBomb(i + 1, j + 1)) buttons[i, j].BackgroundImage = Minesweeper.Properties.Resources.bomb;
                    }
                }

                //Change icon to dead smiley
                btnStart.BackgroundImage = Minesweeper.Properties.Resources.dead;

                MessageBox.Show("Game Over!");
            }
            else if(!board.IsRevealed(x, y))
            {
                //Reveal cell
                board.SetRevealed(x, y);
                int neighbors = board.GetNeighbors(x, y);

                //Set cell text colors by amount of neighbors
                if (neighbors == 1) buttons[x-1, y-1].ForeColor = Color.Blue;
                else if (neighbors == 2) buttons[x-1, y-1].ForeColor = Color.Green;
                else if (neighbors == 3) buttons[x-1, y-1].ForeColor = Color.Red;
                else if (neighbors == 4) buttons[x-1, y-1].ForeColor = Color.Navy;
                else if (neighbors == 5) buttons[x-1, y-1].ForeColor = Color.DarkRed;
                buttons[x-1, y-1].Font = new Font(buttons[x-1, y-1].Font, FontStyle.Bold);

                //Set background color of selected cell
                buttons[x-1, y-1].BackColor = Color.LightGray;

                //Display number of neighbors
                if (neighbors == 0) buttons[x-1, y-1].Text = " ";
                else buttons[x-1, y-1].Text = neighbors + "";
            }
            else { }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Restart game
            Process.Start("Minesweeper");
            Process[] procs = Process.GetProcessesByName("B");

            foreach (Process proc in procs)
                proc.Kill();

            Environment.Exit(-1);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Increment timer
            seconds++;
            if(seconds == 60)
            {
                seconds = 0;
                minutes += 1;
            }
            lblTimer.Text = string.Format("{0}:{1}", minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));
        }
    }
}
