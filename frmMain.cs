using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class frmMain : Form
    {
        Board board;
        Button[,] buttons;
        int size;
        int score;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            board = new Board();
            size = board.getSize();
            score = 0;

            displayBoard();
        }

        public void displayBoard()
        {
            //Get generated array
            String[,] gameBoard = new String[size, size];
            gameBoard = board.getBoard();

            //Create buttons
            buttons = new Button[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Name = gameBoard[i, j] + "";
                    buttons[i, j].Text = "";
                    buttons[i, j].Height = 200;
                    buttons[i, j].Width = 200;
                    buttons[i, j].Padding = new Padding(5);
                    buttons[i, j].BackColor = Color.DarkGray;

                    //Add a button click event handler
                    buttons[i, j].Click += new EventHandler(buttonClick);

                    //Add button to form
                    flowLayoutPanel1.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            //Game over if bomb is clicked
            if (clickedButton.Name.Equals("bomb"))
            {
                MessageBox.Show("Game Over");

                //Disable buttons
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        buttons[i, j].Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show(clickedButton.Name);

                //Update score

                //Reveal cells around clicked 
            }

        }

        private void updateScore()
        {

        }
    }
}
