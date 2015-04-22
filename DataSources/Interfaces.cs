using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataSources
{

     class Common
    {

        public static int CountWords(string c1)
        {
            string sentence = c1;
            char[] chrArray = new char[] { ' ' };
            return sentence.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Count<string>();
        }


    }

     interface BaseCounterInterface
    {
        string Content
        {
            get;
            set;
        }

        int CountWords();
    }

     class FileCounterInterface : BaseCounterInterface
    {
        public string Content
        {
            get;
            set;
        }

        public FileCounterInterface(string s)
        {
            this.Content = File.ReadAllText(s);
        }

        public int CountWords()
        {
            return Common.CountWords(this.Content);
        }
    }

     interface IStringCounterInterface
    {
        int CountWords();
    }

 

     class StringCounterInterface : BaseCounterInterface
    {
        public string Content
        {
            get;
            set;
        }

        public StringCounterInterface(string s)
        {
            this.Content = s;
        }

        public int CountWords()
        {
            return Common.CountWords(this.Content);
        }
    }



     class URLCounterInterface : BaseCounterInterface
    {
        public string Content
        {
            get;
            set;
        }

        public URLCounterInterface(string s)
        {
            this.Content = this.download(s);
        }

        public int CountWords()
        {
            return Common.CountWords(this.Content);
        }

        private string download(string uri)
        {
            Stream data = (new WebClient()).OpenRead(uri);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return s;
        }
    }
}
