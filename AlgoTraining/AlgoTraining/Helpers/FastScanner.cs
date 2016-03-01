﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining.Helpers
{
    class FastScanner : StreamReader
    {
        private string[] _line;
        private int _iterator;

        public FastScanner(Stream stream) : base(stream)
        {
            _line = null;
            _iterator = 0;
        }
        public int NextInt()
        {
            if (_line == null || _iterator >= _line.Length)
            {
                _line = base.ReadLine().Split(' ');
                _iterator = 0;
            }
            if (_line.Count() == 0) throw new IndexOutOfRangeException("Input string is empty");
            return Convert.ToInt32(_line[_iterator++]);
        }
        public long NextLong()
        {
            if (_line == null || _iterator >= _line.Length)
            {
                _line = base.ReadLine().Split(' ');
                _iterator = 0;
            }
            if (_line.Count() == 0) throw new IndexOutOfRangeException("Input string is empty");
            return Convert.ToInt64(_line[_iterator++]);
        }
    }
}