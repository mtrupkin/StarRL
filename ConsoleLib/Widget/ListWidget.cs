using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public delegate void OptionHandler();

    public class Option
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool Visable { get; set; }
        public OptionHandler OptionHandler { get; set; }

        public Option()
        {
            Enabled = true;
            Visable = true; 
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public delegate void ItemSelectedEventHandler<T>(T item);

    public class ListWidget<T> : ControlBase
    {
        public List<T> Items { get; protected set; }

        public T SelectedItem { get; set; }

        public int SelectedIndex { get; set; }
        public int HighlightedIndex { get; set; }

        ConsoleRGB HightlightBackgroundColor { get; set; }
        ConsoleRGB HightlightForegroundColor { get; set; }
        ConsoleRGB ForegroundColor { get; set; }

        public ListWidget(Composite parent)
            : base(parent)
        {
            Items = new List<T>();
            //HightlightBG = new ConsoleRGB() { R = 65, G = 65, B = 65 };
            HightlightBackgroundColor = ConsoleRGB.Base2;
            HightlightForegroundColor = ConsoleRGB.Base01;
            ForegroundColor = ConsoleRGB.White;
        }

        public event ItemSelectedEventHandler<T> ItemSelectedEvent;

        public virtual void OnItemSelectedEvent(T item)
        {
            if (ItemSelectedEvent != null)
            {
                ItemSelectedEvent(item);
            }
        }        

        public override void Render()
        {
            Screen.Clear();

            int i = 0;
            foreach (T o in Items)
            {
                //if (i == SelectedIndex)
                //{
                    //Con.BackgroundColor = ConsoleRGB.White;
                    //Con.ForegroundColor = ConsoleRGB.Black;
                //}
                //else
                {

                    if (i == HighlightedIndex)
                    {
                        Screen.ForegroundColor = HightlightForegroundColor;
                        Screen.BackgroundColor = HightlightBackgroundColor;
                    }
                    else
                    {
                        Screen.BackgroundColor = ConsoleRGB.Black;
                        Screen.ForegroundColor = ForegroundColor;
                    }
                }
                string value = o.ToString();
                int offset = (Width - value.Length) / 2;
                string paddedValue = value.PadLeft(offset + value.Length).PadRight(Width);
                Screen.SetPosition(0, i);
                Screen.Write(paddedValue);
                
                i++;
            }
        }

        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            base.OnKeyPress(consoleKey);

            switch (consoleKey)
            {
                case ConsoleKey.Enter: SelectItem(HighlightedIndex);
                break;
                case ConsoleKey.UpArrow: MoveHighlightUp();
                break;
                case ConsoleKey.DownArrow: MoveHighlightDown();
                break;

            }            
        }

        public override void OnMouseMove(Mouse mouse)
        {
            base.OnMouseMove(mouse);

            if (mouse.Y < Items.Count)
            {
                HighlightedIndex = mouse.Y;
            }
            
        }

        public override void OnMouseButton(Mouse mouse)
        {
            SelectItem(HighlightedIndex);
        }

        void MoveHighlightUp()
        {
            if (HighlightedIndex == 0)
            {
                HighlightedIndex = Items.Count - 1;
            }
            else
            {
                HighlightedIndex -= 1;
            }
        }

        void MoveHighlightDown()
        {
            if (HighlightedIndex == Items.Count -1)
            {
                HighlightedIndex = 0;
            }
            else
            {
                HighlightedIndex += 1;
            }
        }

        void SelectItem(int index)
        {
            SelectedItem = Items[index];
            SelectedIndex = index;
            OnItemSelectedEvent(SelectedItem);
        }

        public void SetItemList(List<T> items)
        {            
            Items = items;
        }

        public void AddItem(T item)
        {
            Items.Add(item);

            int maxWidth = Width;
            int maxHeight = Height;
            int itemWidth = item.ToString().Length;
            int itemHeight = Items.Count;

            if (itemWidth > Width)
            {
                maxWidth = itemWidth;
            }

            if (itemHeight > Height)
            {
                maxHeight = itemHeight;
            }

            Resize(maxWidth, maxHeight);

            Resize();
        }
    }
}
