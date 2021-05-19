using NAudio.Wave;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using VirtualMixer.Models;

namespace VirtualMixer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AudioRouteModel router = null;
        string lastSelectedInput;
        string lastSelectedOutput;

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(@"E:\in.txt") && File.Exists(@"E:\out.txt"))
            {
                lastSelectedInput = File.ReadAllText(@"E:\in.txt");
                lastSelectedOutput = File.ReadAllText(@"E:\out.txt");

                inputDevice.SelectedValue = lastSelectedInput;
                outputDevice.SelectedValue = lastSelectedOutput;
            }
        }

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                (sender as ComboBox).Items.Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(router != null)
            {
                router.Stop();
            }

            lastSelectedInput = inputDevice.Text;
            lastSelectedOutput = outputDevice.Text;
            
            router = new AudioRouteModel(lastSelectedInput, lastSelectedOutput).Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.WriteAllText(@"E:\in.txt", lastSelectedInput);
            File.WriteAllText(@"E:\out.txt", lastSelectedOutput);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(sender is Slider)
            {
                float vol = (float)(sender as Slider).Value;
                router.UpdateVolume(vol);
            }
        }


    }
}
