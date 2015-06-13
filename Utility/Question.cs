using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    [Serializable]
    public class Question
    {
        public string ans { get; set; }
        public string question { get; set; }
        public string questionImage { get; set; }
        public int questionTime { get; set; }
        public string questionVideo { get; set; }
        public Question()
        {
            question = null;
            ans = null;
            questionImage = null;
            questionTime = 0;
            questionVideo = null;
        }

        public Question(String _ans,String _question, String _questionImage, int _questionTime)
        {
            ans = _ans;
            question = _question;
            questionImage = _questionImage;
            questionTime = _questionTime;
        }
        public Question(string line)
        {
            string[] words = line.Split('|');
            question = words[0];
            ans = words[1];
            try
            {
                questionImage = words[2];
            }
            catch (IndexOutOfRangeException ioore)
            {
                questionImage = null;
            }
            try
            {
                questionTime = Int32.Parse(words[3]);
            }
            catch (Exception ex){
                questionTime = 0;
            }
            try
            {
                questionVideo = words[4];
            }
            catch (IndexOutOfRangeException ioore)
            {
                questionVideo = null;
            }
        }
        
    }
}
