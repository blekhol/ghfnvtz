using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghfnvtz
{
    internal class Pixel
    {
        string backgroundColor;
        string foregroundColor;
        char character;

        public Pixel(string bgColor, string fgColor, char character)
        {
            this.backgroundColor = bgColor;
            this.foregroundColor = fgColor;
            this.character = character;
        }

        public string BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public string ForegroundColor { get => foregroundColor; set => foregroundColor = value; }
        public char Character { get => character; set => character = value; }

        public override string ToString()
        {
            return $"{backgroundColor}{foregroundColor}{character}\x1b[0m";
        }
    }
}
