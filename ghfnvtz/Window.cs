using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghfnvtz
{
    internal class Window
    {
        private int width;
        private int height;

        public Window()
        {
        }

        public void Setup()
        {
            WindowSetup.SetFont((short)8, (short)8);
            
            width = Console.LargestWindowWidth;
            height = Console.LargestWindowHeight;
			Console.SetBufferSize(width, height);
            Console.SetWindowSize(width, height);
        }
    }
}
