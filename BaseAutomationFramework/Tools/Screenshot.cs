using BaseAutomationFramework.Tests;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using TestStack.White.UIItems;

namespace BaseAutomationFramework.Tools
{
	public class Screenshot
	{

        public static Bitmap TakeSS_OfControl(UIItem Control)
        {
            System.Windows.Rect rect = new Rect(Control.Bounds.BottomLeft, Control.Bounds.TopRight);

            int TLx = Convert.ToInt16(rect.TopLeft.X);
            int TLy = Convert.ToInt16(rect.TopLeft.Y);

            Bitmap SS = new Bitmap(Convert.ToInt16(rect.Width), Convert.ToInt16(rect.Height));

            Graphics graphics = Graphics.FromImage(SS as System.Drawing.Image);

            graphics.CopyFromScreen(TLx, TLy, 0, 0, SS.Size);

            return SS;
        }
        public static void TakeSS_OfControl(UIItem Control, string filename)
        {
            System.Windows.Rect rect = new Rect(Control.Bounds.BottomLeft, Control.Bounds.TopRight);

            int TLx = Convert.ToInt16(rect.TopLeft.X);
            int TLy = Convert.ToInt16(rect.TopLeft.Y);

            Bitmap printscreen = new Bitmap(Convert.ToInt16(rect.Width), Convert.ToInt16(rect.Height));

            Graphics graphics = Graphics.FromImage(printscreen as System.Drawing.Image);

            graphics.CopyFromScreen(TLx, TLy, 0, 0, printscreen.Size);
            string filePath = string.Format("C:\\Automation_Data\\{0}.jpg", filename);
            //logger.Debug("Taking Screenshot: {0}", filePath);
            printscreen.Save(filePath, ImageFormat.Jpeg);
            printscreen.Dispose();
        }
        public static Bitmap TakeSS_FullDesktop()
        {

            var Screen = System.Windows.Forms.Screen.PrimaryScreen;
            var size = Screen.Bounds.Size;
            System.Windows.Rect rect = new Rect(0, 0, size.Width, size.Height);
            //System.Windows.Rect rect = new Rect(Screen.Bounds.Bottom, Screen.Bounds.Right);

            int TLx = Convert.ToInt16(rect.TopLeft.X);
            int TLy = Convert.ToInt16(rect.TopLeft.Y);

            Bitmap SS = new Bitmap(Convert.ToInt16(rect.Width), Convert.ToInt16(rect.Height));

            Graphics graphics = Graphics.FromImage(SS as System.Drawing.Image);

            graphics.CopyFromScreen(TLx, TLy, 0, 0, SS.Size);

            return SS;
        }
        public static string TakeScreenShot(Bitmap SS, string FilePath_WithFileName)
        {

            string fullPath = string.Format("{0}.jpg", FilePath_WithFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            SS.Save(fullPath, ImageFormat.Jpeg);
            SS.Dispose();

            return fullPath;
        }
		public static string TakeScreenShot(Bitmap SS, string FileName, bool ExtentStep)
		{
			string fullPath = string.Format("{0}\\Screenshots\\{1}\\{2}.png", BaseTest.MasterData.TestResultPathStem, BaseTest.MasterData.TestID, FileName);
//			string fullPath = string.Format("{0}\\{1}\\{2}\\Screenshots\\{3}.png", BaseTest.MasterData.TestResultPathStem, BaseTest.MasterData.TestID, BaseTest.MasterData.TestDescription, FileName);
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

			using (FileStream stream = new FileStream(fullPath, FileMode.Create))
			{
				SS.Save(stream, ImageFormat.Png);
				SS.Dispose();
			}
			Console.WriteLine("Path of the screenshot: " + fullPath);

			return fullPath;
		}

	}
}
