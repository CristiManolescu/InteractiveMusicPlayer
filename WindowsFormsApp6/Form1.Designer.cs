namespace WindowsFormsApp6
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPlayStop = new System.Windows.Forms.Button();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.listBoxLocalMusicFiles = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMuteUnmute = new System.Windows.Forms.Button();
            this.trackBarCurrentPosition = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetMusicList = new System.Windows.Forms.Button();
            this.listBoxServerMusicFiles = new System.Windows.Forms.ListBox();
            this.btnDownloadSelected = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCurrentPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(22, 42);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPlayStop
            // 
            this.btnPlayStop.Location = new System.Drawing.Point(103, 42);
            this.btnPlayStop.Name = "btnPlayStop";
            this.btnPlayStop.Size = new System.Drawing.Size(75, 23);
            this.btnPlayStop.TabIndex = 1;
            this.btnPlayStop.Text = "Play";
            this.btnPlayStop.UseVisualStyleBackColor = true;
            this.btnPlayStop.Click += new System.EventHandler(this.btnPlayStop_Click);
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Location = new System.Drawing.Point(184, 42);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(75, 23);
            this.btnPauseResume.TabIndex = 2;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(478, 13);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 5;
            this.axWindowsMediaPlayer1.Visible = false;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            this.axWindowsMediaPlayer1.MediaChange += new AxWMPLib._WMPOCXEvents_MediaChangeEventHandler(this.axWindowsMediaPlayer1_MediaChange);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "MP3 | *.mp3*";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(5, 19);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(399, 45);
            this.trackBarVolume.TabIndex = 6;
            this.trackBarVolume.Value = 100;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // listBoxLocalMusicFiles
            // 
            this.listBoxLocalMusicFiles.FormattingEnabled = true;
            this.listBoxLocalMusicFiles.Location = new System.Drawing.Point(22, 71);
            this.listBoxLocalMusicFiles.Name = "listBoxLocalMusicFiles";
            this.listBoxLocalMusicFiles.Size = new System.Drawing.Size(399, 134);
            this.listBoxLocalMusicFiles.TabIndex = 7;
            this.listBoxLocalMusicFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxLocalMusicFiles_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMuteUnmute);
            this.groupBox1.Controls.Add(this.trackBarVolume);
            this.groupBox1.Location = new System.Drawing.Point(22, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 79);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setari volum";
            // 
            // btnMuteUnmute
            // 
            this.btnMuteUnmute.Location = new System.Drawing.Point(15, 50);
            this.btnMuteUnmute.Name = "btnMuteUnmute";
            this.btnMuteUnmute.Size = new System.Drawing.Size(75, 23);
            this.btnMuteUnmute.TabIndex = 7;
            this.btnMuteUnmute.Text = "Mute";
            this.btnMuteUnmute.UseVisualStyleBackColor = true;
            this.btnMuteUnmute.Click += new System.EventHandler(this.btnMuteUnmute_Click);
            // 
            // trackBarCurrentPosition
            // 
            this.trackBarCurrentPosition.Location = new System.Drawing.Point(22, 241);
            this.trackBarCurrentPosition.Maximum = 100;
            this.trackBarCurrentPosition.Name = "trackBarCurrentPosition";
            this.trackBarCurrentPosition.Size = new System.Drawing.Size(399, 45);
            this.trackBarCurrentPosition.TabIndex = 9;
            this.trackBarCurrentPosition.Scroll += new System.EventHandler(this.trackBarCurrentPosition_Scroll);
            this.trackBarCurrentPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarCurrentPosition_MouseDown);
            this.trackBarCurrentPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarCurrentPosition_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 10;
            // 
            // btnGetMusicList
            // 
            this.btnGetMusicList.Location = new System.Drawing.Point(427, 42);
            this.btnGetMusicList.Name = "btnGetMusicList";
            this.btnGetMusicList.Size = new System.Drawing.Size(132, 23);
            this.btnGetMusicList.TabIndex = 11;
            this.btnGetMusicList.Text = "Get music list";
            this.btnGetMusicList.UseVisualStyleBackColor = true;
            this.btnGetMusicList.Click += new System.EventHandler(this.btnGetMusicList_Click);
            // 
            // listBoxServerMusicFiles
            // 
            this.listBoxServerMusicFiles.FormattingEnabled = true;
            this.listBoxServerMusicFiles.Location = new System.Drawing.Point(427, 71);
            this.listBoxServerMusicFiles.Name = "listBoxServerMusicFiles";
            this.listBoxServerMusicFiles.Size = new System.Drawing.Size(399, 134);
            this.listBoxServerMusicFiles.TabIndex = 12;
            // 
            // btnDownloadSelected
            // 
            this.btnDownloadSelected.Location = new System.Drawing.Point(565, 42);
            this.btnDownloadSelected.Name = "btnDownloadSelected";
            this.btnDownloadSelected.Size = new System.Drawing.Size(132, 23);
            this.btnDownloadSelected.TabIndex = 13;
            this.btnDownloadSelected.Text = "Download selected";
            this.btnDownloadSelected.UseVisualStyleBackColor = true;
            this.btnDownloadSelected.Click += new System.EventHandler(this.btnDownloadSelected_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 14;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(453, 222);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Repeat";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(453, 246);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Shuffle";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 410);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDownloadSelected);
            this.Controls.Add(this.listBoxServerMusicFiles);
            this.Controls.Add(this.btnGetMusicList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarCurrentPosition);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxLocalMusicFiles);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.btnPauseResume);
            this.Controls.Add(this.btnPlayStop);
            this.Controls.Add(this.btnOpen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCurrentPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPlayStop;
        private System.Windows.Forms.Button btnPauseResume;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.ListBox listBoxLocalMusicFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMuteUnmute;
        private System.Windows.Forms.TrackBar trackBarCurrentPosition;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetMusicList;
        private System.Windows.Forms.ListBox listBoxServerMusicFiles;
        private System.Windows.Forms.Button btnDownloadSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

