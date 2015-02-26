namespace GUI
{
    partial class Presenting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbClientPlayer = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbClientPresenter = new System.Windows.Forms.ListBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbQuestion = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelAns = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.labelQuest = new System.Windows.Forms.Label();
            this.btnKick = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timerCountDown = new System.Windows.Forms.Timer(this.components);
            this.lbQuestionNext = new System.Windows.Forms.Label();
            this.labelAnsNext = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbClientPlayer
            // 
            this.lbClientPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientPlayer.FormattingEnabled = true;
            this.lbClientPlayer.ItemHeight = 20;
            this.lbClientPlayer.Location = new System.Drawing.Point(3, 258);
            this.lbClientPlayer.Name = "lbClientPlayer";
            this.lbClientPlayer.Size = new System.Drawing.Size(365, 124);
            this.lbClientPlayer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("DejaVu Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "List Client Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("DejaVu Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "List Client Presenter";
            // 
            // lbClientPresenter
            // 
            this.lbClientPresenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientPresenter.FormattingEnabled = true;
            this.lbClientPresenter.ItemHeight = 18;
            this.lbClientPresenter.Location = new System.Drawing.Point(3, 30);
            this.lbClientPresenter.Name = "lbClientPresenter";
            this.lbClientPresenter.Size = new System.Drawing.Size(157, 202);
            this.lbClientPresenter.TabIndex = 3;
            this.lbClientPresenter.SelectedIndexChanged += new System.EventHandler(this.lbClientPresenter_SelectedIndexChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(6, 583);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(45, 16);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("DejaVu Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(172, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "List Question";
            // 
            // lbQuestion
            // 
            this.lbQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuestion.FormattingEnabled = true;
            this.lbQuestion.ItemHeight = 18;
            this.lbQuestion.Location = new System.Drawing.Point(166, 30);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(208, 202);
            this.lbQuestion.TabIndex = 7;
            this.lbQuestion.SelectedIndexChanged += new System.EventHandler(this.lbQuestion_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelAns);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.labelTimer);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.labelQuest);
            this.groupBox1.Location = new System.Drawing.Point(380, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 286);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question is being showed";
            // 
            // labelAns
            // 
            this.labelAns.AutoSize = true;
            this.labelAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAns.Location = new System.Drawing.Point(6, 246);
            this.labelAns.Name = "labelAns";
            this.labelAns.Size = new System.Drawing.Size(70, 25);
            this.labelAns.TabIndex = 4;
            this.labelAns.Text = "label5";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(203, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 150);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.ForeColor = System.Drawing.Color.Red;
            this.labelTimer.Location = new System.Drawing.Point(520, 16);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(35, 13);
            this.labelTimer.TabIndex = 2;
            this.labelTimer.Text = "label5";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(523, 129);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(87, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show Answer";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // labelQuest
            // 
            this.labelQuest.AutoSize = true;
            this.labelQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuest.Location = new System.Drawing.Point(6, 36);
            this.labelQuest.Name = "labelQuest";
            this.labelQuest.Size = new System.Drawing.Size(70, 25);
            this.labelQuest.TabIndex = 0;
            this.labelQuest.Text = "label4";
            // 
            // btnKick
            // 
            this.btnKick.Location = new System.Drawing.Point(293, 545);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(75, 23);
            this.btnKick.TabIndex = 10;
            this.btnKick.Text = "Kick";
            this.btnKick.UseVisualStyleBackColor = true;
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(3, 545);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 11;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(150, 545);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop Server";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // timerCountDown
            // 
            this.timerCountDown.Tick += new System.EventHandler(this.timerCountDown_Tick);
            // 
            // lbQuestionNext
            // 
            this.lbQuestionNext.AutoSize = true;
            this.lbQuestionNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbQuestionNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuestionNext.Location = new System.Drawing.Point(3, 16);
            this.lbQuestionNext.Name = "lbQuestionNext";
            this.lbQuestionNext.Size = new System.Drawing.Size(70, 25);
            this.lbQuestionNext.TabIndex = 1;
            this.lbQuestionNext.Text = "label5";
            // 
            // labelAnsNext
            // 
            this.labelAnsNext.AutoSize = true;
            this.labelAnsNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnsNext.Location = new System.Drawing.Point(6, 230);
            this.labelAnsNext.Name = "labelAnsNext";
            this.labelAnsNext.Size = new System.Drawing.Size(70, 25);
            this.labelAnsNext.TabIndex = 5;
            this.labelAnsNext.Text = "label5";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(529, 127);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send Question";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(190, 59);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(240, 160);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.labelAnsNext);
            this.groupBox2.Controls.Add(this.lbQuestionNext);
            this.groupBox2.Location = new System.Drawing.Point(380, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 264);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "The next question";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 388);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(365, 151);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Presenting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 606);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.btnKick);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbClientPresenter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbClientPlayer);
            this.Name = "Presenting";
            this.Text = "Presenting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbClientPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbClientPresenter;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbQuestion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.Label labelAns;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label labelQuest;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timerCountDown;
        private System.Windows.Forms.Label lbQuestionNext;
        private System.Windows.Forms.Label labelAnsNext;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}