///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <UserConfig>
///   Description:    <prompts_for_.txt_file_in_Automation_Data_folder>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <Work_in_progress>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAutomationFramework.Tools;

namespace BaseAutomationFramework.DataObjects
{
	public class UserConfig
	{
		private Dictionary<string, string> data { get; set; }
		public bool DoThisThing { get; private set; }
		public string PieceOfData { get; private set; }

		public UserConfig(string FileName)
		{
			data = FileUtilities.ReadConfig_CreateDictionary(FileUtilities.DefaultDataDir + FileName + ".txt");

			DoThisThing = Convert.ToBoolean(data["DoThisThing"]);			
			PieceOfData = data["PieceOfData"];
		}
	}

}
