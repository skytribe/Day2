using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataSources
{
     class BaseCounter
    {
        public string Content
        {
            get;
            set;
        }


        public int CountWords()
        {
            string sentence = this.Content;
            char[] chrArray = new char[] { ' ' };
            return sentence.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Count<string>();
        }
    }

     class StringCounter : BaseCounter
    {
        public StringCounter(string s)
        {            
            base.Content = s;
        }
    }

     class FileCounter : BaseCounter
    {
        public FileCounter(string s)
        {
            base.Content = File.ReadAllText(s);
        }
    }

     class URLCounter : BaseCounter
    {
        public URLCounter(string s)
        {
            base.Content = this.download(s);
        }

        private string download(string uri)
        {
            var s = "";
            try
            {
                Stream data = (new WebClient()).OpenRead(uri);
                StreamReader reader = new StreamReader(data);
                s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                

            }
            catch (Exception)
            {

                Console.WriteLine("A problem occured trying to download the web page.");
            }
            return s;
        }
    }

}
