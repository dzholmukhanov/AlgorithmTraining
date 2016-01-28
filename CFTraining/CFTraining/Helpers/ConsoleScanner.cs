using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.Helpers
{
    class ConsoleScanner
    {
        private string[] _line;
        private int _iterator;

        public ConsoleScanner()
        {
            _line = null;
            _iterator = 0;
        }

        public int NextInt()
        {
            if (_line == null || _iterator >= _line.Length)
            {
                _line = Console.ReadLine().Split(' ');
                _iterator = 0;
            }
            if (_line.Count() == 0) throw new IndexOutOfRangeException("Input string is empty");
            return Convert.ToInt32(_line[_iterator++]);
        }
        public long NextLong()
        {
            if (_line == null || _iterator >= _line.Length)
            {
                _line = Console.ReadLine().Split(' ');
                _iterator = 0;
            }
            if (_line.Count() == 0) throw new IndexOutOfRangeException("Input string is empty");
            return Convert.ToInt64(_line[_iterator++]);
        }
        public int Read()
        {
            return Console.Read();
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
