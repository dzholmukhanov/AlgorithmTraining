using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.Helpers
{
    public class FastScanner : StreamReader
    {
        private string[] _line;
        private int _iterator;

        public FastScanner(Stream stream) : base(stream)
        {
            _line = null;
            _iterator = 0;
        }
        public string NextToken()
        {
            if (_line == null || _iterator >= _line.Length)
            {
                _line = base.ReadLine().Split(' ');
                _iterator = 0;
            }
            if (_line.Count() == 0) throw new IndexOutOfRangeException("Input string is empty");
            return _line[_iterator++];
        }
        public int NextInt()
        {
            return Convert.ToInt32(NextToken());
        }
        public long NextLong()
        {
            return Convert.ToInt64(NextToken());
        }
        public float NextFloat()
        {
            return float.Parse(NextToken());
        }
        public double NextDouble()
        {
            return Convert.ToDouble(NextToken());
        }
    }
} 