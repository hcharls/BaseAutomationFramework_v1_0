///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <StatusReport>
///   Description:    <builds_report_structure>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <written_by_Ascendum_automation>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

using BaseAutomationFramework.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BaseAutomationFramework.HTML_Report
{
	/// <summary>
	/// Creation of HTML Status Report
	/// Send Step objects with addStep, populate a list of steps and then
	/// use writeReport at the end of the test to create the HTML document.
	/// </summary>
	public class StatusReport : Screenshot
	{
		//default constructor
		private StatusReport() { }

		#region Class Variables
		//public properties
		public string Title { get; set; }
		public string Description { get; set; }
		public List<string> OtherInformation { get; set; }
		public string FilePath { get; private set; }
		public bool PassFail
		{
			get
			{
				return passfailvar;
			}
			set
			{
				PFSet = true;
				passfailvar = value;
			}
		}

		//private instance of StatusReport
		private static StatusReport instance = null;
		//private class variables
		private bool PFSet = false;
		private List<Step> steps = new List<Step>();
		private bool passfailvar;
		private List<string> reportToWrite = new List<string>();
		private DateTime timeStarted, timeStopped;
		private List<string> modals = new List<string>();

		#endregion

		#region Variable For CSS Values
		//CSS formatting values
		public bool UseExpectedResults = true;
		public string[] HeaderWidth = { "20", "20", "20", "20", "20" };
		public string[] TableWidth = { "8", "20", "27", "27", "8", "10" }; //default table width includes using Expected results column.
		public string[] FooterWidth = { "25", "25", "25", "25" };
		public string BackgroundColor = "#000000";
		public string HeadingBackgroundColor = "#A9BBBD";
		public string Headingcolor = "#000000";
		public string HeaderPassColor = "#56DB4A";
		public string HeaderFailColor = "#FA4248";
		public string TableBorderColor = "#000000";
		public string SubheaderBackgroundColor = "#2C3E50";
		public string SubheaderColor = "#F7EBD9";
		public string TRSectionBGColor = "#8B9292";
		public string TRSectionColor = "#001429";
		public string TRContentBGColor = "#F7EBD9";
		public string TRContentColor = "#000000";
		public string TDPassColor = "#3CBA3A";
		public string TDFailColor = "#CC2F00";
		public string TDDoneColor = "#000000";
		public string TDWarnColor = "orange";
		public string TDDebugColor = "blue";
		public string TDBorderColor = "#000000";
		#endregion

		/// <summary>
		/// Get current instance of StatusReport or returns new instance.
		/// </summary>
		/// <returns>current instance of StatusReport or creates new instance.</returns>
		public static StatusReport getStatusReport()
		{
			if (instance == null)
				instance = new StatusReport();
			return instance;
		}
		/// <summary>
		/// setup basic details of a report
		/// </summary>
		/// <param name="strTitle">Title to use with report</param>
		/// <param name="strFilePath">Filepath to use with report</param>
		/// <param name="lstDetails">Other details to use with report (subheaders)</param>
		public void reportSetup(string strTitle = null, string strFilePath = null, string strDescription = null, List<string> lstDetails = null)
		{
			if (strTitle != null)
				instance.Title = strTitle;
			if (strFilePath != null)
				instance.FilePath = strFilePath;
			if (lstDetails != null)
				instance.OtherInformation = lstDetails;
			if (strDescription != null)
				instance.Description = strDescription;
			instance.initializeReporter();
		}
		/// <summary>
		/// Add a Step to the reporter
		/// </summary>
		/// <param name="step">Step to add to the reporter's list of steps.</param>
		public void addStep(Step step)
		{
			steps.Add(step);
		}
		/// <summary>
		/// builds header (applying CSS / title / headers & subheaders)
		/// </summary>
		public void initializeReporter()
		{
			//building header of HTML report
			reportToWrite = null;
			reportToWrite = new List<string>();
			timeStarted = DateTime.Now;
			Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
			reportToWrite.Add(@"<!DOCTYPE html>" + "\n" +
				@"<html>" + "\n" +
				@"<head>" + "\n" +
				@"<meta charset='UTF-8'>" + "\n" +
				string.Format(@"<title>{0}</title>", Title));

			buildCSS();
			buildHeaders();

		}
		/// <summary>
		/// Set boolean of TestPassed (true =pass, false =fail) to be used for the footer
		/// TestPassed is optional.  If this value is not set, the testReporter will use count of steps failed to determine
		/// if the test passed or failed.  But this value will override that behavior.
		/// </summary>
		/// <param name="testPassed"></param>
		public void setPassFail(bool testPassed)
		{
			PassFail = testPassed;
		}
		/// <summary>
		/// sets FilePath to use for creating report
		/// </summary>
		/// <param name="strNewFilePath">New FilePath value to use for report craetion</param>
		private void setFilePath(string strNewFilePath)
		{
			FilePath = strNewFilePath;
		}
		/// <summary>
		/// Finishes creating the HTML file & writes to FilePath.
		/// </summary>
		public void writeReport()
		{
			int passedSteps = 0, failedSteps = 0;
			if (FilePath != null)
			{
				if (File.Exists(FilePath))
					File.Delete(FilePath);
				//initializeReporter should be called from your test case or test set up.
				//but if it hasn't yet been called when writeReport is called, we will call it now to set up CSS / HEADERS / HTML tags.
				if (reportToWrite == null)
					initializeReporter();

				buildStepTable(ref passedSteps, ref failedSteps);
				buildFooters(passedSteps, failedSteps);
				//closing out html tags
				reportToWrite.Add(@"</body>" + "\n" +
					@"</html>");

				foreach (var m in modals)
					reportToWrite.Add(m);
				//Will create directory if it does not exist
				Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
				//System.Windows.Forms.MessageBox.Show(FilePath);
				//write reportToWrite to file
				File.WriteAllLines(FilePath, reportToWrite);
			}
			else
				throw new Exception("Results reporter filepath not set.");

			instance = null;
		}
		/// <summary>
		/// Builds headers and subheaders for HTML file
		/// </summary>
		private void buildHeaders()
		{
			//Body
			reportToWrite.Add("<!--Begin Body-->\n" +
				"<body> " + "\n" +
				//adding header
				"<!--Headers-->\n" +
				@"<table id='header'> " + "\n" +
				@"<colgroup>");
			foreach (string headerwidth in HeaderWidth)
				reportToWrite.Add(string.Format(@"<col style='width: {0}%' /> ", headerwidth));

			reportToWrite.Add(@"</colgroup> " + "\n" +
				@"<thead> " + "\n" +
				@"<tr class='heading'> " + "\n" +
				string.Format(@"<th colspan='{0}' style='font-family:Verdana, Geneva, sans-serif; font-size:2em;'> ", HeaderWidth.Length) +
				Title +
				@"</th> " + "\n" +
				@"</tr> " + "\n" +
				@"<tr class='heading'> " + "\n" +
				string.Format(@"<th colspan='{0}' style='font-family:Verdana, Geneva, sans-serif; font-size:1.4em;'> ", HeaderWidth.Length) +
				Description +
				@"</th> " + "\n" +
				@"</tr>");

			//adding subheader
			int headercols = HeaderWidth.Length;
			if (OtherInformation != null)
			{
				int cellcount = 0;
				reportToWrite.Add("<!--SubHeadings-->\n" + "<tr class='subheading'>");
				foreach (string info in OtherInformation)
				{
					//&nbsp;
					reportToWrite.Add(string.Format(@"<th>{0}</th>", info));
					cellcount++;
					//if cell count of headers is longer than the # of cols for headers, start a new line (prevents formatting breaking.)
					if (cellcount % headercols == 0 && cellcount < OtherInformation.Count)
					{
						reportToWrite.Add(@"</tr>");
						reportToWrite.Add(@"<tr class='subheading'>");
					}
				}
				//if header cell count doesn't end in a full row of cols, add blank headers to fill space (prevents formatting breaking.)
				while (cellcount % headercols != 0)
				{
					reportToWrite.Add(@"<th></th>");
					cellcount++;
				}
				reportToWrite.Add(@"</tr>");
			}
			reportToWrite.Add(@"</thead>" + "\n" +
				@"</table>");
		}
		/// <summary>
		/// adding CSS formats to HTML file
		/// </summary>
		private void buildCSS()
		{
			//CSS
			reportToWrite.Add("<!--CSS-->\n" +
				"<style type='text/css'> " + "\n" +
				@"body { " + "\n" +
				string.Format(@"background-color: {0}; " + "\n", BackgroundColor) +
				@"font-family: Verdana, Geneva, sans-serif; " + "\n" +
				@"text-align: center; " + "\n" +
				@"} " + "\n" +
				//small font
				@"small { " + "\n" +
				@"font-size: 0.7em; " + "\n" +
				@"} " + "\n" +
				//table
				@"table { " + "\n" +
				string.Format(@"border: 1px solid {0}; " + "\n", TableBorderColor) +
				@"border-collapse: collapse; " + "\n" +
				@"border-spacing: 0px; " + "\n" +
				@"width: 1000px; " + "\n" +
				@"margin-left: auto; " + "\n" +
				@"margin-right: auto; " + "\n" +
				@"} " + "\n" +
				//Heading
				@"tr.heading { " + "\n" +
				string.Format(@"background-color: {0}; " + "\n", HeadingBackgroundColor) +
				string.Format(@"color: {0}; " + "\n", Headingcolor) +
				@"font-size: 0.9em; " + "\n" +
				@"font-weight: bold; " + "\n" +
				@"} " + "\n" +
				//TR Subheading
				@"tr.subheading { " + "\n" +
				string.Format(@"background-color: {0}; " + "\n", SubheaderBackgroundColor) +
				string.Format(@"color: {0} ; " + "\n", SubheaderColor) +
				@"font-weight: bold; " + "\n" +
				@"font-size: 0.9em; " + "\n" +
				@"text-align: center; " + "\n" +
				@"}" + "\n" +
				//TR Section
				@"tr.section { " + "\n" +
				string.Format(@"background-color: {0}; " + "\n", TRSectionBGColor) +
				string.Format(@"color: {0}; " + "\n", TRSectionColor) +
				@"cursor: pointer; " + "\n" +
				@"font-weight: bold; " + "\n" +
				@"font-size: 0.9em; " + "\n" +
				@"text-align: justify; " + "\n" +
				@"} " + "\n" +
				//TR Subsection
				@"tr.subsection { " + "\n" +
				@"cursor: pointer; " + "\n" +
				@"} " + "\n" +
				//TR Content
				@"tr.content { " + "\n" +
				string.Format(@"background-color: {0}; " + "\n", TRContentBGColor) +
				string.Format(@"color: {0}; " + "\n", TRContentColor) +
				@"font-size: 0.8em; " + "\n" +
				@"display: table-row; " + "\n" + @"}" + "\n" +
				@"td, th { " + "\n" +
				@"padding: 4px; " + "\n" +
				@"text-align: inherit\0/; " + "\n" + @"} " + "\n" +
				//Table Header
				@"th { " + "\n" +
				@"font-family: 'Verdana, Geneva, sans-serif; " + "\n" +
				@"} " + "\n" +
				//TD
				@"td { " + "\n" +
				string.Format(@"border: 1px solid {0}; " + "\n", TDBorderColor) +
				@"border-spacing: 1px; " + "\n" +
				@"} " + "\n" +
				//TD Justified
				@"td.justified { " + "\n" +
				@"text-align: center; " + "\n" +
				@"} " + "\n" +
				//HeaderPass
				@"td.headerpass {" + "\n" +
				@"font-weight: bold; " + "\n" +
				string.Format(@"color: {0}; " + "\n", HeaderPassColor) +
				@"}" + "\n" +
				//HeaderFail
				@"td.headerfail { " + "\n" +
				@"font-weight: bold; " + "\n" +
				string.Format(@"color: {0}; " + "\n", HeaderFailColor) +
				@"}" + "\n" +
				//TD Pass
				@"td.pass { " + "\n" +
				@"font-weight: bold; " + "\n" +
				string.Format(@"color: {0}; " + "\n", TDPassColor) +
				@"} " + "\n" +
				//TD Fail
				@"td.fail { " + "\n" +
				@"font-weight: bold; " + "\n" +
				string.Format(@"color: {0}; " + "\n", TDFailColor) +
				@"} " + "\n" +
				//TD Done & Screenshot
				@"td.done, td.screenshot { " + "\n" +
				@"font-weight: bold;" + "\n" +
				string.Format(@"color: {0};" + "\n", TDDoneColor) +
				@"}" + "\n" +
				//TD debug
				@"td.debug {" + "\n" +
				@"font-weight: bold;" + "\n" +
				string.Format(@"color: {0};" + "\n", TDDebugColor) +
				@"}" + "\n" +
				//TD Warning
				@"td.warning {" + "\n" +
				@"font-weight: bold;" + "\n" +
				string.Format(@"color: {0};" + "\n", TDWarnColor) +
				@"}" + "\n"
				//Modal window
				+ ".modal {" + "\n"
				+ "display: none;" + "\n"
				+ "position: fixed;" + "\n"
				+ "z-index: 1;" + "\n"
				+ "padding-top: 20px;" + "\n"
				+ "left: 0;" + "\n"
				+ "top: 0;" + "\n"
				+ "width: 100%;" + "\n"
				+ "height: 100%;" + "\n"
				+ "overflow: auto;" + "\n"
				+ "background-color: rgb(0,0,0);" + "\n"
				+ "background-color: rgba(0,0,0,0.4);" + "\n"
				+ "}" + "\n"
				//paragraph inside modal
				+ "pre {" + "\n"
						+ "white-space: pre-wrap;" + "\n"
					+ "white-space: -moz-pre-wrap;" + "\n"
					+ "white-space: -pre-wrap;" + "\n"
					+ "white-space: -o-pre-wrap;" + "\n"
					+ "word-wrap: break-word;" + "\n"
					+ "font-size: 14px;" + "\n"
					+ "}" + "\n"
				//content of modal
				+ ".modal-content {" + "\n"
						+ "text-align: left;" + "\n"
						+ "background-color: #fefefe;" + "\n"
						+ "margin: auto;padding: 20px;" + "\n"
						+ "border: 3px solid #888;" + "\n"
						+ "width: 80%;" + "\n"
				+ "}" + "\n"
				//images within modal content
				+ ".modal-img {" + "\n"
						+ "max-width: 100%; \n"
						+ "max-height: 100%; \n"
						+ "object-fit: contain; \n"
						+ "} \n"
				//modal window close button
				+ ".close {" + "\n"
						+ "color: #aaaaaa;" + "\n"
						+ "float: right;" + "\n"
						+ "font-size: 28px;" + "\n"
						+ "font-weight: bold;" + "\n"
				+ "}" + "\n"
				+ ".close:hover," + "\n"
					+ ".close:focus {" + "\n"
							+ "color: #000;" + "\n"
							+ "text-decoration: none;" + "\n"
							+ "cursor: pointer;" + "\n"
					+ "}\n"
					+ "</style>" + "\n" +
				@"</head>" + "\n"); 

		}
		/// <summary>
		/// Builds footers for the HTML file
		/// </summary>
		/// <param name="passedSteps">Int of passed steps</param>
		/// <param name="failedSteps">Int of failed steps</param>
		private void buildFooters(int passedSteps, int failedSteps)
		{
			timeStopped = DateTime.Now;
			string passfail = "", classPF = "";
			TimeSpan executionTime = timeStopped - timeStarted;
			//first footer
			reportToWrite.Add("<!--Begin Footer-->\n" +
				"<table id='footer'>" + "\n" +
				@"<colgroup> ");
			foreach (string fWidth in FooterWidth)
				reportToWrite.Add(string.Format(@"<col style='width: {0}%' />", fWidth));

			reportToWrite.Add(@"</colgroup> " + "\n" +
				@"<tfoot> " + "\n" +
				@"<tr class='heading'>" + "\n" +
				string.Format(@"<th colspan='{3}'>Execution Duration: {0}:hh {1}:mm {2}:ss</th>" + "\n", executionTime.Hours, executionTime.Minutes, executionTime.Seconds, FooterWidth.Length) +
				@"</tr>" + "\n" +
				@"<tr class='subheading'>" + "\n" +
				@"<td class='headerpass'>&nbsp;Steps passed</td>" + "\n" +
				string.Format(@"<td class='headerpass'>&nbsp;{0}</td>", passedSteps) + "\n" +
				@"<td class='headerfail'>&nbsp;Steps failed</td>" + "\n" +
				string.Format(@"<td class='headerfail'>&nbsp;{0}</td></tr>", failedSteps) + "\n" +
				@"</tfoot>" + "\n" +
				@"</table>" + "\n" +
				@"</tbody>" + "\n" +
				@"</table>");

			if (!PFSet)
			{
				passfail = failedSteps != 0 ? "Failed" : "Passed";
				classPF = "header" + passfail.Substring(0, 4).ToLower();
			}
			else
			{

				passfail = PassFail ? "Passed" : "Failed";
				classPF = "header" + passfail.Substring(0, 4).ToLower();
			}
			//bottom footer
			reportToWrite.Add("<!--Begin Second Footer-->");
			reportToWrite.Add(@"<table id='footer'>" + "\n" +
				@"<colgroup> ");
			//foreach (string fWidth in FooterWidth)
			//	reportToWrite.Add(string.Format(@"<col style='width: {0}%' />", fWidth));
			reportToWrite.Add(@"<col style='width: 100%' />");
			reportToWrite.Add(@"</colgroup> " + "\n" +
				@"<tfoot> " + "\n" +
				@"<tr class='subheading'> " + "\n" +
				string.Format(@"<td class='{0}'>Execution Status: {1}</td> ", classPF, passfail) + "\n" +
				@"</tr> " + "\n" +
				@"</tfoot> " + "\n" +
				@"</table> ");

		}

		/// <summary>
		/// Add modal window to the report
		/// </summary>
		/// <param name="linkText">Text to display.  Should be Step.Action</param>
		/// <param name="message">Message to display within the Modal Window</param>
		/// <returns>Link to use for new window</returns>
		private string addModal(string linkText, string message)
		{
			int num = modals.Count() + 1;
			string modalDialog = "<!--Modal Window " + num + "-->\n" +
								"<div>" + "<div id=\"messageModal" + num + "\" class=\"modal\"><div class=\"modal-content\"><span id=\"messageClose" + num
								+ "\" class=\"close\">×</span><pre>" + message.Replace("\n", "<br>") + "</pre></div></div>\r" + "<script>"
												+ "var modal" + num + " = document.getElementById('messageModal" + num + "');"
												+ "var link" + num + " = document.getElementById(\"messageLink" + num + "\");"
												+ "var span" + num + " = document.getElementById(\"messageClose" + num + "\");"
												+ "link" + num + ".style.textDecoration = 'underline';"
												+ "link" + num + ".onclick = function() {"
														+ "modal" + num + ".style.display = \"block\";"
												+ "}\n"
												+ "span" + num + ".onclick = function() {"
														+ "modal" + num + ".style.display = \"none\";"
												+ "}\n"
										+ "</script></div>\n";
			modals.Add(modalDialog);
			return "<span style='cursor:pointer' id='messageLink" + num + "'>" + linkText + "</span>";
		} 

		/// <summary>
		/// builds table of steps for the HTML file
		/// </summary>
		/// <param name="passedSteps">reference to counter of passed steps</param>
		/// <param name="failedSteps">reference to counter of failed steps</param>
		private void buildStepTable(ref int passedSteps, ref int failedSteps)
		{
			string classPF = "";
			//table of steps
			reportToWrite.Add("<!--Main content table-->\n" + "<table id='main'>" + "\n" +
				@"<colgroup>");
			//set up column sizes
			foreach (string tWidth in TableWidth)
				reportToWrite.Add(string.Format(@"<col style='width: {0}%' />", tWidth));
			reportToWrite.Add(@"</colgroup>" + "\n" +
				//adding table headers
				@"<thead>" + "\n" +
				@"<tr class='heading'>" + "\n" +
				@"<th>Step#</th>" + "\n" +
				@"<th>Action</th>");
			if (UseExpectedResults)
				reportToWrite.Add(@"<th>Expected Result</th>");
			reportToWrite.Add(@"<th>Actual Result</th>" + "\n" +
				@"<th>Status</th>" + "\n" +
				@"<th>Screenshot</th>" + "\n" +
				@"<th>Time</th>" + "\n" +
				@"</tr>" + "\n" +
				@"</thead>");
			//adding each step to the table
			int i = 0; passedSteps = 0; failedSteps = 0;
			foreach (var step in steps)
			{
				//adding each step's data to the table
				//set class to status - used for setting CSS for the status cell
				classPF = step.Status.ToLower();
				reportToWrite.Add(string.Format(@"<tr class='content' id='{0}'>", i + 1) + "\n" +
					//table id is the step's # in order that they were added.
					string.Format(@"<td>{0}</td>", i+1) + "\n" +
					string.Format(@"<td class='justified'>{0}</td>", string.IsNullOrEmpty(step.ModalText) ?
						CharLimit(step.Action) : addModal(CharLimit(step.Action), step.ModalText)));
				if (UseExpectedResults)
					reportToWrite.Add(string.Format(@"<td class='justified'>{0}</td>", CharLimit(step.ExpectedResult)));
				reportToWrite.Add(string.Format(@"<td class='justified'>{0}</td>", CharLimit(step.ActualResult)));
				// Adding Status
				reportToWrite.Add(string.Format(@"<td class='{1}'>{0}</td>", CharLimit(step.Status), classPF));
				
				//	Screenshot Column
				if (!string.IsNullOrEmpty(step.ScreenShotLocation))
				{
					//reportToWrite.Add(string.Format(@"<td class='{0}'><a href='{1}'>{2}</a></td>", classPF, step.ScreenShotLocation, "Link"));
					//reportToWrite.Add(string.Format(@"<td class='{0}'>{1}</td>", classPF, addModal(step.Status, string.Format(@"<img src='//{0}' />", step.ScreenShotLocation))));
					reportToWrite.Add(string.Format(@"<td class='{0}'>{1}</td>", classPF, addModal("Link", string.Format(@"<pre><h2>{1}</h2></pre><pre>{0}</pre><a href='\\{0}'><img class='modal-img' src='\\{0}' /></a>", step.ScreenShotLocation, step.Status))));
				}
													
				else
				{
					reportToWrite.Add(string.Format(@"<td class='{1}'>{0}</td>", "", ""));
				}					
				
				//	Timestamp Column
				reportToWrite.Add(string.Format(@"<td class='justified'><small>{0}</small></td>" + "\n", step.Time) +
					@"</tr>");
				i++;
				//counter of steps passed and steps failed for the footer
				if (step.Status.ToLower().Contains("pass"))
					passedSteps++;
				else if (step.Status.ToLower().Contains("fail"))
					failedSteps++;
				classPF = "";
			}
			reportToWrite.Add(@"</tbody" + "\n" +
				@"</table>");
		}
		/// <summary>
		/// Set font size to small if the string is longer than the limiter
		/// </summary>
		/// <param name="str">string to check size</param>
		/// <param name="limiter">limit to set font size to small</param>
		/// <returns>if string length >= limiter, returns string with <small>str</small> tags.</returns>
		private string CharLimit(string str, int limiter = 100)
		{
			if (str.Length >= limiter)
			{
				str = string.Format(@"<small>{0}</small>", StringCutOff(str));
			}
			return str;
		}
		/// <summary>
		/// Limits string max length to limiter
		/// </summary>
		/// <param name="str">string to check length</param>
		/// <param name="limiter">length to limit string to max</param>
		/// <returns>str cut off to length of limiter</returns>
		private string StringCutOff(string str, int limiter = 300)
		{
			if (str.Length >= limiter)
			{
				str = str.Substring(0, limiter);
			}
			return str;
		}
	}
}
