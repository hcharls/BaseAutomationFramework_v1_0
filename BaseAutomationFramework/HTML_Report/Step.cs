///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <Step>
///   Description:    <report_step_builder>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

using System.Text;

namespace BaseAutomationFramework.HTML_Report
{

	/// <summary>
	/// Step object to be used with StatusReport.
	/// </summary>
	public class Step
	{
		public enum enumStatus
		{

		}
		public string Action { get; set; }
		public string ActualResult { get; set; }
		public string Status { get; set; }
		public string Time { get; set; }
		public string ExpectedResult { get; set; }
		public string ScreenShotLocation { get; set; }
		public string ModalText { get; set; }

		/// <summary>
		/// override of ToString to return Step object as a string, ignoring null values
		/// </summary>
		/// <returns>Step as a string, ignoring null values.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Action != null ? " Action " + Action : "")
				.Append(ExpectedResult != null ? " ExpectedResult " + ExpectedResult : "")
				.Append(ActualResult != null ? " ActualResult " + ActualResult : "")
				.Append(Status != null ? " Status " + Status : "")
				.Append(ScreenShotLocation != null ? " ScreenShotLocation " + ScreenShotLocation : "")
				.Append(!string.IsNullOrEmpty(ModalText) ? " ModalText " + ModalText : "")
				.Append(Time != null ? " Time " + Time : "");
			return sb.ToString().Trim();
		}
	}
}
