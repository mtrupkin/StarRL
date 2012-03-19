using System;

namespace ConsoleLib
{
	public class TextWidget : Control
	{
		public String TextValue { get; protected set; }

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

        public void SetText(String text)
        {
            TextValue = text;
        }

	}
}

