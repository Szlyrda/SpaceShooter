namespace SpaceShooter
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MoveBackGTimer = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.leftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.rightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.upMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.downMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.moveAmmoTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyAmmoTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.replayBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.scorelbl = new System.Windows.Forms.Label();
            this.levellbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBackGTimer
            // 
            this.MoveBackGTimer.Enabled = true;
            this.MoveBackGTimer.Interval = 10;
            this.MoveBackGTimer.Tick += new System.EventHandler(this.MoveBackGTimer_Tick);
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(260, 400);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(50, 50);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // leftMoveTimer
            // 
            this.leftMoveTimer.Interval = 5;
            this.leftMoveTimer.Tick += new System.EventHandler(this.leftMoveTimer_Tick);
            // 
            // rightMoveTimer
            // 
            this.rightMoveTimer.Interval = 5;
            this.rightMoveTimer.Tick += new System.EventHandler(this.rightMoveTimer_Tick);
            // 
            // upMoveTimer
            // 
            this.upMoveTimer.Interval = 5;
            this.upMoveTimer.Tick += new System.EventHandler(this.upMoveTimer_Tick);
            // 
            // downMoveTimer
            // 
            this.downMoveTimer.Interval = 5;
            this.downMoveTimer.Tick += new System.EventHandler(this.downMoveTimer_Tick);
            // 
            // moveAmmoTimer
            // 
            this.moveAmmoTimer.Enabled = true;
            this.moveAmmoTimer.Interval = 20;
            this.moveAmmoTimer.Tick += new System.EventHandler(this.moveAmmoTimer_Tick);
            // 
            // enemyMoveTimer
            // 
            this.enemyMoveTimer.Enabled = true;
            this.enemyMoveTimer.Tick += new System.EventHandler(this.enemyMoveTimer_Tick);
            // 
            // enemyAmmoTimer
            // 
            this.enemyAmmoTimer.Enabled = true;
            this.enemyAmmoTimer.Interval = 20;
            this.enemyAmmoTimer.Tick += new System.EventHandler(this.enemyAmmoTimer_Tick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(113, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "pauza/gameover/win";
            this.label1.Visible = false;
            // 
            // replayBtn
            // 
            this.replayBtn.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.replayBtn.Location = new System.Drawing.Point(180, 199);
            this.replayBtn.Name = "replayBtn";
            this.replayBtn.Size = new System.Drawing.Size(224, 53);
            this.replayBtn.TabIndex = 2;
            this.replayBtn.Text = "Powtórz";
            this.replayBtn.UseVisualStyleBackColor = true;
            this.replayBtn.Visible = false;
            this.replayBtn.Click += new System.EventHandler(this.replayBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Impact", 15.75F);
            this.exitBtn.Location = new System.Drawing.Point(180, 279);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(224, 53);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Wyjście";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Visible = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // scorelbl
            // 
            this.scorelbl.AutoSize = true;
            this.scorelbl.Font = new System.Drawing.Font("Wide Latin", 12F);
            this.scorelbl.ForeColor = System.Drawing.Color.Red;
            this.scorelbl.Location = new System.Drawing.Point(13, 13);
            this.scorelbl.Name = "scorelbl";
            this.scorelbl.Size = new System.Drawing.Size(0, 19);
            this.scorelbl.TabIndex = 4;
            // 
            // levellbl
            // 
            this.levellbl.AutoSize = true;
            this.levellbl.Font = new System.Drawing.Font("Wide Latin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levellbl.ForeColor = System.Drawing.Color.Red;
            this.levellbl.Location = new System.Drawing.Point(537, 12);
            this.levellbl.Name = "levellbl";
            this.levellbl.Size = new System.Drawing.Size(0, 19);
            this.levellbl.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.levellbl);
            this.Controls.Add(this.scorelbl);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.replayBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Player);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Shooter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MoveBackGTimer;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer leftMoveTimer;
        private System.Windows.Forms.Timer rightMoveTimer;
        private System.Windows.Forms.Timer upMoveTimer;
        private System.Windows.Forms.Timer downMoveTimer;
        private System.Windows.Forms.Timer moveAmmoTimer;
        private System.Windows.Forms.Timer enemyMoveTimer;
        private System.Windows.Forms.Timer enemyAmmoTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button replayBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label scorelbl;
        private System.Windows.Forms.Label levellbl;
    }
}

