using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading;
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
using PrsnLib;

namespace csSharpJWPF
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /* Button myButton = new Button();
             myButton.Width = 100;
             myButton.Height = 30;
             myButton.Content = "Кнопка";
             layoutGrid.Children.Add(myButton);
            */
        }


        public void Button_click_List(object e, EventArgs args)
        {
            PathContent path = new PathContent();
            FileInfo fileInf = new FileInfo(path.Get_Path());
            LstMen.Opacity = LstMen.Opacity - 0.05;
            if (fileInf.Exists == true)
            {
                Window1 window1 = new Window1();
                this.Close();
                window1.Show();
            }
            else
            {
                StreamWriter sw = File.CreateText(path.Get_Path());
                Window1 window1 = new Window1();
                this.Close();
                window1.Show();
            }
        }
        public void Button_click_Add(object e, EventArgs args)
        {
            Add.Opacity = Add.Opacity - 0.05;
            Window2 win2 = new Window2();
            this.Close();
            win2.Show();
        }
        public void Exit_click(object e, EventArgs args)
        {
            Close();
        }

        /*
public void Button_click1(object e, RoutedEventArgs arg)
{
   First.Content = "Pervii";
   First.Width = First.Width + 20;
   First.Height = First.Height + 20;
   First.Opacity = First.Opacity - 0.0005;
}
*/
    }
}