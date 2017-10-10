using System;
using System.IO;
using Microsoft.Win32;
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
using System.Windows.Forms;
using System.Drawing;

namespace MyNotepad
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Text { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_New(object sender, RoutedEventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Selection.Text = "";
        }

        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Selection.Text = "";

            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";

            // Show open file dialog box
            Nullable<bool> result = ofd.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                richTextBox1.Selection.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void MenuItem_Save(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
            
            // Show save file dialog box
            Nullable<bool> result = sfd.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = sfd.FileName;
                richTextBox1.SelectAll();
                File.WriteAllText(filename, richTextBox1.Selection.Text);
            }
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Font(object sender, RoutedEventArgs e)
        {
            FontDialog fd = new FontDialog();
            System.Windows.Forms.DialogResult dr = fd.ShowDialog();

            if(dr != System.Windows.Forms.DialogResult.Cancel)
            {
                richTextBox1.FontFamily = new System.Windows.Media.FontFamily(fd.Font.Name);
            }
    
        }

        private void MenuItem_Background_Color(object sender, RoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            System.Windows.Forms.DialogResult dr = cd.ShowDialog();

            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                var wpfColor = System.Windows.Media.Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);

                var brush = new SolidColorBrush(wpfColor);

                this.richTextBox1.Background = brush;
            }
        }

        private void MenuItem_Help(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("MyNotepad\nVersion 1.0.0\nCreated by Karol Minuth");
        }
    }
}
