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
namespace textEditorTask5
{
    /// <summary>
    /// Логика взаимодействия для TextEditorToolbar.xaml
    /// </summary>
    public partial class TextEditorToolbar : UserControl
    {
        public TextEditorToolbar()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            for (double i = 8; i < 49; i += 2)
            {
                fontSize.Items.Add(i);
            }
            fontColor.Items.Add("Black");
            fontColor.Items.Add("Red");
            fontColor.Items.Add("Orange");
            fontColor.Items.Add("Green");
            fontColor.Items.Add("Blue");
            fontColor.Items.Add("Yellow");
            fontColor.Items.Add("Purple");
            fontColor.Items.Add("White");
        }
    }
}