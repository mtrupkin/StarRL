using System;

namespace ConsoleLib
{
	public class TextWidget : Control
	{
		public String TextValue { get; set; }

		public TextWidget ()
		{
			Height = 1;
		}
		
		public override void Render ()
		{
			Con.Clear();
			
			if (TextValue != null) {
				Con.Write(TextValue);
			}
		}
	}
}

