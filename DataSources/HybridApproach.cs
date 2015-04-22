using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataSources
{

    //This approach uses a base class to eliminate extra common methods class 
    // or need to implement specific versions of CountWordsInString in each class
    // but also uses interfaces to ensure common contracts as all implementing classes
    // support this interface.

    /// <summary>
    /// Base functionality that all classes are required to implement.
    /// </summary>
     interface BaseCounterHybrid
    {
        string Content
        {
            get;
            set;
        }

        int CountWords();
    }

    /// <summary>
    /// Common Class which all methods inherit
    /// </summary>
    class BaseHybrid
    {
        public string Content
        {
            get;
            set;
        }
        public static int CountWordsInString(string c1)
        {
            string sentence = c1;
            char[] chrArray = new char[] { ' ' };
            return sentence.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Count<string>();
        }
    }

     class FileCounterHybrid : BaseHybrid, BaseCounterHybrid
    {


        public FileCounterHybrid(string s)
        {
            this.Content = File.ReadAllText(s);
        }

        public int CountWords()
        {
            return CountWordsInString(this.Content);
        }
    }

     interface IStringCounterHybrid
    {
        int CountWords();
    }

     enum SourceType
    {
        randomstring,
        file,
        url
    }


     class StringCounterHybrid : BaseHybrid, BaseCounterHybrid
    {

        public StringCounterHybrid(string s)
        {
            this.Content = s;
        }

        public int CountWords()
        {
            return CountWordsInString(this.Content);
        }
    }



     class URLCounterHybrid : BaseHybrid, BaseCounterHybrid
    {


        public URLCounterHybrid(string s)
        {
            this.Content = this.download(s);
        }

        public int CountWords()
        {
            return CountWordsInString(this.Content);
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
