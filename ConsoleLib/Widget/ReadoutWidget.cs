using System;
using System.Collections.Generic;

namespace ConsoleLib
{
	public class ReadoutWidget
	{
		Dictionary<String, String> ReadoutValues{get;set;}
		Dictionary<String, LabelWidget> LabelWidgets{get;set;}
		
		public ReadoutWidget ()
		{
			ReadoutValues = new Dictionary<String, String>();
		}
		
		public void SetReadout(String labelString, String valueString) 
		{
			ReadoutValues[labelString] = valueString;
			LabelWidgets[labelString] = new LabelWidget(labelString);
			LabelWidgets[labelString].SetValue(valueString);
		}
	}
}

