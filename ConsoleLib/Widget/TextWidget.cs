using System;

namespace ConsoleLib
{
	public class TextWidget : Control
	{
		public String TextValue { get; set; }

		public TextWidget (Composite parent)
            : base(parent, 30, 1)
		{
			
		}
		
		public override void Render ()
		{
			Screen.Clear();
			
			if (TextValue != null) {
				Screen.Write(TextValue);
			}
		}
	}
}

