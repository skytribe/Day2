using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataSources
{
     class Counter
    {
        /// <summary>
        /// Takes a Uri type to point to file to get content
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountWords(Uri uri)
        {
            Debug.Assert(uri != null, "Web addresss provide is null");

            return this.CountWords(SourceType.url,uri.AbsoluteUri);
        }

        // Takes a direct string from user
        public int CountWords(string s)
        {
            Debug.Assert(s != null, "string provided is null");

            return this.CountWords(SourceType.randomstring, s);
        }

        /// <summary>
        /// Takes a fileinfo type to point to file to get content
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountWords(FileInfo fi)
        {
            Debug.Assert(fi != null, "fileinfo provided is null");

            return this.CountWords(SourceType.file, fi.FullName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountWords(SourceType type, string s)
        {
            int value1 = 0;

            // Quick exit condition
            if (string.IsNullOrEmpty(s))
                value1 = 0;
            else
            {
                switch (type)
                {
                        // All these call the common countWordsFromAString methods
                        // but have to obtain the string depending upon the type provided
                        // which indicates the data source.
                    case SourceType.randomstring:
                        {
                            value1 = countWordsFromAString(s);
                            break;
                        }
                    case SourceType.file:
                        {
                            if (File.Exists(s))
                            {
                                value1 = countWordsFromAString(File.ReadAllText(s));
                            }
                            break;
                        }
                    case SourceType.url:
                        {
                            value1 = countWordsFromAString(this.download(s));
                            break;
                        }
                }
                //Console.WriteLine(value1.ToString());
            }

            return value1;
        }

        /// <summary>
        /// Simple method to count words in a string.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        private int countWordsFromAString(string sentence)
        {
            char[] chrArray = new char[] { ' ' };
            return sentence.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Count<string>();
        }

        /// <summary>
        /// Download string from a uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
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
            catch 
            {
                Console.WriteLine("A problem occured trying to download the file.");
            }
            return s;
        }
    }
}
