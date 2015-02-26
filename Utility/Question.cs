using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    [Serializable]
    public class Question
    {
        public String ans { get; set; }
        public String question { get; set; }
        public string questionImage { get; set; }

        public Question()
        {
            question = null;
            ans = null;
            questionImage = null;
        }

        public Question(String _ans,String _question, String _questionImage)
        {
            ans = _ans;
            question = _question;
            questionImage = _questionImage;
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
        }
        
    }
}
