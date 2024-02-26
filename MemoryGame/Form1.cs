
namespace MemoryGame
{

    public partial class Form1 : Form
    {
        int playerOnePoints = 0;
        int playerTwoPoints = 0;
        bool isGameStarted = false;
        bool isPlayerOneTurn = false;
        bool isPlayerTwoTurn = false;
        bool isFirstPressed = false;
        bool isSecondPressed = false;
        PictureBox firstPressedPictureBox = new PictureBox();
        PictureBox secondPressedPictureBox = new PictureBox();
        static string icon = "";
        static Random rnd = new Random();
        static EnWords enWords;
        int mainCountdown = 5;
        int subCountdown = 1;
        MyLabel? firstMyLabel;
        MyLabel? secondMyLabel;
        static List<EnWords> wordIcons = new List<EnWords>()
        {
           EnWords.A,EnWords.A,EnWords.B,EnWords.B,EnWords.C,EnWords.C,EnWords.D,EnWords.D,EnWords.E,EnWords.E,EnWords.F,EnWords.F,/*
          EnWords.G,EnWords.G,EnWords.H,EnWords.H,EnWords.J,EnWords.J,EnWords.K,EnWords.K,EnWords.L,EnWords.L,EnWords.M,EnWords.M,
           EnWords.N,EnWords.N,EnWords.O,EnWords.O,EnWords.P,EnWords.P,EnWords.R,EnWords.R,EnWords.S,EnWords.S,EnWords.T,EnWords.T,
           EnWords.U,EnWords.U,EnWords.W,EnWords.W*/
        };
        public Form1()
        {
            InitializeComponent();

        }

        private void IconSelector()
        {
            int randomNumber = rnd.Next(wordIcons.Count);
            enWords = wordIcons[randomNumber];
            switch (enWords)
            {
                case EnWords.A:
                    icon = "A";
                    break;
                case EnWords.B:
                    icon = "B";
                    break;
                case EnWords.C:
                    icon = "C";
                    break;
                case EnWords.D:
                    icon = "D";
                    break;
                case EnWords.E:
                    icon = "E";
                    break;
                case EnWords.F:
                    icon = "F";
                    break;
                    /*case EnWords.G:
                        icon = "G";
                        break;
                    case EnWords.H:
                        icon = "H";
                        break;
                    case EnWords.J:
                        icon = "J";
                        break;
                    case EnWords.K:
                        icon = "K";
                        break;
                    case EnWords.L:
                        icon = "L";
                        break;
                    case EnWords.M:
                        icon = "M";
                        break;
                    case EnWords.N:
                        icon = "N";
                        break;
                    case EnWords.O:
                        icon = "O";
                        break;
                    case EnWords.P:
                        icon = "P";
                        break;
                    case EnWords.R:
                        icon = "R";
                        break;
                    case EnWords.S:
                        icon = "S";
                        break;
                    case EnWords.T:
                        icon = "T";
                        break;
                    case EnWords.U:
                        icon = "U";
                        break;
                    case EnWords.W:
                        icon = "W";
                        break;*/
            }

            wordIcons.Remove(enWords);

        }

        private void start_Click(object sender, EventArgs e)
        {
            timer1.Start();
            foreach (var control in this.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pictureBox = (PictureBox)control;
                    IconSelector();
                    pictureBox.Controls.Add(
                        new MyLabel(
                            location: new Point(pictureBox.Size.Width / 2 - 12,
                            pictureBox.Size.Height / 2 - 12),
                            icon: icon
                            ));

                }
            }
            button1.Enabled = false;

        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;


            if (!timer1.Enabled)
            {
                timer1.Start();
            }


            if (isFirstPressed)
            {
                isSecondPressed = true;
            }

            if (!isSecondPressed)
            {
                isFirstPressed = true;
            }


            if (isFirstPressed == true && isSecondPressed == false)
            {
                PictureBox pctrBox = (PictureBox)sender;
                firstPressedPictureBox = pctrBox;


            }
            if (isFirstPressed == true && isSecondPressed == true)
            {

                PictureBox pctrBox = (PictureBox)sender;
                secondPressedPictureBox = (PictureBox)sender;
                foreach (var control in this.Controls)
                {
                    if (control is PictureBox)
                    {
                        ((PictureBox)control).Click -= PictureBox_Click;
                    }
                }
                timer2.Start();
                timer1.Stop();
                label1.Text = mainCountdown.ToString();


            }

