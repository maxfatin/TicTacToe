using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class StartWindow : Form
    {
        bool turn = true; //true = X turn, false = Y turn
        int turn_count = 0;
        int winner1 = 0;
        int winner2 = 0;

        public StartWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            playerTurn();
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;
            winnerCheck();
        }

        private void winnerCheck()
        {
            
            bool got_a_winner = false;
            //horizontal checks
            if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled))
                got_a_winner = true;
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
                got_a_winner = true;
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled))
                got_a_winner = true;
            //vertical checks
            else if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
                got_a_winner = true;
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
                got_a_winner = true;
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
                got_a_winner = true;
            //diagonal checks
            else if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
                got_a_winner = true;
            else if ((c1.Text == b2.Text) && (b2.Text == a3.Text) && (!c1.Enabled))
                got_a_winner = true;

            if (got_a_winner)
            {
                disableButtons();
                String winner = "";
                
                if (turn)
                {
                    winner = "Player2";
                    winner2++;
                    lblPlayer2Score.Text = winner2.ToString();
                    lblPlayerTurn.Text = "Player 2 wins!";

                }
                else
                {
                    winner = "Player1";
                    winner1++;
                    lblPlayer1Score.Text = winner1.ToString();
                    lblPlayerTurn.Text = "Player 1 wins!";
                }
                MessageBox.Show(winner + " wins!","Congratulations!");
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("It's a draw!", "Tough game!");
            }
        }

        private void disableButtons()
        {
            a1.Enabled = false;
            b1.Enabled = false;
            c1.Enabled = false;
            a2.Enabled = false;
            b2.Enabled = false;
            c2.Enabled = false;
            a3.Enabled = false;
            b3.Enabled = false;
            c3.Enabled = false;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            a1.Enabled = true;
            a1.Text = "";
            b1.Enabled = true;
            b1.Text = "";
            c1.Enabled = true;
            c1.Text = "";
            a2.Enabled = true;
            a2.Text = "";
            b2.Enabled = true;
            b2.Text = "";
            c2.Enabled = true;
            c2.Text = "";
            a3.Enabled = true;
            a3.Text = "";
            b3.Enabled = true;
            b3.Text = "";
            c3.Enabled = true;
            c3.Text = "";
        }

        private void playerTurn()
        {
            if (turn == true)
                lblPlayerTurn.Text = "Player 2 turn";
            else
                lblPlayerTurn.Text = "Player 1 turn";
        }


    }
        
}
