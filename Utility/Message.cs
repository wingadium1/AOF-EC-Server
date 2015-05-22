using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    [Serializable]
    public class Message
    {
        
        public Question x { get; set; }
        public byte[] image { get; set; }
        public string imagename { get; set; }
        public Type type { get; set; }
        public string message { get; set; }
        public string IP { get; set; }
        public string name { get; set; }

        
        public Message(Type _type,Question _x,String _message,String _IP,String _name)
        {
            switch (_type){
                case Type.Quest:    x = _x;
                                    type = _type;
                                    IP = _IP;
                                    name = _name;
                                    if (null != _x.questionImage && _x.questionImage.CompareTo("")!=0)
                                    {
                                        type = Type.Quest;
                                        System.Drawing.Bitmap Image = new System.Drawing.Bitmap(System.IO.Directory.GetCurrentDirectory() + @"\Image\"+_x.questionImage);
                                        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                                        image = (byte[])converter.ConvertTo(Image, typeof(byte[]));
                                        imagename = _x.questionImage;
                                    }
                                    else
                                    {
                                        image = null;
                                        imagename = null;
                                    }
                                    break;
                default:            x = null;
                                    message = _message;
                                    type = _type;
                                    IP = _IP;
                                    name = _name;
                                    break;

            }
                
            
        }

        public enum Type
        {
            Hello,
            Quest,
            ShowAns,
            Ans,
            JoinSlot,
            LeaveSlot,
            Cnt
        }
    }
}
