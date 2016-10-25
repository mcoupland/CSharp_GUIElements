using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUIElements
{
    /// <summary>
    /// Interaction logic for GUITogglePanelSample.xaml
    /// </summary>
    public partial class GUITogglePanelSample : Window
    {
        string _button_pic = string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "default-capture.jpg");
        List<GUIButton> _multi_buttons = new List<GUIButton>();
        List<GUIButton> _single_buttons = new List<GUIButton>();
        GUIButton gui_button = new GUIButton();

        public GUITogglePanelSample()
        {
            InitializeComponent();
            WindowImage.ImageSource = new BitmapImage(new Uri(string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "bg2.jpg")));

            
            //TestSingle();
            //TestMultiple();
        }

        private GUIButton BuildButton(
            string instancetitle,
            string caption,
            string imagesource,
            GUIEnumerations.ButtonType? buttontype,
            GUIEnumerations.ButtonDock? dock,
            bool? trimcaption)
        {
            GUIEnumerations.ButtonType button_type = buttontype.HasValue ? buttontype.Value : GUIEnumerations.ButtonType.Momentary;
            GUIEnumerations.ButtonDock dock_type = dock.HasValue ? dock.Value : GUIEnumerations.ButtonDock.Bottom;
            caption = string.IsNullOrEmpty(caption) ? string.Empty : caption;
            imagesource = string.IsNullOrEmpty(imagesource) ? string.Empty : imagesource;

            GUIButton guibutton_example = new GUIButton(
                button_type,
                dock_type,
                caption,
                imagesource,
                trimcaption
            );
            guibutton_example.Margin = new Thickness(10);
            return guibutton_example;
        }

        private void TestSingle()
        {
            GUITogglePanel ssbp = new GUITogglePanel();
            for (int x = 0; x < 6; x++)
            {
                BuildToggle(GUIEnumerations.ButtonType.Toggle, GUITogglePanelSelectionType.Single);
            }

            gui_button = BuildButton(
                "Long Caption, Compensated",
                "This caption is long enough to upset the whitespace",
                string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "default-capture.jpg"), null,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));
            gui_button.UpdateButton(null, null, true);
            _single_buttons.Add(gui_button);

            gui_button = BuildButton(
                "Long Caption, Compensated",
                "This caption is long enough to upset the whitespace",
                string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "default-capture.jpg"), null,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));
            gui_button.UpdateButton(null, null, true);
            _single_buttons.Add(gui_button);
            ssbp.AddButtons(_single_buttons, GUITogglePanelSelectionType.Single);
            ssbp.OnSelectionChanged += SinglePanel_ButtonStateChanged;
            Surface.Children.Add(ssbp);
        }

        private void SinglePanel_ButtonStateChanged(object sender, SelectionChangedEventArgs e)
        {
            GUITogglePanel panel = sender as GUITogglePanel;
            GUIButton button = e.ButtonChanged;
            button.UpdateCaption(null, null, "State is now" + button.CurrentState);
        }

        private void TestMultiple()
        {
            GUITogglePanel ssbp = new GUITogglePanel();
            for (int x = 0; x < 11; x++)
            {
                BuildToggle(GUIEnumerations.ButtonType.Toggle, GUITogglePanelSelectionType.Multiple);
            }
            ssbp.AddButtons(_multi_buttons, GUITogglePanelSelectionType.Multiple);
            ssbp.OnSelectionChanged += MutiPanel_ButtonStateChanged;
            Surface.Children.Add(ssbp);
        }

        private void MutiPanel_ButtonStateChanged(object sender, SelectionChangedEventArgs e)
        {
            GUITogglePanel panel = sender as GUITogglePanel;
            GUIButton button = e.ButtonChanged;
            button.UpdateCaption(null, null, "State is now" + button.CurrentState);
        }

        private void BuildToggle(GUIEnumerations.ButtonType buttontype, GUITogglePanelSelectionType selectiontype)
        {
            GUIButton button = new GUIButton(
                buttontype,
                GUIElements.GUIEnumerations.ButtonDock.Top,
                selectiontype.ToString(),
                string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "mute.png"), null
            );
            button.UpdateFrame(new Thickness(10), Brushes.Black, 0.6, Brushes.Black, new Thickness(1));
            button.UpdateButton(Colors.Transparent, null, false);
            button.UpdatePicture(null, 20, 20);
            button.UpdateCaption(Colors.White, Colors.Black, string.Empty);            
            if (selectiontype == GUITogglePanelSelectionType.Single) { _single_buttons.Add(button); }
            else { _multi_buttons.Add(button); }
        }
    }
}
