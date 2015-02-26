using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace GUI
{
    public partial class Question_Management : Form
    {

        private string imageFolder = System.IO.Directory.GetCurrentDirectory() + @"\Image";
        private string questionFile = System.IO.Directory.GetCurrentDirectory() + @"\question.txt";
        List<Utility.Question> questionList = new List<Utility.Question>();
        public Question_Management()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = listBoxQuestion.SelectedIndex;
            if (id <= 0)
            {
                return;
            }
            Swap<Utility.Question>(questionList, id, id - 1);
            listBoxQuestion.Items[id] = string.Format("[{0}]", questionList[id].question);
            listBoxQuestion.Items[id-1] = string.Format("[{0}]", questionList[id-1].question);
            listBoxQuestion.SelectedIndex = id - 1;

        }

        private static void Swap<T>(List<T> list,int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            saveQuestionToFile(questionFile, questionList);
        }

        private void Question_Management_Load(object sender, EventArgs e)
        {
            Loading();
        }

        private void CreateIfNotExit()
        {
            if (!System.IO.Directory.Exists(imageFolder))
            {
                System.IO.Directory.CreateDirectory(imageFolder);
            }
            if (!System.IO.File.Exists(questionFile))
            {
               // System.IO.File.Create(questionFile);
                System.IO.File.AppendAllText(questionFile, "The very first question|The very first answer");
            }
        }
        private void Loading()
        {
            CreateIfNotExit();
            questionList = getQuestionFromFile(questionFile);
            foreach (Utility.Question q in questionList)
            {

                listBoxQuestion.Items.Add(string.Format("[{0}]", q.question));
            }
            listBoxQuestion.SelectedIndex = questionList.Count - 1;

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

        private void tbAns_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = listBoxQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            Utility.Question q = questionList[id];
            tbQuestionText.Text = q.question;
            tbAns.Text = q.ans;
            if (null != q.questionImage)
            {
                ShowImage(imageFolder + @"\" + q.questionImage, 320, 240,pictureBox1);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void ShowImage(String fileToDisplay, int xSize, int ySize,PictureBox pictureBox)
        {
            // Sets up an image object to be displayed. 
            Bitmap Image = null;
            if (null!=Image)
            {
                Image.Dispose();
            }

            // Stretches the image to fit the pictureBox.
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Image = new Bitmap(fileToDisplay);
            pictureBox.ClientSize = new Size(xSize, ySize);
            pictureBox.Image = (Image)Image;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = imageFolder;
            OFD.RestoreDirectory = true;
            OFD.Title = "Browse Image Files";
            OFD.Filter = "";

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                OFD.Filter = String.Format("{0}{1}{2} ({3})|{3}", OFD.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            OFD.Filter = String.Format("{0}{1}{2} ({3})|{3}", OFD.Filter, sep, "All Files", "*.*");


            DialogResult result = OFD.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string fullname = OFD.FileName;
                string filename = System.IO.Path.GetFileName(fullname);
                try
                {
                    System.IO.File.Copy(fullname, imageFolder + @"\" + filename, true);
                    
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    int id = listBoxQuestion.SelectedIndex;
                    Utility.Question q = questionList[id];
                    q.questionImage = filename;
                    ShowImage(imageFolder + @"\" + q.questionImage, 360, 240,pictureBox1);
                }
            }
            
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = listBoxQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            Utility.Question q = questionList[id];
            q.questionImage = null;
            pictureBox1.Image = null;
        }

        private void tbQuestionText_Leave(object sender, EventArgs e)
        {
            int id = listBoxQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            Utility.Question q = questionList[id];
            q.question = tbQuestionText.Text;
            listBoxQuestion.Items[id] = string.Format("[{0}]", q.question);
        }

        private void tbAns_Leave(object sender, EventArgs e)
        {
            int id = listBoxQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            Utility.Question q = questionList[id];
            q.ans = tbAns.Text;
        }

        private void btnNewQuestion_Click(object sender, EventArgs e)
        {
            Utility.Question newQuest = new Utility.Question();
            questionList.Add(newQuest);
            listBoxQuestion.Items.Add(string.Format("[{0}]", "NULL"));
            listBoxQuestion.SelectedIndex = questionList.Count - 1;
        }

        private static void saveQuestionToFile(String _questionFile,List<Utility.Question> _listquest)
        {
            string[] lines = new string[_listquest.Count];
            foreach (var quest in _listquest)
            {
                lines[_listquest.IndexOf(quest)] = quest.question + "|" + quest.ans + "|" + quest.questionImage;
            }

            System.IO.File.WriteAllLines(_questionFile, lines);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = listBoxQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            listBoxQuestion.Items.RemoveAt(id);
            questionList.RemoveAt(id);
            listBoxQuestion.SelectedIndex = questionList.Count - 1;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            int id = listBoxQuestion.SelectedIndex;
            if (id < 0)
            {
                return;
            }
            if (id == questionList.Count - 1)
            {
                return;
            }
            Swap<Utility.Question>(questionList, id, id + 1);
            listBoxQuestion.Items[id] = string.Format("[{0}]", questionList[id].question);
            listBoxQuestion.Items[id + 1] = string.Format("[{0}]", questionList[id + 1].question);
            listBoxQuestion.SelectedIndex = id + 1;
        }


    }
}