            foreach (var control in pictureBox.Controls)
            {
                if (control is Label)
                {
                    MyLabel obj = (MyLabel)control;
                    if (!obj.Visible)
                    {
                        obj.Visible = true;

                    }


                }
            }


        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {

            mainCountdown--;
            label1.Text = mainCountdown.ToString();
            if (mainCountdown == 0)
            {
                timer1.Stop();
                isFirstPressed = false;

                if (isPlayerOneTurn)
                {
                    isPlayerOneTurn = false;
                    isPlayerTwoTurn = true;
                    MessageBox.Show("Time is out!! Player 2's turn");
                }

                else if (isPlayerTwoTurn)
                {
                    isPlayerOneTurn = true;
                    isPlayerTwoTurn = false;
                    MessageBox.Show("Time is out!! Player 1's turn");
                }



                if (!isGameStarted)
                {
                    foreach (var controls in this.Controls)
                    {
                        if (controls is PictureBox)
                        {
                            PictureBox pictureBox = (PictureBox)controls;
                            pictureBox.Click += PictureBox_Click;
                        }
                    }
                }

                foreach (var controls in this.Controls)
                {
                    if (controls is PictureBox)
                    {
                        PictureBox pictureBox = (PictureBox)controls;

                        foreach (var control in pictureBox.Controls)
                        {

                            if (control is MyLabel)
                            {
                                MyLabel myLabel = (MyLabel)control;
                                if (pictureBox.Enabled)
                                {
                                    myLabel.Visible = false;

                                }

                            }
                        }
                    }
                }


                mainCountdown = 5;
                label1.Text = mainCountdown.ToString();
                if (!isGameStarted)
                {
                    MessageBox.Show("Player 1's turn.");
                    isPlayerOneTurn = true;
                }

                isGameStarted = true;

            }

        }

        private void subTimer_Tick(object sender, EventArgs e)
        {

            subCountdown--;

            if (subCountdown == 0)
            {
                foreach (var control in firstPressedPictureBox.Controls)
                {
                    if (control is MyLabel)
                    {
                        firstMyLabel = (MyLabel)control;

                    }


                }
                foreach (var control in secondPressedPictureBox.Controls)
                {
                    if (control is MyLabel)
                    {
                        secondMyLabel = (MyLabel)control;
                    }

                }

                if (firstPressedPictureBox != secondPressedPictureBox)
                {
                    if (firstMyLabel!.PIcon == secondMyLabel!.PIcon)
                    {

                        firstPressedPictureBox.Enabled = false;
                        secondPressedPictureBox.Enabled = false;
                        label1.Text = mainCountdown.ToString();
                        if (isPlayerOneTurn)
                        {
                            playerOnePoints += 10;
                            label2.Text = "Player1 Points: " + playerOnePoints;
                        }
                        else if (isPlayerTwoTurn)
                        {
                            playerTwoPoints += 10;
                            label3.Text = "Player2 Points: " + playerTwoPoints;
                        }
                        MessageBox.Show("Congrats!! You found the equivalent pair.");
                        mainCountdown = 5;
                        label1.Text = mainCountdown.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Sorry!! Thats not the right one.");
                        if (isPlayerOneTurn)
                        {
                            isPlayerOneTurn = false;
                            isPlayerTwoTurn = true;
                            MessageBox.Show("Player 2's turn.");
                        }
                        else if (isPlayerTwoTurn)
                        {
                            isPlayerOneTurn = true;
                            isPlayerTwoTurn = false;
                            MessageBox.Show("Player 1's turn.");
                        }
                        firstMyLabel.Visible = false;
                        secondMyLabel.Visible = false;
                        mainCountdown = 5;
                        label1.Text = mainCountdown.ToString();

                    }
                }
                else
                {
                    MessageBox.Show("You have already chosen this one.Try another one.");
                    timer1.Start();
                    firstMyLabel!.Visible = false;
                }

                isFirstPressed = false;
                isSecondPressed = false;

                foreach (var control in this.Controls)
                {
                    if (control is PictureBox)
                    {
                        ((PictureBox)control).Click += PictureBox_Click;
                    }
                }
                subCountdown = 2;
                timer2.Stop();
                if (checkIfGameFinished())
                {
                    Winner();
                }

            }

        }
        private void Winner()
        {
            if (playerOnePoints > playerTwoPoints)
            {
                MessageBox.Show("Player 1 wins!!!");
            }
            else if (playerOnePoints < playerTwoPoints)
            {
                MessageBox.Show("Player 2 wins!!!");
            }
            else
            {
                MessageBox.Show("Draw!!!");
            }
        }
        private bool checkIfGameFinished()
        {
            int disabledLenght = 0;
            int pictureBoxLenght = 0;
            foreach (var control in this.Controls)
            {
                if (control is PictureBox)
                {
                    pictureBoxLenght++;
                    PictureBox pctBox = (PictureBox)control;

                    if (pctBox.Enabled == false)
                    {
                        disabledLenght++;

                    }
                }

            }


            if (disabledLenght == pictureBoxLenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

}