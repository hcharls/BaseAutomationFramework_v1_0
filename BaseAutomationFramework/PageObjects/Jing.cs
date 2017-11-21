using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects
{
	public class Jing : BaseScreen
	{
			public static Jing Initialize()
		{
			Thread.Sleep(500);
			return new Jing();
		}

		public void GetScreenshot()
		{
			Point Frame = new Point(460, 202);
			Point PropertyTaxes1 = new Point(963, 575);
			Point PropertyTaxes2 = new Point(1015, 600);
			Point FirstPayment1 = new Point(1357, 360);
			Point FirstPayment2 = new Point(1445, 395);
			Point TaxDueDate1 = new Point(1253, 429);
			Point TaxDueDate2 = new Point(1341, 484);
			Point Copy = new Point(641, 959);

			Mouse.Instance.Location = Frame;
			Mouse.Instance.Click(MouseButton.Left);
			Thread.Sleep(1000);

			//Mouse.Instance.Location = PropertyTaxes1;
			//Mouse.LeftDown();
			//Mouse.Instance.Location = PropertyTaxes2;
			//Mouse.LeftUp();
			//Thread.Sleep(1000);

			//Mouse.Instance.Location = FirstPayment1;
			//Mouse.LeftDown();
			//Mouse.Instance.Location = FirstPayment2;
			//Mouse.LeftUp();
			//Thread.Sleep(1000);

			//Mouse.Instance.Location = TaxDueDate1;
			//Mouse.LeftDown();
			//Mouse.Instance.Location = TaxDueDate2;
			//Mouse.LeftUp();
			//Thread.Sleep(1000);

			//Mouse.Instance.Location = Copy;
			//Mouse.LeftDown();
			//Mouse.LeftUp();

		}


	}
}