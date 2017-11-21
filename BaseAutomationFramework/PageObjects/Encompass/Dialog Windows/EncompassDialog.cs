﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BaseAutomationFramework.Tests;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	class EncompassDialog : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByClassName("#32770");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;

		public static EncompassDialog Initialize()
		{
			return new EncompassDialog();
		}

		public EncompassDialog()
		{
			try
			{
				BaseTest.TestedApplication.WaitWhileBusy();
			}
			catch (InvalidOperationException e) { Thread.Sleep(5000); } 

			if (Screen == null)
				throw new Exception("Screen must not be null");
		}

		private SearchCriteria btn_RESPA_OK = SearchCriteria.ByAutomationId("2");
		private SearchCriteria btn_SaveYes = SearchCriteria.ByAutomationId("6");
		private SearchCriteria btn_OKtoCertify = SearchCriteria.ByAutomationId("1");

		//
		public EncompassDialog btn_RESPA_OK_Click()
		{
			GetButton(btn_RESPA_OK).Click();
			return new EncompassDialog();
		}
		public EncompassDialog btn_SaveYes_Click()
		{
			GetButton(btn_SaveYes).Click();
			return new EncompassDialog();
		}
		public EncompassDialog btn_OKtoCertify_Click()
		{
			GetButton(btn_OKtoCertify).Click();
			return new EncompassDialog();
		}
	}
}
