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

            timerColor.Interval = 2000; // 2초마다 색 바꿈
            timerColor.Tick += timerColor_Tick;
            timerColor.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //공의 위치를 변경
            picBall.Left += ballSpeedX;
            picBall.Top += ballSpeedY;
            rand = new Random();

            //공이 벽에 부딪혔을 때 방향 전환
            if (picBall.Left < 0 || picBall.Right > panelGame.Width) //좌우 벽
            {
                ballSpeedX = -ballSpeedX;
            }
            if (picBall.Top <= 0 || picBall.Bottom >= panelGame.Height) //상하 벽
            {
                ballSpeedY = -ballSpeedY;
            }

            //플레이어 패들에 맞았을 때 튕기기
            if (picBall.Bounds.IntersectsWith(playerPaddle.Bounds))
            {
                ballSpeedX = -ballSpeedX; //공의 방향 x 방향 반전

                float relativeY = (playerPaddle.Top + playerPaddle.Height / 2) - (picBall.Top + picBall.Height / 2);
                float normalized = relativeY / (playerPaddle.Height / 2);
                ballSpeedY = (int)(normalized * 5 + rand.Next(-2, 3)); //각도 조정
            }

            //ai 패들에 맞았을 때 튕기기
            if (picBall.Bounds.IntersectsWith(aiPaddle.Bounds))
            {
                ballSpeedX = -ballSpeedX; //공의 방향 x 방향 반전

                float relativeY = (aiPaddle.Top + aiPaddle.Height / 2) - (picBall.Top + picBall.Height / 2);
                float normalized = relativeY / (aiPaddle.Height / 2);
                ballSpeedY = (int)(normalized * 5 + rand.Next(-2, 3));
            }

            //AI 패들 이동
            MoveAIPaddle();

            //점수 갱신
            UpdateScore();

            //게임 종료 여부
            CheckGameOver();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && playerPaddle.Top > 0)
            {
                playerPaddle.Top -= playerSpeed; //위로 이동
            }
            if (e.KeyCode == Keys.Down && playerPaddle.Bottom < panelGame.Height)
            {
                playerPaddle.Top += playerSpeed; //아래로 이동
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
            if (picBall.Left <= 0) //AI 점수
            {
                aiScore++;
                labelScore.Text = playerScore + " : " + aiScore;
            }
            if (picBall.Right >= panelGame.Width) //플레이어 점수
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
