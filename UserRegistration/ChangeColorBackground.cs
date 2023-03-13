using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UserRegistration
{
    public class ChangeColorBackground
    {
        
        public ChangeColorBackground(Brush backgroundColor)
        {
            BackgroundColor = backgroundColor;
        }
        public static Brush BackgroundColor { get; set; }
        public static void ChangeColor(Brush color)
        {
            BackgroundColor = color;
        }
    }
}
