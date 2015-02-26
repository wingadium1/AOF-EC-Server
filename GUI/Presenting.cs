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
        public Presenting()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
        String[] namePlayer = new String[4];
        System.Collections.Generic.Dictionary<int, string> namePlayers = new System.Collections.Generic.Dictionary<int, string>();
        List<Socket> listClient = new List<Socket>();
        // question list
        List<Utility.Question> questionList = new List<Utility.Question>();
        // question file
        private string imageFolder = System.IO.Directory.GetCurrentDirectory() + @"\Image";
        private string questionFile = System.IO.Directory.GetCurrentDirectory() + @"\question.txt";
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
                //socket = listen.AcceptSocket();

                //add client
                socket = s.Accept();

                //Lưu máy khách được thêm vào danh sách. Để dễ quản lí
                listClient.Add(socket);
                //Thông báo kết nối với máy khách
                textBox1.Text = textBox1.Text + "a client has connected \r\n";


                //Mỗi máy khách sẽ được xử lí trong 1 luồng (thread)
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
                Utility.Message message = new Utility.Message(Utility.Message.Type.Hello, null, "Hello client, you connected with server " + IP + "\r\n",IP,"Server");
                byte[] buffer = MessageToByteArray(message);
                socket.Send(buffer);
            }
            

            //Mỗi máy khách được xử lý riêng trong 1 luồng (thread)
            thCommunications = new Thread((ThreadStart)(() =>
            {
                while (true)//Trong khi vẫn còn kết nối
                {
                    #region Nhận dữ liệu từ máy khách gửi đến

                    try
                    {
                        byte[] dlNhan = new byte[1048576];
                        socket.Receive(dlNhan);
                       // tmp = Encoding.Unicode.GetString(dlNhan);
                        Utility.Message reciveMessage = ByteArrayToMessage(dlNhan);
                        int slot = 0;
                        switch(reciveMessage.type)
                        {
                            case (Utility.Message.Type.JoinSlot):
                                textBox1.Text += "Player " + reciveMessage.name + "@" + reciveMessage.IP + 
                                                        " have joined at slot" + reciveMessage.message + "!!!!\r\n";
                                slot = Int32.Parse(reciveMessage.message);
                                //ListClientPlayer[slot-1] = socket;
                                namePlayers.Add(slot,reciveMessage.name);
                                namePlayer[slot-1] = reciveMessage.name;
                                lbClientPlayer.Items[slot - 1] = string.Format("[{0}]{1}", slot,namePlayer[slot-1]);
                                break;
                            case (Utility.Message.Type.Ans):
                                textBox1.Text += "Player " + reciveMessage.name + "@" + reciveMessage.IP +
                                                        " answered " + reciveMessage.message + "at" + timeLeft +  "!!!!\r\n";
                                foreach (KeyValuePair<int, string> pair in namePlayers)
                                {
                                    if (reciveMessage.name.Equals(pair.Value))
                                    {
                                        slot = pair.Key;
                                        lbClientPlayer.Items[slot - 1] = string.Format("[{0}]{1}:{2}", slot, namePlayer[slot - 1],reciveMessage.message);
                                    }
                                }
                                
                                SendData(reciveMessage);
                                break;
                        }
                        
                    }
                    catch (Exception er)
                    {
                        textBox1.Text += @"Lost connect to client\r\n";
                        textBox1.Text += er.Message + er.Source;
                        break;
                    }

                    #endregion

                    #region Xử lí dữ liệu nhận được: Nếu thỏa mãn thì gửi lại cho máy khách và có thể lưu vào CSDL

                    //Hiển thị dữ liệu nhận đc
                    //richTextBox1.Text = richTextBox1.Text + tmp;
                    //richTextBox1.Text = richTextBox1.Text + "\r\n";

                    
                    #endregion
                }
            }));
            thCommunications.IsBackground = true;//Khi thoát sẽ tự đóng thread luôn
            thCommunications.Start();
        }

        /// <summary>
        /// Gửi dữ liệu đến máy khách
        /// </summary>
        /// <param name="data">Nội dung cần gửi</param>
        /// <param name="client">Socket của máy khách. Được tạo ra trong KetNoiTaoServer()</param>
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
            questionList = getQuestionFromFile(questionFile);
            foreach (Utility.Question q in questionList)
            {

                lbQuestion.Items.Add(string.Format("[{0}]", q.question));
            }
            lbQuestion.SelectedIndex = 0;
            labelQuest.Text = "";
            labelAns.Text = "";
            labelTimer.Text = "00:00";

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
            if (null != q.questionImage)
            {
                ShowImage(imageFolder + @"\" + q.questionImage, 240, 160, pictureBox2);
            }
            else
            {
                pictureBox2.Image = null;
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
            Utility.Message sendQuest = new Utility.Message(Utility.Message.Type.Quest, q, "question", IP, "Server");
            foreach (Socket s in listClient)
            {
                s.Send(MessageToByteArray(sendQuest));
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            int id = lbQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            Utility.Question q = questionList[id];
            sendQuestion(q);
            labelQuest.Text = q.question;
            labelAns.Text = q.ans;
            btnShow.Enabled = false;
            if (null != q.questionImage)
            {
                ShowImage(imageFolder + @"\" + q.questionImage, 200, 150, pictureBox1);
            }
            else
            {
                pictureBox2.Image = null;
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
            
            StartTheQuestion();
        }
        


        private void StartTheQuestion()
        {
            timeLeft = 100;
            labelTimer.Text = "10''00";
            timerCountDown.Interval = 100;
            timerCountDown.Start();


        }

        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Display the new time left 
                // by updating the Time Left label.
                timeLeft -= 1;
                labelTimer.Text = String.Format("{0}''{1}", timeLeft/10 , (timeLeft % 10));
            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timerCountDown.Stop();
                labelTimer.Text = "Time's up!";
                // MessageBox.Show("Time's up");
                btnShow.Enabled = true;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Utility.Message showAns = new Utility.Message(Utility.Message.Type.ShowAns,null , "", IP, "Server");
            foreach (Socket s in listClient)
            {
                s.Send(MessageToByteArray(showAns));
            }
        }

    }
}
