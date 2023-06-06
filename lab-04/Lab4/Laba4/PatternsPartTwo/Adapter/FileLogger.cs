using PatternsPartTwo.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsPartTwo.Adapter
{
    internal class FileLogger : ILogger
    {
        public void Error()
        {
            ExplainLine("XD");
            FileWriter.WriteLine("An erorr occurred ");
            ExplainLine("XD");
        }

        private void ExplainLine(string line)
        {
            FileWriter.WriteLine($"\n-----------------------{line}-----------------------\n");
        }
        public void Log()
        {
            ExplainLine("XD");
            FileWriter.WriteLine("The best way to do this it`s....");
            ExplainLine("XD");
        }

        public void Warn()
        {
            ExplainLine("XD");
            FileWriter.WriteLine("An warning occurred");
            ExplainLine("XD");
        }
    }
}
