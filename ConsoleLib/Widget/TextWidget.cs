using System;

namespace ConsoleLib
{
	public class TextWidget : ControlBase
	{
        protected int MinWidth { get; set; }

        public String TextValue { get; protected set; }

        public TextWidget(Composite parent, int width)
            : base(parent, width, 1)
        {
            MinWidth = Width;
        }

        public TextWidget(Composite parent, String text)
            : base(parent, text.Length, 1)
		{
            MinWidth = Width;
            TextValue = text;
		}

        public void SetText(String text)
        {
            TextValue = text;
            int newSize = text.Length;
            if (newSize > MinWidth)
            {
                //MinWidth = newSize;
                Resize(newSize, 1, true);
            }
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

