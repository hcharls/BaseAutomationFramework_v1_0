using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class Itemization : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public Itemization()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static Itemization OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("2015 Itemization");
				Thread.Sleep(10000);

			return new Itemization();
		}

		public static Itemization Initialize()
		{
			return new Itemization();
		}

		private PropertyCondition btn_ScrollDown1100 = new PropertyCondition(AutomationElement.NameProperty, "700. Total Sales / Brokers Commission");
		private PropertyCondition btn_ScrollUp900 = new PropertyCondition(AutomationElement.NameProperty, "1000. Reserves Deposited with Lender");

		public Itemization btn_ScrollDownToAppraisal_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ScrollDown1100);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(300);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Thread.Sleep(3000);

			return this;
		}

		public Itemization btn_ScrollUp900_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ScrollUp900);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(300);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.UP);
			Thread.Sleep(3000);

			return this;
		}

		public Itemization btn_ScrollDown1100_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ScrollDown1100);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(300);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);

			return this;
		}

		#region Buttons

		private PropertyCondition btn_AggregateSetup = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button12");
		private PropertyCondition btn_PropertyTaxes = new PropertyCondition(AutomationElement.AutomationIdProperty, "StandardButton6");

		public Itemization btn_AggregateSetup_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_AggregateSetup);
			aElement.ClickCenterOfBounds();

			return new Itemization();
		}
		public Itemization btn_PropertyTaxes_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_PropertyTaxes);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(5000);

			return new Itemization();
		}

		#endregion

		#region Text Boxes

		private PropertyCondition txt_PropertyTaxesMths = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox658");

		public Itemization txt_PropertyTaxesMths_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PropertyTaxesMths);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(4000);

			return this;
		}

		#endregion

		#region Fee Detail Windows

		private PropertyCondition btn_line701 = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton19");
		private PropertyCondition btn_line702 = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton20");
		private PropertyCondition btn_line704 = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton18");
		private PropertyCondition btn_line801a = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801a");
		private PropertyCondition btn_line801b = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801b");
		private PropertyCondition btn_line801c = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801c");
		private PropertyCondition btn_line801d = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801d");
		private PropertyCondition btn_line801e = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801e");
		private PropertyCondition btn_line801f = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801f");
		private PropertyCondition btn_line801g = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801g");
		private PropertyCondition btn_line801h = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801h");
		private PropertyCondition btn_line801i = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801i");
		private PropertyCondition btn_line801j = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801j");
		private PropertyCondition btn_line801k = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801k");
		private PropertyCondition btn_line801l = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801l");
		private PropertyCondition btn_line801m = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801m");
		private PropertyCondition btn_line801n = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801n");
		private PropertyCondition btn_line801o = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801o");
		private PropertyCondition btn_line801p = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801p");
		private PropertyCondition btn_line801q = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801q");
		private PropertyCondition btn_line801r = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop801r");
		private PropertyCondition btn_line802 = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton1");
		private PropertyCondition btn_line802e = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton5");
		private PropertyCondition btn_line802f = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton6");
		private PropertyCondition btn_line802g = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton7");
		private PropertyCondition btn_line802h = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton8");
		private PropertyCondition btn_line803 = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton9");
		private PropertyCondition btn_line804 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop804");
		private PropertyCondition btn_line805 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop805");
		private PropertyCondition btn_line806 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop806");
		private PropertyCondition btn_line807 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop807");
		private PropertyCondition btn_line808 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop808");
		private PropertyCondition btn_line809 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop809");
		private PropertyCondition btn_line810 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop810");
		private PropertyCondition btn_line811 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop811");
		private PropertyCondition btn_line812 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop812");
		private PropertyCondition btn_line813 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop813");
		private PropertyCondition btn_line814 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop814");
		private PropertyCondition btn_line815 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop815");
		private PropertyCondition btn_line816 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop816");
		private PropertyCondition btn_line817 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop817");
		private PropertyCondition btn_line818 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop818");
		private PropertyCondition btn_line819 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop819");
		private PropertyCondition btn_line820 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop820");
		private PropertyCondition btn_line821 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop821");
		private PropertyCondition btn_line822 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop822");
		private PropertyCondition btn_line823 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop823");
		private PropertyCondition btn_line824 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop824");
		private PropertyCondition btn_line825 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop825");
		private PropertyCondition btn_line826 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop826");
		private PropertyCondition btn_line827 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop827");
		private PropertyCondition btn_line828 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop828");
		private PropertyCondition btn_line829 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop829");
		private PropertyCondition btn_line830 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop830");
		private PropertyCondition btn_line831 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop831");
		private PropertyCondition btn_line832 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop832");
		private PropertyCondition btn_line833 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop833");
		private PropertyCondition btn_line834 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop834");
		private PropertyCondition btn_line835 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop835");
		private PropertyCondition btn_line901 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop901");
		private PropertyCondition btn_line902 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop902");
		private PropertyCondition btn_line903 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop903");
		private PropertyCondition btn_line904 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop904");
		private PropertyCondition btn_line905 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop905");
		private PropertyCondition btn_line906 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop906");
		private PropertyCondition btn_line907 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop907");
		private PropertyCondition btn_line908 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop908");
		private PropertyCondition btn_line909 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop909");
		private PropertyCondition btn_line910 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop910");
		private PropertyCondition btn_line911 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop911");
		private PropertyCondition btn_line912 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop912");
		private PropertyCondition btn_line1002 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1002");
		private PropertyCondition btn_line1003 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1003");
		private PropertyCondition btn_line1004 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1004");
		private PropertyCondition btn_line1005 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1005");
		private PropertyCondition btn_line1006 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1006");
		private PropertyCondition btn_line1007 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1007");
		private PropertyCondition btn_line1008 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1008");
		private PropertyCondition btn_line1009 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1009");
		private PropertyCondition btn_line1010 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1010");
		private PropertyCondition btn_line1011 = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton2");
		private PropertyCondition btn_line1101a = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1101a");
		private PropertyCondition btn_line1101b = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1101b");
		private PropertyCondition btn_line1101c = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1101c");
		private PropertyCondition btn_line1101d = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1101d");
		private PropertyCondition btn_line1101e = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1101e");
		private PropertyCondition btn_line1101f = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1101f");
		private PropertyCondition btn_line1102a = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton10");
		private PropertyCondition btn_line1102b = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton11");
		private PropertyCondition btn_line1102c = new PropertyCondition(AutomationElement.AutomationIdProperty, "ImageButton12");
		private PropertyCondition btn_line1102d = new PropertyCondition(AutomationElement.AutomationIdProperty, "imgBtn1102e");
		private PropertyCondition btn_line1102e = new PropertyCondition(AutomationElement.AutomationIdProperty, "imgBtn1102f");
		private PropertyCondition btn_line1102f = new PropertyCondition(AutomationElement.AutomationIdProperty, "imgBtn1102g");
		private PropertyCondition btn_line1102g = new PropertyCondition(AutomationElement.AutomationIdProperty, "imgBtn1102h");
		private PropertyCondition btn_line1102h = new PropertyCondition(AutomationElement.AutomationIdProperty, "imgBtn1102i");
		private PropertyCondition btn_line1103 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1103");
		private PropertyCondition btn_line1104 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1104");
		private PropertyCondition btn_line1109 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1109");
		private PropertyCondition btn_line1110 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1110");
		private PropertyCondition btn_line1111 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1111");
		private PropertyCondition btn_line1112 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1112");
		private PropertyCondition btn_line1113 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1113");
		private PropertyCondition btn_line1114 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1114");
		private PropertyCondition btn_line1115 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1115");
		private PropertyCondition btn_line1116 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1116");
		private PropertyCondition btn_line1202 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1202");
		private PropertyCondition btn_line1203 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1203");
		private PropertyCondition btn_line1204 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1204");
		private PropertyCondition btn_line1205 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1205");
		private PropertyCondition btn_line1206 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1206");
		private PropertyCondition btn_line1207 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1207");
		private PropertyCondition btn_line1208 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1208");
		private PropertyCondition btn_line1209 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1209");
		private PropertyCondition btn_line1210 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1210");
		private PropertyCondition btn_line1302 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1302");
		private PropertyCondition btn_line1303 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1303");
		private PropertyCondition btn_line1304 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1304");
		private PropertyCondition btn_line1305 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1305");
		private PropertyCondition btn_line1306 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1306");
		private PropertyCondition btn_line1307 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1307");
		private PropertyCondition btn_line1308 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1308");
		private PropertyCondition btn_line1309 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1309");
		private PropertyCondition btn_line1310 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1310");
		private PropertyCondition btn_line1311 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1311");
		private PropertyCondition btn_line1312 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1312");
		private PropertyCondition btn_line1313 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1313");
		private PropertyCondition btn_line1314 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1314");
		private PropertyCondition btn_line1315 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1315");
		private PropertyCondition btn_line1316 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1316");
		private PropertyCondition btn_line1317 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1317");
		private PropertyCondition btn_line1318 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1318");
		private PropertyCondition btn_line1319 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1319");
		private PropertyCondition btn_line1320 = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPop1320");
	
		public Itemization btn_line701_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_line701);
			aElement.ClickCenterOfBounds();

			return new Itemization();
		}
		public Itemization btn_line702_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_line702);
			aElement.ClickCenterOfBounds();

			return new Itemization();
		}

		#endregion

	}
}
