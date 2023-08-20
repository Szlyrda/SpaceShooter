using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib; // Dodane odwołanie do biblioteki Windows Media Player

namespace SpaceShooter
{
    public partial class Form1 : Form
    {
        // Obiekty WindowsMediaPlayer dla dźwięku w grze
        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootgMedia;
        WindowsMediaPlayer explosion;

        // Tablice elementów PictureBox dla obiektów w grze
        PictureBox[] stars;
        int playerSpeed;

        PictureBox[] ammunition;
        int AmmunitionSpeed;

        PictureBox[] enemies;
        int enemiesSpeed;

        PictureBox[] enemyAmmo;
        int enemyAmmoSpeed;


        int backgroundspeed;
        Random rnd;

        int score;
        int level;
        int difficulty;
        bool pause;
        bool gameIsOver;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicjalizacja zmiennych i ustawienie wartości początkowych
            pause = false;
            gameIsOver = false;
            score = 0;
            level = 1;
            difficulty = 9;

            backgroundspeed = 4;
            playerSpeed = 4;
            enemiesSpeed = 4;
            AmmunitionSpeed = 20;
            enemyAmmoSpeed = 4;

            ammunition = new PictureBox[3];

            // Ładowanie obrazów dla amunicji i przeciwników
            Image missile = Image.FromFile(@"asserts\ammunition.png");
            Image enemy1 = Image.FromFile(@"asserts\E1.png");
            Image enemy2 = Image.FromFile(@"asserts\E2.png");
            Image enemy3 = Image.FromFile(@"asserts\E3.png");
            Image boss1 = Image.FromFile(@"asserts\Boss1.png");
            Image boss2 = Image.FromFile(@"asserts\Boss2.png");

            enemies = new PictureBox[10];

