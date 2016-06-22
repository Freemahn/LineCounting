using System;
using System.IO;
using System.Text.RegularExpressions;
namespace LineCounting
{
    class LinesCounter
    {
        private static Regex onelineComment = new Regex("^\\s*//");
        private static Regex multilineCommentStart = new Regex("^\\s*/\\*");
        private static Regex multilineCommentEnd = new Regex("\\*/\\s*$");
        private static Regex emptyLine = new Regex("^\\s*$");

        static void Walk(string path)
        {
            foreach (string folder in Directory.GetDirectories(path))
            {
                Walk(folder);
            }        
            foreach (string filePath in Directory.GetFiles(path))
            {
                Count(filePath);        
            }
        }
        //asdasdsa


        /**
         * dfsdfsdf
         * */
        static void Count(string filepath)
        {
            FileInfo fi = new FileInfo(filepath);
            if (!fi.Extension.Equals(".cs"))
                return;
            int total_lines = 0;
            StreamReader reader = fi.OpenText();
            string line;
            bool commentBlock = false;
            while ((line = reader.ReadLine()) != null)
            {
                if (multilineCommentStart.IsMatch(line))
                    commentBlock = true;
                if (!(commentBlock) && (!emptyLine.IsMatch(line)) && !(onelineComment.IsMatch(line)))
                    total_lines++;
                if (multilineCommentEnd.IsMatch(line))
                    commentBlock = false;
            }
            Console.WriteLine("File " + filepath + " has "+ total_lines + " lines with code");
        }

        static void Main(string[] args)
        {
            string path = args[0];
            LinesCounter.Walk(path);
            Console.ReadKey();
        }
    }
}
