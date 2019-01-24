using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        #region Properties and fields
        #region Helpfull shits
        private bool isMouseDownOnTrackbar = false;
        #endregion

        #region Database configuration
        private const string DatabaseServerHost = "188.241.222.75";
        private const string DatabaseName = "interac2_musicdb";
        private const string DatabaseUser = "interac2_musicdb";
        private const string DatabasePassword = "interac2_musicdb";
        private const string FTPUser = "interac2";
        private const string FTPPassword = "v6*1A-9k8qBbSS";
        private const string ConnectionString = "Encrypt=false;SERVER=" + DatabaseServerHost + ";" + "DATABASE=" +
        DatabaseName + ";" + "UID=" + DatabaseUser + ";" + "PASSWORD=" + DatabasePassword + ";";
        #endregion

        #region Lists / arrays
        // Lista care exista pe server, cand cautam noi melodii
        List<MusicFile> ServerMusicFiles = new List<MusicFile>();

        // Lista care exista la noi si din care putem da play
        List<MusicFile> LocalMusicFiles = new List<MusicFile>();
        #endregion
        #endregion

        #region Constructor & Initialization
        public Form1()
        {
            InitializeComponent();
            
            openFileDialog1.Multiselect = true;
            LoginForm _loginForm = new LoginForm(ConnectionString, this);
            _loginForm.ShowDialog();
        }
        #endregion

        #region Music player
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach(string filename in openFileDialog1.FileNames)
                {
                    MusicFile _musicFile = new MusicFile(GenerateLocalID(), filename);
                    listBoxLocalMusicFiles.Items.Add(_musicFile.ID + ". " + _musicFile.SafeFileName);
                    LocalMusicFiles.Add(_musicFile);
                }

                listBoxLocalMusicFiles.SelectedIndex = listBoxLocalMusicFiles.Items.Count - 1;
            }
        }

        private void btnPlayStop_Click(object sender, EventArgs e)
        {
            if(btnPlayStop.Text == "Play")
            {
                if (listBoxLocalMusicFiles.SelectedIndex != -1)
                {
                    axWindowsMediaPlayer1.URL = GetSelectedMusicFile_LOCAL().FileName;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    label1.Text = "Now playing: " + axWindowsMediaPlayer1.currentMedia.name;
                    axWindowsMediaPlayer1.settings.volume = trackBarVolume.Value;
                }
            }
            else if(btnPlayStop.Text == "Stop")
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }


        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if(btnPauseResume.Text == "Pause")
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBarVolume.Value;
        }

        private void btnMuteUnmute_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.settings.mute == true)
            {
                axWindowsMediaPlayer1.settings.mute = false;
                btnMuteUnmute.Text = "Mute";
            }
            else 
            {
                axWindowsMediaPlayer1.settings.mute = true;
                btnMuteUnmute.Text = "Unmute";
            }
        }

        private void trackBarCurrentPosition_Scroll(object sender, EventArgs e)
        {
        }

        private void listBoxLocalMusicFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = GetSelectedMusicFile_LOCAL().FileName;
            label1.Text = "Now playing: " + axWindowsMediaPlayer1.currentMedia.name;
            axWindowsMediaPlayer1.settings.volume = trackBarVolume.Value;
        }

        private void axWindowsMediaPlayer1_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            double dur = axWindowsMediaPlayer1.currentMedia.duration;
            trackBarCurrentPosition.Maximum = Convert.ToInt32(dur);
        }

        private void trackBarCurrentPosition_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDownOnTrackbar = true;
        }

        private void trackBarCurrentPosition_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDownOnTrackbar = false;
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBarCurrentPosition.Value;
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                btnPlayStop.Text = "Play";
                btnPauseResume.Enabled = false;
            }
            else if(axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                btnPlayStop.Text = "Stop";
                btnPauseResume.Text = "Pause";
                btnPauseResume.Enabled = true;
            }
            else if(axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                btnPlayStop.Text = "Stop";
                btnPauseResume.Text = "Resume";
                btnPauseResume.Enabled = true;
            }
        }
        #endregion

        #region Server actions
        private void btnGetMusicList_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                
                string sql_query = "SELECT * FROM musicfiles";
                MySqlCommand command = new MySqlCommand(sql_query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MusicFile _musicFile = new MusicFile(int.Parse(reader["ID"].ToString()), reader["filename"].ToString());
               
                    listBoxServerMusicFiles.Items.Add(_musicFile.ID + ". " + _musicFile.SafeFileName);
                    ServerMusicFiles.Add(_musicFile);
                }


                connection.Close();
            }
        }

        private void btnDownloadSelected_Click(object sender, EventArgs e)
        {
            if (listBoxServerMusicFiles.SelectedIndex != -1)
            {
                MusicFile _musicFileToDownload = GetSelectedMusicFile_SERVER();
                string downloadLocation = Application.StartupPath + @"\Downloaded\" + _musicFileToDownload.FileName;
                if (File.Exists(downloadLocation))
                {
                    File.Delete(downloadLocation);
                }
                DownloadMusicFile(_musicFileToDownload, downloadLocation);

                ServerMusicFiles.Remove(_musicFileToDownload);
                listBoxServerMusicFiles.Items.RemoveAt(listBoxServerMusicFiles.SelectedIndex);

                _musicFileToDownload.ID = GenerateLocalID();
                _musicFileToDownload.FileName = downloadLocation;
                LocalMusicFiles.Add(_musicFileToDownload);

                listBoxLocalMusicFiles.Items.Add(_musicFileToDownload.ID.ToString() + ". " + _musicFileToDownload.SafeFileName);

                listBoxLocalMusicFiles.SelectedIndex = listBoxLocalMusicFiles.Items.Count - 1;
                // after downloading the music file, move it to the local list.

            }
            else
            {
                MessageBox.Show("Please select a music file to download!", "Selection required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion

        #region Helpfull methods
        private void DownloadMusicFile(MusicFile _musicFileToDownload, string downloadLocation)
        {
            string safeFileName = _musicFileToDownload.FileName.Split('/')[_musicFileToDownload.FileName.Split('/').Length - 1];
            string directoryPath = _musicFileToDownload.FileName.Replace(safeFileName, "");
            if (!Directory.Exists(Application.StartupPath + "\"" + directoryPath)) 
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Downloaded\\" + directoryPath);
            }

            string ftpPath = DatabaseServerHost + "/public_html/";
            string ftpFilePath = "/" + _musicFileToDownload.FileName;

            string ftpFullPath = "ftp://" + ftpPath + ftpFilePath;

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential(FTPUser, FTPPassword);
                byte[] fileData = request.DownloadData(ftpFullPath);

                using (FileStream file = File.Create(downloadLocation))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
            }
        }

        private int GenerateLocalID()
        {
            int _id = 1;
            while(LocalMusicFiles.Where(item => item.ID == _id).Count() > 0)
            {
                _id++;
            }

            return _id;
        }

        #endregion

        #region Shortcuts
        private MusicFile GetSelectedMusicFile_LOCAL()
        {
            return LocalMusicFiles.Where(item => item.ID == int.Parse(listBoxLocalMusicFiles.SelectedItem.ToString().Split('.')[0])).First();
        }

        private MusicFile GetSelectedMusicFile_SERVER()
        {
            return ServerMusicFiles.Where(item => item.ID == int.Parse(listBoxServerMusicFiles.SelectedItem.ToString().Split('.')[0])).First();
        }
        #endregion

        #region Form events
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            axWindowsMediaPlayer1.URL = string.Empty;
            axWindowsMediaPlayer1.Dispose();
            foreach(var directoryPath in Directory.GetDirectories(Application.StartupPath + @"\Downloaded"))
            {
                foreach(var file  in Directory.GetFiles(directoryPath))
                {
                    File.Delete(file);
                }
                Directory.Delete(directoryPath);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isMouseDownOnTrackbar == false)
            {
                trackBarCurrentPosition.Value = Convert.ToInt32(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
                int sec = trackBarCurrentPosition.Value;
                int trackbarToMinutes = sec / 60;
                sec = sec - (trackbarToMinutes * 60);
                if (trackbarToMinutes < 10)
                {
                    if (sec < 10)
                    {
                        label2.Text = "0" + trackbarToMinutes.ToString() + ":0" + sec.ToString();
                    }
                    else
                    {
                        label2.Text = "0" + trackbarToMinutes.ToString() + ":" + sec.ToString();
                    }
                }
                else
                {
                    if (sec < 10)
                    {
                        label2.Text =  trackbarToMinutes.ToString() + ":0" + sec.ToString();
                    }
                    else
                    {
                        label2.Text =  trackbarToMinutes.ToString() + ":" + sec.ToString();
                    }
                }
                if (checkBox1.Checked == true)
                {
                    if (trackBarCurrentPosition.Value == trackBarCurrentPosition.Maximum)
                    {
                        listBoxLocalMusicFiles.SelectedIndex++;
                    }
                }
                Random rand = new Random();
                if (checkBox2.Checked == true)
                {
                    if (trackBarCurrentPosition.Value == trackBarCurrentPosition.Maximum)
                    {
                        listBoxLocalMusicFiles.SelectedIndex = rand.Next(0, listBoxLocalMusicFiles.Items.Count - 1);   
                    }
                }

            }
        }
        #endregion
    }
}
