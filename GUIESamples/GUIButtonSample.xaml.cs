using GUIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUIESamples
{
    /// <summary>
    /// Interaction logic for GUIButtonSample.xaml
    /// </summary>
    public partial class GUIButtonSample : Window
    {
        static Int16 row = 0;
        string button_pic = string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "default-capture.jpg");
        GUIButton gui_button;

        public GUIButtonSample()
        {
            InitializeComponent();
            WindowImage.ImageSource = new BitmapImage(new Uri(string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "bg2.jpg")));
            TestGUIButtons();
        }

        private void TestGUIButtons()
        {
            gui_button = new GUIButton();
            Grid.SetRow(gui_button, 0);
            Grid.SetColumn(gui_button, 0);
            Grid.SetRow(gui_button, row);
            Grid.SetColumn(gui_button, 1);
            Label d = new Label();
            d.Content = "Default";
            Surface.Children.Add(d);
            Surface.Children.Add(gui_button);
            row++;

            gui_button = BuildButton(
                "Normal", "GUIButton Example",
                button_pic, null,
                null, null
            );

            gui_button = BuildButton(
                 "Set Frame", "GUIButton Example",
                 button_pic, null,
                 null, null
             );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));


            gui_button = BuildButton(
                "Set Border", "GUIButton Example",
                button_pic, null,
                null, null
            );
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));


            gui_button = BuildButton(
                "Set Frame, Set Border", "GUIButton Example",
                button_pic, null,
                null, null
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));

            gui_button = BuildButton(
                "Long Caption, Not Trimmed",
                "This button has an unbelievably long caption for some unknown reason",
                button_pic, null,
                null, false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));

            gui_button = BuildButton(
                "Long Caption, Trimmed",
                "This button has an unbelievably long caption for some unknown reason",
                button_pic, null,
                null, true
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));

            gui_button = BuildButton(
                "Long Caption, Not Compensated",
                "This caption is long enough to upset the whitespace",
                button_pic, null,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));

            gui_button = BuildButton(
                "Long Caption, Compensated",
                "This caption is long enough to upset the whitespace",
                button_pic, null,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));
            gui_button.UpdateButton(null, null, true);


            gui_button = BuildButton(
                "New Dock Position",
                "New Dock is Left",
                button_pic, null,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));
            gui_button.UpdateButton(null, GUIEnumerations.ButtonDock.Left, null);

            gui_button = BuildButton(
                "New Background Color",
                "New Background Color is Lime",
                button_pic, null,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));
            gui_button.UpdateButton(Colors.Lime, null, null);


            gui_button = BuildButton(
                "Updated Caption",
                "Original Caption",
                button_pic, null,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));
            gui_button.UpdateCaption(Colors.Black, Colors.White, "New Caption");


            string new_pic = string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "second-capture.jpg");
            gui_button = BuildButton(
                "Updated Image",
                "New Image",
                button_pic, null,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));
            gui_button.UpdatePicture(new_pic, 400, 400);

            gui_button = BuildButton(
                "Toggle Image",
                "Toggle button attempt",
                button_pic, GUIEnumerations.ButtonType.Toggle,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));
            gui_button.OnLeftClick += Toggle_Click;

            gui_button = BuildButton(
                "Momentary Image",
                "Momentary button attempt",
                button_pic, GUIEnumerations.ButtonType.Momentary,
                null,
                false
            );
            gui_button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            gui_button.UpdatePanelBorder(Brushes.Blue, new Thickness(4));
            gui_button.MouseLeftButtonDown += Momentary_MouseLeftDown;
            gui_button.MouseLeftButtonUp += Momentary_MouseLeftUp;
        }

        private void Momentary_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            GUIButton button = sender as GUIButton;
            button.UpdateFrame(new Thickness(40), Brushes.Red, 0.4, Brushes.Black, new Thickness(4));
        }

        private void Momentary_MouseLeftUp(object sender, MouseButtonEventArgs e)
        {
            GUIButton button = sender as GUIButton;
            button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
        }

        private void Toggle_Click(object sender, MouseButtonEventArgs e)
        {
            GUIButton button = sender as GUIButton;
            if (button.CurrentState != GUIEnumerations.ButtonState.ToggleDown)
            {
                button.UpdateFrame(new Thickness(40), Brushes.Red, 0.4, Brushes.Black, new Thickness(4));
            }
            else
            {
                button.UpdateFrame(new Thickness(40), Brushes.Black, 0.6, Brushes.Red, new Thickness(4));
            }
            button.ToggleLeftClick();
        }

        //private void ShowMore()
        //{
        //    #region init
        //    WindowImage.ImageSource = new BitmapImage(new Uri(string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "bg2.jpg")));            

        //    string caption_text = string.Empty;
        //    string image_source = string.Empty;
        //    Brush border_brush = Brushes.Transparent;
        //    Thickness border_thickness = new Thickness(0);
        //    Size image_size = new Size(200, 200);

        //    // this is a struct to simplify creation of the Frame
        //    GUIButton.Frame FrameInfo = new GUIButton.Frame();
        //    FrameInfo.Color = Brushes.Red;
        //    FrameInfo.Opacity = 0.8;
        //    FrameInfo.Size = new Thickness(20);
        //    FrameInfo.BorderBrush = Brushes.Black;
        //    FrameInfo.BorderThickness = new Thickness(1);
        //    #endregion

        //    gui_button = BuildButton(
        //        "No Caption, Picture, Right, Set Border", string.Empty,
        //        button_pic, null,
        //        GUIButton.ButtonDock.Right, 
        //        null
        //    );
        //    gui_button.BorderBrush = Brushes.Black;
        //    gui_button.BorderThickness = new Thickness(1);


        //    gui_button = BuildButton(
        //        "TTCaption, >>>> Picture, Top, Set Border", "GUIButton Example",
        //        button_pic, null,
        //        GUIButton.ButtonDock.Top,
        //        null
        //    );
        //    gui_button.SetComponentVisualLayout(
        //        Brushes.Transparent,
        //        new Thickness(30),
        //        Brushes.Black,
        //        new Thickness(5),
        //        0d
        //    );




        //    gui_button = BuildButton(
        //        "Long Caption, Picture, Top, Set Border, Not Trimmed", 
        //        "This button has an unbelievably long caption for some unknown reason", 
        //        button_pic, null,
        //        GUIButton.ButtonDock.Top, 
        //        false
        //    );
        //    gui_button.BorderBrush = Brushes.Green;
        //    gui_button.BorderThickness = new Thickness(5);

        //    gui_button = BuildButton(
        //        "Long Caption, Picture, Top, Set Border, Trimmed", 
        //        "This button has an unbelievably long caption for some unknown reason",
        //        button_pic, null,
        //        GUIButton.ButtonDock.Top, 
        //        true
        //    );
        //    gui_button.BorderBrush = Brushes.Green;
        //    gui_button.BorderThickness = new Thickness(5);

        //    gui_button = BuildButton(
        //        "Long Caption, Picture, Bottom, Set Border, Not Trimmed (Allow Compensate)",                
        //        "Slightly larger caption, should compensate",
        //        button_pic, null,
        //        GUIButton.ButtonDock.Bottom,
        //        false
        //    );
        //    gui_button.BorderBrush = Brushes.Green;
        //    gui_button.BorderThickness = new Thickness(5);

        //    gui_button = BuildButton(
        //        "Long Caption, Picture, Top, Set Border, Not Trimmed (Allow Compensate), Set Frame",
        //        "Slightly larger caption, should compensate",
        //        button_pic, null,
        //        GUIButton.ButtonDock.Top,
        //        false
        //    );
        //    gui_button.BorderBrush = Brushes.Green;
        //    gui_button.BorderThickness = new Thickness(5);
        //    FrameInfo.Color = Brushes.Yellow;
        //    FrameInfo.Opacity = 0.7;
        //    gui_button.SetTransparency(FrameInfo);

        //    gui_button = BuildButton(
        //        "Long Caption, Picture, Toggle, Top, Set Border, Not Trimmed (Allow Compensate), Set Frame",
        //        "Slightly larger caption, should compensate",
        //        button_pic, GUIButton.ButtonType.Toggle,
        //        GUIButton.ButtonDock.Top,
        //        false
        //    );
        //    gui_button.BorderBrush = Brushes.Green;
        //    gui_button.BorderThickness = new Thickness(5);
        //    FrameInfo.Color = Brushes.Yellow;
        //    FrameInfo.Opacity = 0.7;
        //    gui_button.SetTransparency(FrameInfo);
        //    gui_button.OnLeftClick += LeftClick_GUIButton;

        //    gui_button = BuildButton(
        //        "Long Caption, Picture, Top, Set Border, Not Trimmed (Allow Compensate), Set Frame",
        //        "Slightly larger caption, should compensate",
        //        button_pic, null,
        //        GUIButton.ButtonDock.Top,
        //        false
        //    );
        //    gui_button.BorderBrush = Brushes.Green;
        //    gui_button.BorderThickness = new Thickness(5);
        //    FrameInfo.Color = Brushes.Black;
        //    FrameInfo.Opacity = 0.5;
        //    gui_button.SetTransparency(FrameInfo);

        //    gui_button = BuildButton(
        //        "Long Caption, Picture, Top, No Border, Not Trimmed (Allow Compensate), Set Frame, Frame Border",
        //        "Slightly larger caption, should compensate",
        //        button_pic, null,
        //        GUIButton.ButtonDock.Top,
        //        false
        //    );
        //    FrameInfo.Color = Brushes.Black;
        //    FrameInfo.Opacity = 0.5;
        //    FrameInfo.BorderBrush = Brushes.Red;
        //    FrameInfo.BorderThickness = new Thickness(3);
        //    gui_button.SetTransparency(FrameInfo);

        //}


        private void LeftClick_GUIButton(object sender, MouseButtonEventArgs e)
        {
            GUIButton button = sender as GUIButton;
            button.ToggleLeftClick();
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
            AddToGrid(instancetitle, guibutton_example);
            return guibutton_example;
        }

        private void AddToGrid(string label, GUIButton button)
        {
            TextBlock title = new TextBlock();
            title.TextWrapping = TextWrapping.Wrap;
            title.Foreground = Brushes.White;
            title.FontSize = 18;
            title.FontWeight = FontWeights.ExtraBold;
            title.Text = label;

            Grid.SetRow(title, row);
            Grid.SetColumn(title, 0);
            
            Grid.SetRow(button, row);
            Grid.SetColumn(button, 1);

            Surface.Children.Add(title);
            Surface.Children.Add(button);

            row++;
        }
        
    }
}
