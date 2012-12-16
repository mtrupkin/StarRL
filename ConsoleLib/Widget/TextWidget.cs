using System;

namespace ConsoleLib
{
	public class TextWidget : Control
	{
		public String TextValue { get; protected set; }

		public TextWidget (Composite parent)
            : base(parent, 1, 0)
		{
			
		}
		
		public override void Render ()
		{
			Screen.Clear();
			
			if (TextValue != null) {
				Screen.Write(TextValue);
			}
		}

        public void SetText(String text)
        {
            TextValue = text;
        }

	}
}

