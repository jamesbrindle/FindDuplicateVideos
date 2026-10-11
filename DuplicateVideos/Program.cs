using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateVideos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> movies = Directory.GetDirectories("E:\\Videos\\Stand Up").ToList();
            var sb = new StringBuilder();

            foreach (var movie in movies)
            {
                List<string> files = Directory.GetFiles(movie, "*.avi").ToList();
                files.AddRange(Directory.GetFiles(movie, "*.mp4").ToList());
                files.AddRange(Directory.GetFiles(movie, "*.mkv").ToList());
                files.AddRange(Directory.GetFiles(movie, "*.ts").ToList());
                files.AddRange(Directory.GetFiles(movie, "*.m2ts").ToList());

                if (files.Count > 1)
                {
                    sb.AppendLine(movie);
                    Console.WriteLine(movie);
                }
            }

            File.WriteAllText(@"c:\temp\dups.txt", sb.ToString());
        }
    }
}
