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
        int[,] gameBoard;
        Button[,] buttons;
        int SIZE;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            board = new Board();
            SIZE = board.getBoardSize();

            displayBoard();
        }

        public void displayBoard()
        {
            //Get generated array
            gameBoard = new int[SIZE+2, SIZE+2];
            gameBoard = board.getBoard();

            //Create buttons
            buttons = new Button[SIZE, SIZE];

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Name = i + " " + j;
                    buttons[i, j].Text = "";
                    buttons[i, j].Height = 130;
                    buttons[i, j].Width = 130;
                    buttons[i, j].Padding = new Padding(5);
                    if (buttons[i, j].Text == "-1") buttons[i, j].BackColor = Color.Blue;
                    else buttons[i, j].BackColor = Color.DarkGray;

                    //Add a button click event handler
                    buttons[i, j].Click += new EventHandler(ButtonClick);
                  
                    //Add button to form
                    flowLayoutPanel1.Controls.Add(buttons[i, j]);
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

            int value = board.getCellValue(x,y);

            //Game over if bomb is clicked - game over
            if(value == -1)
            {
                MessageBox.Show("Game Over");

                //Disable buttons
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        buttons[i, j].Enabled = false;
                    }
                }
            }
            else if(!board.isRevealed(temp[0], temp[1]))
            {
                //Reveal cell
                board.setRevealed(temp[0], temp[1]);
                buttons[x, y].BackColor = Color.Pink;
                buttons[x, y].Text = board.getNeighbors(x, y) + "";
            }
            else
            {
                MessageBox.Show("nothing");
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
