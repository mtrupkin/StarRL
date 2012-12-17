using System;

namespace ConsoleLib
{
	public class TextWidget : ControlBase
	{
        public String TextValue { get; protected set; }

        public TextWidget(Composite parent)
            : base(parent, 1, 1)
        {
            
        }

        public TextWidget(Composite parent, String text)
            : base(parent, text.Length, 1)
		{
            TextValue = text;
		}

        public void SetText(String text)
        {
            TextValue = text;
            Resize(text.Length, 1);
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

