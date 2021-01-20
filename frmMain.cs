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
            size = board.getBoardSize();
            score = 0;

            displayBoard();
        }

        public void displayBoard()
        {
            //Get generated array
            int[,] gameBoard = new int[size, size];
            gameBoard = board.getBoard();

            //Create buttons
            buttons = new Button[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Name = i + "" + j;
                    buttons[i, j].Text = gameBoard[i, j] + ""; 
                    buttons[i, j].Height = 130;
                    buttons[i, j].Width = 130;
                    buttons[i, j].Padding = new Padding(5);
                    if (buttons[i, j].Text == "-1") buttons[i, j].BackColor = Color.Blue;
                    else buttons[i, j].BackColor = Color.DarkGray;

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
            if (clickedButton.Name.Equals(5))
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
                //MessageBox.Show(clickedButton.Name);

                //Check if cell is revealed
                int row = Int32.Parse(clickedButton.Name.Substring(0));
                int col = Int32.Parse(clickedButton.Name.Substring(1));
                MessageBox.Show(row + " " + col);

                //Update score

                //Reveal cells around clicked 
            }

        }

        private void updateScore()
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
