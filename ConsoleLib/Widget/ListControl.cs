using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public delegate void ItemSelectedEventHandler<T>(T item);

    public class ListControl<T> : Control
    {
        public List<T> Items { get; set; }

        public T SelectedItem { get; set; }

        public int SelectedIndex { get; set; }
        public int HighlightedIndex { get; set; }

        public ListControl():base()
        {
            Items = new List<T>();
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
                    Con.ForegroundColor = ConsoleRGB.White;
                    if (i == HighlightedIndex)
                    {
                        Con.BackgroundColor = ConsoleRGB.Gray;
                    }
                    else
                    {
                        Con.BackgroundColor = ConsoleRGB.Black;
                    }
                }
                Con.SetPosition(0, i);
                Con.Write(o.ToString());
                i++;
            }
        }

        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.Enter: SelectItem(HighlightedIndex);
                break;
                case ConsoleKey.UpArrow: MoveHighlightUp();
                break;
                case ConsoleKey.DownArrow: MoveHighlightDown();
                break;

            }
            base.OnKeyPress(consoleKey);
        }

        public override void OnMouseMove(Mouse mouse)
        {

            if (mouse.Y < Items.Count)
            {
                HighlightedIndex = mouse.Y;
            }

            base.OnMouseMove(mouse);
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

        public void AddItem(T item)
        {
            Items.Add(item);
        }
    }
}
