using System;

namespace ConsoleLib
{
	public class LabelWidget:Control
	{		
		public String LabelString{get; protected set;}
		public String ValueString{get; protected set;}
		
		public int LabelLength{get; protected set;}

		TextWidget LabelTextWidget{get; set;}
		TextWidget ValueTextWidget{get; set;}
		
		ControlLayout LabelLayout{get;set;}
		ControlLayout ValueLayout{get;set;}

		public LabelWidget (String label) {
			if (label != null) {
				Initialize(label, label.Length);
			}
		}
		
		void Initialize() {
			LabelTextWidget = new TextWidget();
			ValueTextWidget = new TextWidget();
			
			LabelLayout = new ControlLayout(LabelTextWidget);
			ValueLayout = new ControlLayout(ValueTextWidget);
		}
		
		void Initialize(String label, int labelLength)
		{
			Initialize();
		}
		
		public void SetValue(String valueString) 
		{
			ValueString = valueString;
		}

		public override void Initialize (Shell shell)
		{
			LabelTextWidget.Initialize(shell);
			ValueTextWidget.Initialize(shell);
		}
		
		public override void Render ()
		{
			RenderLayout(LabelLayout);
			RenderLayout(ValueLayout);
		}
		
		public void RenderLayout (ControlLayout layout) 
		{
			layout.Control.Render();
            Con.Display(layout.X, layout.Y, layout.Control.Con);
		}
	}
}

