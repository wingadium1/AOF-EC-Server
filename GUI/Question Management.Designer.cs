namespace GUI
{
    partial class Question_Management
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
            this.listBoxQuestion = new System.Windows.Forms.ListBox();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnNewQuestion = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbQuestionText = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAns = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textQuestionTime = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxVideo = new System.Windows.Forms.TextBox();
            this.buttonBroVideo = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxQuestion
            // 
            this.listBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxQuestion.FormattingEnabled = true;
            this.listBoxQuestion.ItemHeight = 24;
            this.listBoxQuestion.Location = new System.Drawing.Point(12, 12);
            this.listBoxQuestion.Name = "listBoxQuestion";
            this.listBoxQuestion.Size = new System.Drawing.Size(274, 460);
            this.listBoxQuestion.TabIndex = 0;
            this.listBoxQuestion.SelectedIndexChanged += new System.EventHandler(this.listBoxQuestion_SelectedIndexChanged);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.Location = new System.Drawing.Point(12, 478);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(119, 28);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.Location = new System.Drawing.Point(167, 478);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(119, 28);
            this.btnMoveDown.TabIndex = 2;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnNewQuestion
            // 
            this.btnNewQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewQuestion.Location = new System.Drawing.Point(12, 512);
            this.btnNewQuestion.Name = "btnNewQuestion";
            this.btnNewQuestion.Size = new System.Drawing.Size(119, 27);
            this.btnNewQuestion.TabIndex = 3;
            this.btnNewQuestion.Text = "New";
            this.btnNewQuestion.UseVisualStyleBackColor = true;
            this.btnNewQuestion.Click += new System.EventHandler(this.btnNewQuestion_Click);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToFile.Location = new System.Drawing.Point(167, 512);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(119, 28);
            this.btnSaveToFile.TabIndex = 4;
            this.btnSaveToFile.Text = "Save To File";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Question Text";
            // 
            // tbQuestionText
            // 
            this.tbQuestionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuestionText.Location = new System.Drawing.Point(292, 40);
            this.tbQuestionText.Multiline = true;
            this.tbQuestionText.Name = "tbQuestionText";
            this.tbQuestionText.Size = new System.Drawing.Size(699, 77);
            this.tbQuestionText.TabIndex = 6;
            this.tbQuestionText.Leave += new System.EventHandler(this.tbQuestionText_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(492, 242);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Question Answer";
            // 
            // tbAns
            // 
            this.tbAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAns.Location = new System.Drawing.Point(292, 148);
            this.tbAns.Multiline = true;
            this.tbAns.Name = "tbAns";
            this.tbAns.Size = new System.Drawing.Size(699, 88);
            this.tbAns.TabIndex = 11;
            this.tbAns.TextChanged += new System.EventHandler(this.tbAns_TextChanged);
            this.tbAns.Leave += new System.EventHandler(this.tbAns_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(292, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Question Image";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(851, 242);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(119, 28);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(851, 454);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(119, 28);
            this.btnDel.TabIndex = 15;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(851, 276);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(119, 28);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 511);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Question Time";
            // 
            // textQuestionTime
            // 
            this.textQuestionTime.Location = new System.Drawing.Point(449, 514);
            this.textQuestionTime.Name = "textQuestionTime";
            this.textQuestionTime.Size = new System.Drawing.Size(100, 20);
            this.textQuestionTime.TabIndex = 18;
            this.textQuestionTime.Leave += new System.EventHandler(this.textQuestionTime_Leave);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(877, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 28);
            this.button1.TabIndex = 19;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBoxVideo
            // 
            this.textBoxVideo.Location = new System.Drawing.Point(555, 514);
            this.textBoxVideo.Name = "textBoxVideo";
            this.textBoxVideo.Size = new System.Drawing.Size(267, 20);
            this.textBoxVideo.TabIndex = 20;
            this.textBoxVideo.Leave += new System.EventHandler(this.textBoxVideo_Leave);
            // 
            // buttonBroVideo
            // 
            this.buttonBroVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBroVideo.Location = new System.Drawing.Point(838, 506);
            this.buttonBroVideo.Name = "buttonBroVideo";
            this.buttonBroVideo.Size = new System.Drawing.Size(74, 28);
            this.buttonBroVideo.TabIndex = 21;
            this.buttonBroVideo.Text = "Browse";
            this.buttonBroVideo.UseVisualStyleBackColor = true;
            this.buttonBroVideo.Click += new System.EventHandler(this.buttonBroVideo_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(922, 506);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(74, 28);
            this.buttonPlay.TabIndex = 22;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // Question_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 546);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonBroVideo);
            this.Controls.Add(this.textBoxVideo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textQuestionTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbAns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbQuestionText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.btnNewQuestion);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.listBoxQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Question_Management";
            this.Text = "Question_Management";
            this.Load += new System.EventHandler(this.Question_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxQuestion;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnNewQuestion;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbQuestionText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textQuestionTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxVideo;
        private System.Windows.Forms.Button buttonBroVideo;
        private System.Windows.Forms.Button buttonPlay;
    }
}