using System;
using System.IO;
using System.Linq;

namespace DotNetAdv.ArielClass.DirectoryAndFiles1
{
    class Program
    {
        static void Main(string[] args)
        {

            Directory.CreateDirectory(@"D:\Daniel");
            File.Create(@"D:\Daniel\a.csv");
            var arr = Directory.GetLogicalDrives(); // מחזיר את התתיקיות שיש במחשב שלי 
            var arr1 = Directory.GetDirectories(@"c:\"); // יוציא את רשימת התיקיות מכונן הנבחר (c)
            foreach (var item in arr1.Take(10))
            {
                Console.WriteLine(item);
            }
            FileInfo fileInfo = new FileInfo(@"D:\Daniel\a.csv");
            var sw = fileInfo.AppendText();
            for (int i = 0; i < 1000; i++)
            {
                sw.WriteLine("Line " + i++.ToString());
            }
            sw.Close();
            sw.Dispose(); // הדיספוס כבר עושה את הסגירה ולכן הקלואס מיותר 
            var streamWriter = new StreamWriter(@"D:\Daniel\a.csv");
            using (streamWriter)
            {
                for (int i = 0; i < 1000; i++)
                {
                    streamWriter.WriteLine(i++.ToString());
                }
            }
            var streamReader = new StreamReader(@"\Daniel\a.csv", true);
            using (streamReader)
            {
                string line = string.Empty;
                while (line != null)
                {
                    line = streamReader.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }
    }
}
