using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PingPongGame
{
    public partial class Form1 : Form
    {
        int ballSpeedX = 7;
        int ballSpeedY = 7;

        int playerSpeed = 10;

        int playerScore = 0;
        int aiScore = 0;

        Random rand;

        bool isRed = false;
        Color originalColor;


        public Form1()
        {
            InitializeComponent();
            originalColor = this.BackColor;

            timerColor.Interval = 2000; // 2�ʸ��� �� �ٲ�
            timerColor.Tick += timerColor_Tick;
            timerColor.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //���� ��ġ�� ����
            picBall.Left += ballSpeedX;
            picBall.Top += ballSpeedY;
            rand = new Random();

            //���� ���� �ε����� �� ���� ��ȯ
            if (picBall.Left < 0 || picBall.Right > panelGame.Width) //�¿� ��
            {
                ballSpeedX = -ballSpeedX;
            }
            if (picBall.Top <= 0 || picBall.Bottom >= panelGame.Height) //���� ��
            {
                ballSpeedY = -ballSpeedY;
            }

            //�÷��̾� �е鿡 �¾��� �� ƨ���
            if (picBall.Bounds.IntersectsWith(playerPaddle.Bounds))
            {
                ballSpeedX = -ballSpeedX; //���� ���� x ���� ����

                float relativeY = (playerPaddle.Top + playerPaddle.Height / 2) - (picBall.Top + picBall.Height / 2);
                float normalized = relativeY / (playerPaddle.Height / 2);
                ballSpeedY = (int)(normalized * 5 + rand.Next(-2, 3)); //���� ����
            }

            //ai �е鿡 �¾��� �� ƨ���
            if (picBall.Bounds.IntersectsWith(aiPaddle.Bounds))
            {
                ballSpeedX = -ballSpeedX; //���� ���� x ���� ����

                float relativeY = (aiPaddle.Top + aiPaddle.Height / 2) - (picBall.Top + picBall.Height / 2);
                float normalized = relativeY / (aiPaddle.Height / 2);
                ballSpeedY = (int)(normalized * 5 + rand.Next(-2, 3));
            }

            //AI �е� �̵�
            MoveAIPaddle();

            //���� ����
            UpdateScore();

            //���� ���� ����
            CheckGameOver();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && playerPaddle.Top > 0)
            {
                playerPaddle.Top -= playerSpeed; //���� �̵�
            }
            if (e.KeyCode == Keys.Down && playerPaddle.Bottom < panelGame.Height)
            {
                playerPaddle.Top += playerSpeed; //�Ʒ��� �̵�
            }
        }

        private void MoveAIPaddle()
        {
            if (picBall.Top < aiPaddle.Top)
            {
                aiPaddle.Top -= 4;
            }
            if (picBall.Bottom > aiPaddle.Top)
            {
                aiPaddle.Top += 4;
            }
        }

        private void UpdateScore()
        {
            if (picBall.Left <= 0) //AI ����
            {
                aiScore++;
                labelScore.Text = playerScore + " : " + aiScore;
            }
            if (picBall.Right >= panelGame.Width) //�÷��̾� ����
            {
                playerScore++;
                labelScore.Text = playerScore + " : " + aiScore;
            }
        }

        private void CheckGameOver()
        {
            if (playerScore >= 10)
            {
                ResetGame();
                MessageBox.Show("Player Wins!");
            }
            else if (aiScore >= 10)
            {
                ResetGame();
                MessageBox.Show("AI Wins!");
            }
        }

        private void ResetGame()
        {
            playerScore = 0;
            aiScore = 0;
            labelScore.Text = "0 : 0";
            picBall.Left = (panelGame.Width - picBall.Width) / 2;
            picBall.Top = (panelGame.Height - picBall.Height) / 2;
        }

        private void timerColor_Tick(object sender, EventArgs e)
        {
            if (isRed)
            {
                this.BackColor = originalColor;
            }
            else
            {
                this.BackColor = Color.Red;
            }

            isRed = !isRed;
        }
    }
}
