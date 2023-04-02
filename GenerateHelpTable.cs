using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public static class GenerateHelpTable
    {
        static int tableWidth = 89;

        public static void CreateTable(string[] args)
        {
            const string WIN = "WIN";
            const string LOSE = "LOSE";
            const string DRAW = "DRAW";

            var header = new List<string>();

            header.Add("");
            header.AddRange(args);

            var headerArray = header.ToArray();

            PrintLine();
            PrintRow(headerArray);
            PrintLine();

            string[][] resultArr = new string[args.Length][];

            int half = (args.Length - 1) / 2;

            for (var i = 0; i < args.Length; i++)
            {
                var row = new List<string>();
                row.Add(args[i]);

                var inner = new string[args.Length];
                resultArr[i] = inner;
              
                for (var j = 0; j < args.Length; j++)
                {                
                    if (i == j)
                    {                       
                        inner[j] = DRAW;
                    }    
                    else if ((j > i && j <= i + half) || (j < i && i > j + half))
                    {                   
                        inner[j] = WIN;
                    }
                    else
                    {
                        inner[j] = LOSE;
                    }
                }

                row.AddRange(inner);
                PrintRow(row.ToArray());
            }

            PrintLine();
        }
  
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }   
}