            // Inicjalizacja PictureBox dla przeciwników
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, -50);
            }

            // Przypisanie obrazów przeciwników do odpowiednich PictureBox
            enemies[0].Image = boss1;
            enemies[1].Image = enemy2;
            enemies[2].Image = enemy3;
            enemies[3].Image = enemy3;
            enemies[4].Image = enemy1;
            enemies[5].Image = enemy3;
            enemies[6].Image = enemy2;
            enemies[7].Image = enemy3;
            enemies[8].Image = enemy2;
            enemies[9].Image = boss2;


            // Inicjalizacja PictureBox dla amunicji gracza
            for (int i = 0; i < ammunition.Length; i++)
            {
                ammunition[i] = new PictureBox();
                ammunition[i].Size = new Size(8, 8);
                ammunition[i].Image = missile;
                ammunition[i].SizeMode = PictureBoxSizeMode.Zoom;
                ammunition[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(ammunition[i]);
            }

            //Windows Media Player
            gameMedia = new WindowsMediaPlayer();
            shootgMedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();

            //Ładowanie muzyki
            gameMedia.URL = "songs\\GameSong.mp3";
            shootgMedia.URL = "songs\\shoot.mp3";
            explosion.URL = "songs\\boom.mp3";

            //Ustawienia muzyki
            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 30;
            shootgMedia.settings.volume = 2;
            explosion.settings.volume = 4;

            // Inicjalizacja gwiazd w tle
            stars = new PictureBox[10];
            rnd = new Random();

            // Pętla tworząca dwa rodzaje gwiazd w losowych miejscach
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 550), rnd.Next(-10, 550));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }

                this.Controls.Add(stars[i]);
            }

            // Inicjalizacja amunicji przeciwników
            enemyAmmo = new PictureBox[10];

            for (int i = 0; i < enemyAmmo.Length; i++)
            {
                enemyAmmo[i] = new PictureBox();
                enemyAmmo[i].Size = new Size(2, 25);
                enemyAmmo[i].Visible = false;
                enemyAmmo[i].BackColor = Color.YellowGreen;
                int x = rnd.Next(0, 10);
                enemyAmmo[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemyAmmo[i]);
            }
            // Odtwarzanie muzyki w grze
            gameMedia.controls.play();
        }

        // Przesuwanie gwiazd w tle
        private void MoveBackGTimer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < stars.Length/2; i++)
            {
                stars[i].Top += backgroundspeed;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length/2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed-2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        // Poruszanie się gracza
        private void leftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void rightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 580)
            {
                Player.Left += playerSpeed;
            }

        }

        private void upMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 5)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void downMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 410)
            {
                Player.Top += playerSpeed;
            }
        }

        // Obsługa naciśnięcia klawiszy ruchu gracza
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    rightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    leftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    upMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    downMoveTimer.Start();
                }
            }
        }

        // Obsługa zwolnienia klawiszy ruchu gracza i pauzy
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            rightMoveTimer.Stop();
            leftMoveTimer.Stop();
            upMoveTimer.Stop();
            downMoveTimer.Stop();

            if (e.KeyCode == Keys.Space)
            {
                if (!gameIsOver)
                {
                    if (pause)
                    {
                        StartTimers();
                        label1.Visible = false;
                        gameMedia.controls.play();
                        pause = false;
                    }
                    else
                    {
                        label1.Location = new Point(this.Width/2 - 75, 190);
                        label1.Text = "PAUZA";
                        label1.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }
            }
        }

        // Poruszanie się amunicji gracza
        private void moveAmmoTimer_Tick(object sender, EventArgs e)
        {
            shootgMedia.controls.play();
            for (int i = 0; i < ammunition.Length; i++)
            {
                if (ammunition[i].Top > 0)
                {
                    ammunition[i].Visible = true;
                    ammunition[i].Top -= AmmunitionSpeed;

                    Collision();
                }
                else
                {
                    ammunition[i].Visible = false;
                    ammunition[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                }
            }
        }

        // Poruszanie się wrogów
        private void enemyMoveTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiesSpeed);
        }

        // Przesuwanie wrogów w dół planszy
        private void MoveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }

        // Kolizje, punktacja, poziom trudności
        private void Collision()
        {

            // Wykrywanie kolizji między amunicją gracza a wrogami
            for (int i = 0; i < enemies.Length; i++)
            {
                if (ammunition[0].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    ammunition[1].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    ammunition[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.controls.play();
                    // Zdobywanie punktów
                    score += 1;
                    scorelbl.Text = (score < 10) ? "0" + score.ToString() : score.ToString();

                    // Zwiększanie poziomu trudności co określoną ilość zdobytych punktów
                    if (score % 30 == 0)
                    {
                        level += 1;
                        levellbl.Text = (level < 10) ? "0" + level.ToString() : level.ToString();

                        if (enemiesSpeed <= 10 && enemyAmmoSpeed <= 10 && difficulty >= 0)
                        {
                            difficulty--;
                            enemiesSpeed++;
                            enemyAmmoSpeed++;
                        }

                        if (level == 10)
                        {
                            GameOver("BRAWO!!!");
                        }
                    }
                    enemies[i].Location = new Point ((i+1) * 50, -100);
                }

                // Wykrywanie kolizji między wrogiem a graczem
                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("KONIEC GRY");
                }
                   
            }
        }

        // Koniec gry
        private void GameOver (String str)
        {
            label1.Text = str;
            label1.Location = new Point(190, 120);
            label1.Visible = true;
            replayBtn.Visible = true;
            exitBtn.Visible = true;

            gameMedia.controls.stop();
            StopTimers();
        }

        //Zatrzymanie timerów
        private void StopTimers()
        {

            upMoveTimer.Stop();
            rightMoveTimer.Stop();
            leftMoveTimer.Stop();
            MoveBackGTimer.Stop();
            enemyMoveTimer.Stop();
            moveAmmoTimer.Stop();
            enemyAmmoTimer.Stop();
        }

        //Start timerów
        private void StartTimers()
        {
            MoveBackGTimer.Start();
            enemyMoveTimer.Start();
            moveAmmoTimer.Start();
            enemyAmmoTimer.Start();
        }

        // Aktualizacja położenia amunicji wrogów
        private void enemyAmmoTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < enemyAmmo.Length - difficulty; i++)
            {
                if (enemyAmmo[i].Top < this.Height)
                {
                    // Przesunięcie amunicji w dół
                    enemyAmmo[i].Visible = true;
                    enemyAmmo[i].Top += enemyAmmoSpeed;
                    CollisionWithEnemyAmmo(); // Wywołanie metody sprawdzającej kolizję z graczem
                }
                else
                {
                    // Jeśli amunicja wypadła poza obszar gry, ustaw jej nową pozycję
                    enemyAmmo[i].Visible = false;
                    int x = rnd.Next(0, 10);
                    enemyAmmo[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }
        }

        // Wykrywanie kolizji między amunicją wrogów a graczem
        private void CollisionWithEnemyAmmo()
        {
            for (int i = 0; i < enemyAmmo.Length; i++)
            {
                if (enemyAmmo[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemyAmmo[i].Visible = false;
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Koniec Gry");
                    

                }
            }
        }

        // Przywrócenie gry do początkowego stanu po kliknięciu przycisku "Powtórz"
        private void replayBtn_Click(object sender, EventArgs e)
        {
            
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
            
        }

        // Wyjście z gry
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
