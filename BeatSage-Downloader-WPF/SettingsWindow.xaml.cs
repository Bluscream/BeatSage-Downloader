﻿using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using System.Windows.Forms;

namespace BeatSage_Downloader
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : MetroWindow
    {
        public SettingsWindow()
        {
            InitializeComponent();
            OutputDirectoryTextBox.Text = Properties.Settings.Default.outputDirectory;

            AutomaticExtractionCheckBox.IsChecked = Properties.Settings.Default.automaticExtraction;
            YoutubeDLCheckBox.IsChecked = Properties.Settings.Default.preferYoutubeDL;

        }

        public void SelectOutputDirectory(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                
                if (result.ToString() == "OK" && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    OutputDirectoryTextBox.Text = dialog.SelectedPath;

                    Properties.Settings.Default.outputDirectory = dialog.SelectedPath;
                    Properties.Settings.Default.Save();
                }

            }
        }

        public void SaveButton(object sender, RoutedEventArgs e)
        {
            
            Properties.Settings.Default.automaticExtraction = Properties.Settings.Default.automaticExtraction = (bool)AutomaticExtractionCheckBox.IsChecked;
            Properties.Settings.Default.preferYoutubeDL = Properties.Settings.Default.preferYoutubeDL = (bool)YoutubeDLCheckBox.IsChecked;
            Properties.Settings.Default.outputDirectory = OutputDirectoryTextBox.Text;
            
            Properties.Settings.Default.Save();
            this.Close();
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
