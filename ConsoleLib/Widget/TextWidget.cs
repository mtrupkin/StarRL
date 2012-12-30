using System;

namespace ConsoleLib
{
	public class TextWidget : ControlBase
	{

        public String TextValue { get; protected set; }

        public TextWidget(Composite parent)
            : base(parent)
        {
        }

        public TextWidget(Composite parent, String text)
            : base(parent)
		{
            SetText(text);
		}

        public void SetText(String text)
        {
            TextValue = text;
            int newSize = text.Length;

            if (Width != newSize)
            {
                Resize(newSize, 1);
                Resize();
            }
        }
		
		public override void Render ()
		{
			//Screen.Clear();
			
			if (TextValue != null) {
				Screen.Write(TextValue);
			}
		}
	}
}

