using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using NoterApp.View.UserControls;

namespace NoterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            string QuestionLeavingWithoutSaving = "You haven't save the file yet!\nProceed to EXIT?";
            string CaptionLeaveWithoutSaving = "File might get lost";
            MessageBoxResult MessageBoxLeavingResult;
            if (String.IsNullOrEmpty(TextCanvas.TextInLine))
            {
                Close();
            }
            else
            {
                
                MessageBoxLeavingResult = MessageBox.Show(
                    QuestionLeavingWithoutSaving, 
                    CaptionLeaveWithoutSaving, 
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Warning);
                if (MessageBoxLeavingResult == MessageBoxResult.Yes)
                {
                    Close();
                }
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
                this.DragMove();
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MenuItem_OpenFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            if (openFile.ShowDialog() is true)
            {
                TextCanvas.FileName = openFile.SafeFileName;
                TextCanvas.TextInLine = File.ReadAllText(openFile.FileName);
            }
        }

        private void MenuItem_NewFile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
