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
using textEditorTask5;

namespace textEditorTask5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DocumentManeger _documentmanager;
        public MainWindow()
        {
            InitializeComponent();
            _documentmanager = new DocumentManeger(body);
            if (_documentmanager.OpenDocument())
            {
                status.Text = "Document Loaded";
            }
        }
        private void toolBar_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.OriginalSource as Button;
            if (button == null) return;
            switch (button.Name)
            {
                case "_Open":
                    _documentmanager.OpenDocument();
                    break;
                case "_Save":
                    _documentmanager.SaveDocument();
                    break;
                case "_Cut":
                    _documentmanager.Cut_Click();
                    break;
                case "_Copy":
                    _documentmanager.Copy_Click();
                    break;
                case "_Paste":
                    _documentmanager.Paste_Click();
                    break;
                case "boldButton":
                    _documentmanager.Bold_Click();
                    break;
                case "italicButton":
                    _documentmanager.Italic_Click();
                    break;
                default: break;
            }
            body.Focus();
        }
        private void ToolBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox source = e.OriginalSource as ComboBox;
            if (source == null) return;
            switch (source.Name)
            {
                case "fonts"://change the font family
                    _documentmanager.ApplyToSelection(TextBlock.FontFamilyProperty, source.SelectedItem);
                    break;
                case "fontSize"://change the font size
                    _documentmanager.ApplyToSelection(TextBlock.FontSizeProperty, source.SelectedItem);
                    break;
                case "fontColor":
                    _documentmanager.ApplyToSelection(TextBlock.BackgroundProperty, source.SelectedItem);
                    break;
            }
            body.Focus();
        }
        private void menu_Click_1(object sender, RoutedEventArgs e)
        {
            MenuItem menu = e.OriginalSource as MenuItem;
            switch (menu.Name)
            {
                case "New":
                    _documentmanager.NewDocument();
                    break;
                case "Open":
                    _documentmanager.OpenDocument();
                    break;
                case "Save":
                    _documentmanager.SaveDocument();
                    break;
                case "Save_As":
                    _documentmanager.SaveDocumentAs();
                    break;
                case "Print":
                    _documentmanager.PrintDocument();
                    break;
                case "Close":
                    _documentmanager.CloseDocument(this);
                    break;
                case "Undo":
                    _documentmanager.Undo_Click();
                    break;
                case "Redo":
                    _documentmanager.Redo_Click();
                    break;
                case "Cut":
                    _documentmanager.Cut_Click();
                    break;
                case "Copy":
                    _documentmanager.Copy_Click();
                    break;
                case "Paste":
                    _documentmanager.Paste_Click();
                    break;
                case "Delete":
                    _documentmanager.Delete_Click();
                    break;
                default: break;
            }
        }
    }
}