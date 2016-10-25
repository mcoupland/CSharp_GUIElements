using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GUIElements
{
    public class SelectionChangedEventArgs : EventArgs
    {
        private readonly GUIButton _button;
        public SelectionChangedEventArgs(GUIButton button)
        {
            _button = button;
        }
        public GUIButton ButtonChanged
        {
            get { return _button; }
        }
    }

    public enum GUITogglePanelSelectionType { Single, Multiple }
    /// <summary>
    /// Interaction logic for GUITogglePanel.xaml
    /// </summary>
    public partial class GUITogglePanel : UserControl
    {
        #region event
        public delegate void SelectionChangedHandler(object sender, SelectionChangedEventArgs e);
        public event SelectionChangedHandler OnSelectionChanged;
        private void SelectionChanged(object sender, SelectionChangedEventArgs args) { OnSelectionChanged?.Invoke(this, args); }
        #endregion

        private GUITogglePanelSelectionType _selection_type = GUITogglePanelSelectionType.Single;
        private List<GUIButton> _buttons = new List<GUIButton>();

        public GUITogglePanel()
        {
            InitializeComponent();
            this.Margin = new Thickness(20);
        }

        public void AddButtons(List<GUIButton> buttons, GUITogglePanelSelectionType selectiontype = GUITogglePanelSelectionType.Single, Orientation orientation = Orientation.Horizontal)
        {
            _buttons.Clear();
            _buttons = buttons.GetRange(0, buttons.Count);

            _selection_type = selectiontype;
            Container.Orientation = orientation;
            Container.Children.Clear();
            foreach (GUIButton button in _buttons)
            {
                button.Margin = new Thickness(10);
                button.OnLeftClick += SelectButton_Click;
                Container.Children.Add(button);
            }
        }

        private void SelectButton_Click(object sender, MouseButtonEventArgs e)
        {
            GUIButton selected = sender as GUIButton;
            if (_selection_type == GUITogglePanelSelectionType.Single) { SelectSingle(selected); }
            else { SelectMultiple(selected); }
            SelectionChanged(this, new SelectionChangedEventArgs(selected));
        }

        private void SelectMultiple(GUIButton sender)
        {
            if (sender.CurrentState == GUIEnumerations.ButtonState.ToggleDown)
            {
                sender.CurrentState = GUIEnumerations.ButtonState.ToggleUp;
                sender.UpdateFrame(new Thickness(10), Brushes.Black, 0.6, Brushes.Black, new Thickness(1));
            }
            else
            {
                sender.CurrentState = GUIEnumerations.ButtonState.ToggleDown;
                sender.UpdateFrame(new Thickness(sender.guiBorder.Margin.Top), Brushes.Black, 0.6, Brushes.Red, new Thickness(2));
            }
        }

        private void SelectSingle(GUIButton selected)
        {            
            foreach (GUIButton button in _buttons)
            {
                if (button == selected)
                {
                    button.CurrentState = GUIEnumerations.ButtonState.ToggleDown;
                    button.UpdateFrame(new Thickness(button.guiBorder.Margin.Top), Brushes.Black, 0.6, Brushes.Red, new Thickness(2));
                }
                else
                {
                    button.CurrentState = GUIEnumerations.ButtonState.ToggleUp;
                    button.UpdateFrame(new Thickness(10), Brushes.Black, 0.6, Brushes.Black, new Thickness(1));
                }
            }
        }
    }
}
