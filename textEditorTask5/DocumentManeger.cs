using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Controls;
using textEditorTask5;
using System.IO;
using System.Windows.Media;
using Microsoft.Win32;
namespace textEditorTask5
{
    class DocumentManeger
    {
        private string _currentFile;
        private RichTextBox _textBox;
        public DocumentManeger(RichTextBox textBox)
        {
            _textBox = textBox;
        }
        public void NewDocument()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to save your existing document first?", "Save");
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.SaveDocument();
            }
            if (!String.IsNullOrEmpty(_currentFile))
            {
                this._currentFile = null;
            }
            this._textBox.Document.Blocks.Clear();
        }
        public bool OpenDocument()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".rtf";
            dlg.Filter = "Rich Text Format (.rtf)|*.rtf";
            if (dlg.ShowDialog() == true)
            {
                _currentFile = dlg.FileName;
                using (Stream stream = dlg.OpenFile())
                {
                    TextRange range = new TextRange(_textBox.Document.ContentStart, _textBox.Document.ContentEnd);
                    range.Load(stream, DataFormats.Rtf);
                }
                return true;
            }
            else return false;
        }
        public bool SaveDocument()
        {

            if (string.IsNullOrEmpty(_currentFile)) return SaveDocumentAs();
            else
            {
                using (Stream stream = new FileStream(_currentFile, FileMode.Create))
                {
                    TextRange range = new TextRange(_textBox.Document.ContentStart, _textBox.Document.ContentEnd);
                    range.Save(stream, DataFormats.Rtf);
                }
                return true;
            }
        }
        public bool SaveDocumentAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf";
            if (dlg.ShowDialog() == true)
            {
                _currentFile = dlg.FileName;
                return SaveDocument();
            }
            return false;
        }
        public bool PrintDocument()
        {//create a print dialog object and set options.
            this.SaveDocument();
            PrintDialog pDialog = new PrintDialog();
            if (pDialog.ShowDialog() == true)
            {
                pDialog.PrintVisual(this._textBox as Visual, "Rich text box");
                return true;
            }
            return false;
        }
        public bool CloseDocument(MainWindow window)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to save your existing document first", "Save");
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (this.SaveDocument() == false)
                {
                    window.Close();
                }
            }
            window.Close();
            return true;
        }
        public void Undo_Click()
        {
            _textBox.Undo();
        }
        public void Redo_Click()
        {
            _textBox.Redo();
        }
        public void Cut_Click()
        {
            _textBox.Cut();
        }
        public void Copy_Click()
        {
            _textBox.Copy();
        }
        public void Paste_Click()
        {
            _textBox.Paste();
        }
        public void Delete_Click()
        {
            _textBox.Document.Blocks.Clear();
        }
        public void Bold_Click()
        {
            _textBox.FontWeight = FontWeights.Bold;
        }
        public void Italic_Click()
        {
            _textBox.FontStyle = FontStyles.Italic;
        }
        public void ApplyToSelection(DependencyProperty property, object value)
        {
            if (value != null)
            {
                _textBox.Selection.ApplyPropertyValue(property, value);
            }
        }
    }
}