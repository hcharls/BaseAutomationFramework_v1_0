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

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class AddDocument : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("AddDocumentDialog");
		public static SearchCriteria[] scArray = { Encompass_eFolder.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public AddDocument()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static AddDocument Initialize()
		{
			return new AddDocument();
		}

		#region Buttons

		private SearchCriteria btn_OK = SearchCriteria.ByAutomationId("btnOK");

		//
		public void btn_OK_Click()
		{
			GetButton(btn_OK).Click();
		}

		#endregion

		#region Radio Buttons

		private SearchCriteria rdb_NewDocument = SearchCriteria.ByAutomationId("rdoNew");
		private SearchCriteria rdb_DocumentSets = SearchCriteria.ByAutomationId("rdoSet");
		//
		public AddDocument rdb_NewDocument_Select()
		{
			GetRadioButton(rdb_NewDocument).Click();

			return new AddDocument();
		}
		public AddDocument rdb_DocumentSets_Select()
		{
			GetRadioButton(rdb_DocumentSets).Click();

			return new AddDocument();
		}

		#endregion Radio Buttons

	}
}