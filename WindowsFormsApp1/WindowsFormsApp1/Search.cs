using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Collections;

namespace WindowsFormsApp1
{
    delegate void mach(string file, string found);
    class Search
    {
        private Object obj;
        private string[] arrSuffix = { "xml", "json" };
        public string[] arrSuffixChoose;
        string[] valueMemberToSearch;
        public event mach MatchFound;

        public string[] ArrSuffix
        {
            get { return arrSuffix; }
            set { arrSuffix = value; }
        }
        Type t;

        public Search(Object obj, string[] arrSuffixChoose)
        {
            this.obj = obj;
            this.arrSuffixChoose = arrSuffixChoose;
            t = obj.GetType();
            PropertyInfo[] memberToSearch = t.GetProperties().Where(m => m.GetCustomAttribute<IgnorSearchAttribute>()==null).ToArray();
            valueMemberToSearch = memberToSearch.Select(m => m.GetValue(obj).ToString()).ToArray();
        }
        public Boolean isWors(string f)
        {
            var q = arrSuffixChoose.FirstOrDefault(s => s.Equals(f.Split('.')[1]));
            if (q == null)
            {
                return false;
            }
            return true;
        }
        public void flatSearch(string path)
        {
            string[] arrFile = Directory.GetFiles(path);
            string[] arrFileSuffix = arrFile.Where(f => isWors(f)).ToArray();

            //string[] arrFileSuffi = arrFile.Where(f => arrSuffixChoose.Where(a => a.Equals(f));
            //(f.Split('.'))[1])
            for (int i = 0; i < arrFileSuffix.Length ; i++)
            {
                string[] thisFile = searchInFile(arrFileSuffix[i]);
                if (thisFile[1]!="")
                {
                    MatchFound(thisFile[0], thisFile[1]);
                }
            }
        }
        public void deepSearch(string path)
        {
            string[] arrFile = Directory.GetFiles(path);
            string[] arrFileSuffix = arrFile.Where(f => isWors(f)).ToArray();
            string[] arrDirectory = Directory.GetDirectories(path);
            for (int i = 0; i < arrFileSuffix.Length; i++)
            {
                string[] thisFile = searchInFile(arrFileSuffix[i]);
                if (thisFile[1] != "")
                {
                    MatchFound(thisFile[0], thisFile[1]);
                }
            }
            for (int i = 0; i < arrDirectory.Length; i++)
            {
                deepSearch(arrDirectory[i]);
            }
        }
        public string[] searchInFile(string pathFile)
        {
            StreamReader sr = new StreamReader(pathFile);
            string strFile = sr.ReadToEnd();
            string finds = "";
            for (int i = 0; i < valueMemberToSearch.Length; i++)
            {
                if (strFile.Contains(valueMemberToSearch[i].ToString())) {
                    finds += valueMemberToSearch[i];
                }
            }
            string[] arr = { strFile, finds };
            return arr;
        }

    }
}
