using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPS_Winform
{
    public partial class Form1 : Form
    {
        //Variables
        int rounds = 3;
        int timerPerRound = 6;
        bool gameOver = false;
        private string _userName;
        /// <summary>
        /// Array list to stores the choices, this has been stored with 
        /// the fields doubled to improve the random selection.
        /// </summary>
        string[] CPUchoiceList = { "rock", "paper", "scissor", "paper", "scissor", "rock" };

        //Random number is saved
        int randomNumber = 0;

        //Random number
        Random rnd = new Random();

        //Choices for both players
        string CPUChoice;
        string playerChoice;


        //Scores for both players
        int playerScore;
        int CPUScore;


        public Form1(string userName)
        {
            InitializeComponent();
            _userName = userName;
            countDownTimer.Enabled = true;

            playerChoice = "none";
            label1.Text = _userName;
            txtCountDown.Text = "5";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            playerChoice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            playerChoice = "scissor";
        }

        /// <summary>
        /// Button to reset the game to the preset state of zero 
        /// scores and set amount of rounds.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            CPUScore = 0;
            rounds = 3;
            txtScore.Text = "Player: " + _userName + " " + playerScore + " - " + " CPU: " + CPUScore;

            playerChoice = "None";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.question;
            picCPU.Image = Properties.Resources.question;

            gameOver = false;
        }

        /// <summary>
        /// Reducing the countdown timer, update the corrsonding lables,
        /// with the timer it then controls the round.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            txtCountDown.Text = timerPerRound.ToString();


            txtRounds.Text = "Rounds: " + rounds;

            if (timerPerRound < 1)
            {
                countDownTimer.Enabled = false;

                timerPerRound = 6;

                randomNumber = rnd.Next(0, CPUchoiceList.Length);

                CPUChoice = CPUchoiceList[randomNumber];

                switch (CPUChoice)
                {
                    case "rock":
                        picCPU.Image = Properties.Resources.rock;
                        break;

                    case "paper":
                        picCPU.Image = Properties.Resources.paper;
                        break;

                    case "scissor":
                        picCPU.Image = Properties.Resources.scissors;
                        break;
                }

                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if (playerScore > CPUScore)
                    {
                        MessageBox.Show("You Win");
                    }
                    else
                    {
                        MessageBox.Show("Computer wins");
                    }

                    gameOver = true;
                }
            }



        }

        /// <summary>
        /// Rules for the game to follow.
        /// </summary>
        private void checkGame()
        {
            ///CPU condidtions
            if (playerChoice == "rock" && CPUChoice == "paper")
            {
                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("Computer Wins, Paper Covers Rock!");
            }

            else if (playerChoice == "scissor" && CPUChoice == "rock")
            {
                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("Computer Wins, Rock Breaks Scissor!");
            }

            else if (playerChoice == "paper" && CPUChoice == "scissor")
            {
                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("Computer Wins, Scissor Cuts Paper!");
            }
            ///Player win condition

            else if (playerChoice == "rock" && CPUChoice == "scissor")
            {
                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Rock Breaks Scissor !");
            }

            else if (playerChoice == "paper" && CPUChoice == "rock")
            {
                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Paper Covers Rock!");
            }

            else if (playerChoice == "scissor" && CPUChoice == "paper")
            {
                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Scissors Cuts Paper!");
            }

            else if (playerChoice == "none")
            {
                MessageBox.Show("Please Make a Choice");
            }
            else
            {
                MessageBox.Show("Game is a Draw!");
            }

            startNextRound();
        }

        /// <summary>
        /// Method to start the next round, updating the 
        /// scores and reseting the images.
        /// </summary>
        private void startNextRound()
        {
            if (gameOver == true)
            {
                return;
            }

            txtScore.Text = "Player: " + _userName + " " + playerScore + " - " + " CPU: " + CPUScore;

            playerChoice = "None";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.question;
            picCPU.Image = Properties.Resources.question;
        }
    }
}