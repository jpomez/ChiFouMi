using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChiFouMi.Test.Tools
{
    public class CustomStringReader : StringReader
    {
        private readonly IEnumerable<string> strings;

        private int position;

        public CustomStringReader(string s)
            : base(s)
        {
        }

        public CustomStringReader(IEnumerable<string> strings)
            : base(strings.First())
        {
            this.strings = strings;
            this.position = 0;
        }

        public override string ReadLine()
        {
            var stringToReturn = this.strings.ElementAt(this.position);
            this.position++;
            if (this.position >= this.strings.Count())
            {
                this.position--;
            }

            return stringToReturn;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.strings) + Environment.NewLine;
        }
    }
}