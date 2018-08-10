using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BaseAutomationFramework.PageObjects
{
    static class RectExtensions
    {
        public static Point Center(this Rect bounds)
        {
            return new Point((bounds.Left + bounds.Right) / 2.0, (bounds.Top + bounds.Bottom) / 2.0);
        }
    }
}
