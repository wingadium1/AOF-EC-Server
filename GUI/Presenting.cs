using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    public partial class Presenting : Form
    {
        private string videoFolder = System.IO.Directory.GetCurrentDirectory() + @"\Video";
        public Presenting()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            comboBox1.Items.AddRange(new object[] { "Stage 1", "Stage 2", "Stage 3" });
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Stage 1");
            Loading();
        }

        private void lbClientPresenter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        #region Variable
        //default address
        string IP = null; // not init default IP, it depends on IP of machine
        int PORT = 2505; // default port

        //thread
        Thread thConnectToServer, thConnectCreateServer, thCommunications;
        System.Net.Sockets.TcpListener listen;

        // I/O data
        byte[] outputData = new byte[1024];
        byte[] inputData = new byte[1024];

        //Socket create Server and Connection
        Socket socket;
        //Create a socket
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //List of 2 types of client
        //Socket[] ListClientPlayer = new Socket[4];
        String[] namePlayer = new String[5];
        System.Collections.Generic.Dictionary<int, string> namePlayers = new System.Collections.Generic.Dictionary<int, string>();
        List<Socket> listClient = new List<Socket>();
        // question list
        List<Utility.Question> questionList = new List<Utility.Question>();
        // question file
        private string imageFolder = System.IO.Directory.GetCurrentDirectory() + @"\Image";
        private string questionFileFolder = System.IO.Directory.GetCurrentDirectory();
        //question timer
        int timeLeft;
        #endregion
        #region Function and procedure

        /// <summary>
        /// Procedure create server and setup connect with client when have a connection
        /// </summary>
        private void ConnectCreateServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);//IP = Local IP address; PORT = 2505;
            //link port of socket s with IP address and PORT
            s.Bind(iep);
            //Listen for connection
            s.Listen(10);

            #region way 2
            /*listen = new TcpListener(IPAddress.Parse(IP), PORT);
            listen.Start();*/
            #endregion

            //while server is working, each time there is a signal from client, add client to list
            while (true)
            {
                socket = s.Accept();
                listClient.Add(socket);
                textBox1.Text = textBox1.Text + "a client has connected \r\n";
                ThreadPool.QueueUserWorkItem(Communications, socket);

            }
        }

        /// <summary>
        /// Tạo mới xử lí việc kết nối, gửi, nhận dữ liệu từ máy khách
        /// </summary>
        /// <param name="obj">Socket được tạo cho máy khách trong KetNoiTaoServer()</param>
        private void Communications(object obj)
        {
            var socket = (Socket)obj;
            //dem = cacMay.Count;

            //Thông báo kết nối thành công đến máy khách kết nối
            {
                Utility.Message message = new Utility.Message(Utility.Message.Type.Hello, null, "Hello client, you connected with server " + IP + "\r\n", IP, "Server", checkBox1.Checked);
                byte[] buffer = MessageToByteArray(message);
                socket.Send(buffer);
            }
            thCommunications = new Thread((ThreadStart)(() =>
            {
                while (true)
                {
                    #region Nhận dữ liệu từ máy khách gửi đến
                    
                    try
                    {
                        int slot = 0;
                        byte[] dlNhan = new byte[1048576];
                        socket.Receive(dlNhan);
                        Utility.Message reciveMessage = ByteArrayToMessage(dlNhan);
                        
                        switch(reciveMessage.type)
                        {
                            case (Utility.Message.Type.JoinSlot):
                                textBox1.Text += "Player " + reciveMessage.name + "@" + reciveMessage.IP + 
                                                        " have joined at slot" + reciveMessage.message + "!!!!\r\n";
                                slot = Int32.Parse(reciveMessage.message);
                                namePlayers.Add(slot,reciveMessage.name);
                                namePlayer[slot-1] = reciveMessage.name;
                                lbClientPlayer.Items[slot - 1] = string.Format("[{0}]{1}", slot,namePlayer[slot-1]);
                                break;
                            case (Utility.Message.Type.Ans):

                                SendData(reciveMessage);
                                textBox1.Text += "Player " + reciveMessage.name + "@" + reciveMessage.IP +
                                                        " answered " + reciveMessage.message + "at" + timeLeft +  "!!!!\r\n";
                                int time = timeLeft;
                                timeLeft = 0;
                                labelTimer.Text = String.Format("{0}''{1}", time / 10, (time % 10));
                                foreach (KeyValuePair<int, string> pair in namePlayers)
                                {
                                    if (reciveMessage.name.Equals(pair.Value))
                                    {
                                        slot = pair.Key;
                                        lbClientPlayer.Items[slot - 1] = string.Format("[{0}]{1}:{2}", slot, namePlayer[slot - 1],reciveMessage.message);
                                    }
                                }
                                
                                
                                using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Directory.GetCurrentDirectory() + @"\OldPhone.wav"))
                                {
                                    player.PlaySync();
                                }
                                                             
                                break;
                        }
                        
                    }
                    catch (Exception er)
                    {
                        textBox1.Text += @"Lost connect to client\r\n";
                        listClient.Remove(socket);
                        Console.WriteLine("ereeeeeeeeeeeeeeeeeee" + listClient.Count);
                        thCommunications.Abort();
                        
                        break;
                    }
                    #endregion
                }
            }));
            thCommunications.IsBackground = true;//Khi thoát sẽ tự đóng thread luôn
            thCommunications.Start();
        }

        
        private void SendData(string data, Socket client)
        {
            try
            {
                //outputData = Encoding.Unicode.GetBytes(data);
                //client.Send(outputData);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Gửi dữ liệu đến máy khách
        /// </summary>
        /// <param name="data">Nội dung cần gửi</param>
        /// <param name="id">Máy khách thứ i được lưu lại trong list cacMay sau khi kết nối</param>
        private void SendData(Utility.Message data, int id)
        {
            try
            {
                //outputData = Encoding.Unicode.GetBytes(data);
                //listClient[id].Send(outputData);
            }
            catch
            {
            }
        }

        /// <summary>
        /// send data to all client
        /// </summary>
        /// <param name="data"></param>
        private void SendData(Utility.Message data)
        {
            foreach (Socket s in listClient)
            {
                try
                {
                    System.IO.MemoryStream fs = new System.IO.MemoryStream();
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    formatter.Serialize(fs, data);
                    byte[] buffer = fs.ToArray();
                    s.Send(buffer);
                }
                catch (Exception er)
                {
                    textBox1.Text = textBox1.Text + er.Message + "\r\n";
                    listClient.Remove(s);
                    s.Close();
                }
            }
        }

        private byte[] MessageToByteArray(Utility.Message message)
        {
            System.IO.MemoryStream fs = new System.IO.MemoryStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(fs, message);
            return fs.ToArray();
        }

        private static Utility.Message ByteArrayToMessage(byte[] arrBytes)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            ms.Write(arrBytes, 0, arrBytes.Length);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            Utility.Message reciveMessage = (Utility.Message)formatter.Deserialize(ms);
            return reciveMessage;
        }


        /// <summary>
        /// Luồng cho tạo kết nối
        /// </summary>
        private void ConnectToServer()
        {
            thConnectToServer = new Thread(ConnectCreateServer);
            thConnectToServer.IsBackground = true;
            thConnectToServer.Start();
        }

    

        #endregion
        private void Loading()
        {
            loadQuestion();
            IP = LocalIPAddress();
            labelInfo.Text = "Server address " + LocalIPAddress() + ":" + PORT + " is not running";


        }

        private string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            btnStartServer.Enabled = false;
            try
            {
                IP = LocalIPAddress(); PORT = 2505;

                thConnectToServer = new Thread(ConnectToServer);
                thConnectToServer.IsBackground = true;
                thConnectToServer.Start();

                //Thông báo đã khởi tạo đc server
                textBox1.Text += "Server " + IP + " was created " + "\r\n";
                labelInfo.Text = "Server address " + LocalIPAddress() + ":" + PORT + " is running";


                lbClientPlayer.Items.Add(string.Format("[{0}]", "Slot1"));
                lbClientPlayer.Items.Add(string.Format("[{0}]", "Slot2"));
                lbClientPlayer.Items.Add(string.Format("[{0}]", "Slot3"));
                lbClientPlayer.Items.Add(string.Format("[{0}]", "Slot4"));
                lbClientPlayer.Items.Add(string.Format("[{0}]", "Slot5"));


            }
            catch (Exception er)
            {
                //Thông báo tạo lỗi
                MessageBox.Show(er.Message);
                textBox1.Text += "Server " + IP + " hadnot created " + er.Message + "\r\n";
                btnStartServer.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void loadQuestion()
        {
            lbFile.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(questionFileFolder);

            foreach (var file in d.GetFiles("*.txt"))
            {
                lbFile.Items.Add(file);
            }

            lbFile.SelectedIndex = 0;


        }
        public static List<Utility.Question> getQuestionFromFile(String _questionFile)
        {
            try
            {
                List<Utility.Question> rt = new List<Utility.Question>();
                string[] lines = System.IO.File.ReadAllLines(_questionFile);
                foreach (var i in lines)
                {
                    rt.Add(new Utility.Question(i));
                }
                return rt;
            }
            catch (IOException ex)
            {
                return null;
            }

        }

        private void lbQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = lbQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            Utility.Question q = questionList[id];
            lbQuestionNext.Text = q.question;
            labelAnsNext.Text = q.ans;
            if (null != q.questionImage && q.questionImage.CompareTo("") != 0)
            {
                ShowImage(imageFolder + @"\" + q.questionImage, 240, 160, pictureBox2);
            }
            else
            {
                pictureBox2.Image = null;
            }
            if (null != q.questionVideo && q.questionVideo.CompareTo("") != 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private void ShowImage(String fileToDisplay, int xSize, int ySize, PictureBox pictureBox)
        {
            // Sets up an image object to be displayed. 
            Bitmap Image = null;
            if (null != Image)
            {
                Image.Dispose();
            }

            // Stretches the image to fit the pictureBox.
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Image = new Bitmap(fileToDisplay);
            pictureBox.ClientSize = new Size(xSize, ySize);
            pictureBox.Image = (Image)Image;
        }

        private void sendQuestion(Utility.Question q)
        {
            Utility.Message sendQuest = new Utility.Message(Utility.Message.Type.Quest, q, "question", IP, "Server", checkBox1.Checked);
            foreach (Socket s in listClient)
            {
                try{
                s.Send(MessageToByteArray(sendQuest));
                }
                catch (Exception er)
                {
                    textBox1.Text = textBox1.Text + er.Message + "\r\n";
                    s.Close();
                }
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            timerCountDown.Enabled = true;
            int id = lbQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            Utility.Question q = questionList[id];
            sendQuestion(q);
            labelQuest.Text = q.question;
            labelAns.Text = q.ans;
            if (null != q.questionImage && q.questionImage.CompareTo("") != 0)
            {
                ShowImage(imageFolder + @"\" + q.questionImage, 200, 150, pictureBox1);
            }
            else
            {
                pictureBox1.Image = null;
            }


            if (id + 1 != questionList.Count)
            {
                lbQuestion.SelectedIndex = id + 1;
            }
            else
            {
                lbQuestionNext.Text = "";
                pictureBox2.Image = null;
                labelAnsNext.Text = "";
            }
            if (checkBox1.Checked)
            {
                StartTheQuestion(q.questionTime);
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0: checkBox1.Checked = false;
                    break;
            }
            
        }
        


        private void StartTheQuestion(int _time)
        {
            timeLeft = _time*10;
            labelTimer.Text = String.Format("{0}''00",_time);
            timerCountDown.Interval = 100;
            timerCountDown.Start();


        }

        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft -= 1;
                labelTimer.Text = String.Format("{0}''{1}", timeLeft/10 , (timeLeft % 10));
            }
            else
            {
                btnShow.Enabled = true;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Utility.Message showAns = new Utility.Message(Utility.Message.Type.ShowAns, null, "", IP, "Server", checkBox1.Checked);
            foreach (Socket s in listClient)
            {
                try
                {
                    s.Send(MessageToByteArray(showAns));
                }
                catch (Exception er)
                {
                    textBox1.Text = textBox1.Text + er.Message + "\r\n";
                    s.Close();
                }
            }
        }

        private void buttonCnt_Click(object sender, EventArgs e)
        {
            Utility.Message sendContinue = new Utility.Message(Utility.Message.Type.Cnt, null, "cnt", IP, "Server", checkBox1.Checked);
            foreach (Socket s in listClient)
            {
                try
                {
                    s.Send(MessageToByteArray(sendContinue));
                }
                catch (Exception er)
                {
                    textBox1.Text = textBox1.Text + er.Message + "\r\n";
                    s.Close();
                }
            }
        }

        private void lbFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbQuestion.Items.Clear();
            int id = lbFile.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            questionList = getQuestionFromFile(questionFileFolder+"\\"+lbFile.SelectedItem.ToString());
            foreach (Utility.Question q in questionList)
            {
                lbQuestion.Items.Add(string.Format("[{0}]", q.question));
            }
            lbQuestion.SelectedIndex = 0;
            labelQuest.Text = "";
            labelAns.Text = "";
            labelTimer.Text = "00:00";
            combox1_setIndex();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            combox1_setIndex();
            
        }

        private void combox1_setIndex()
        {
            int id = comboBox1.SelectedIndex;
            if (id < 0)
            {
                return;
            }

            switch (id)
            {
                case 0: checkBox1.Checked = true;
                    break;
                case 1: checkBox1.Checked = true;
                    break;
                case 2: checkBox1.Checked = false;
                    break;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnCount.Enabled = (checkBox1.Checked) ? false : true;
        }

        private void labelTimer_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = lbQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            Utility.Question q = questionList[id];
            var playForm = new Utility.Form1(videoFolder + @"\" + q.questionVideo);
            playForm.Show();


            Utility.Message sendPlay = new Utility.Message(Utility.Message.Type.PlayVideo, null, q.questionVideo, IP, "Server", checkBox1.Checked);
            foreach (Socket s in listClient)
            {
                try
                {
                    s.Send(MessageToByteArray(sendPlay));
                }
                catch (Exception er)
                {
                    textBox1.Text = textBox1.Text + er.Message + "\r\n";
                    s.Close();
                }
            }
        }
    }
}
