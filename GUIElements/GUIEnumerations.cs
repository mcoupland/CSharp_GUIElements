using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIElements
{
    public static class GUIEnumerations
    {
        public enum ButtonDock { Top, Bottom, Left, Right }
        public enum ButtonState { All, Up, Down, Hover, ToggleUp, ToggleDown, ToggleHover }
        public enum ButtonType { Momentary, Toggle }
    }
}
