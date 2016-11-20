﻿using System;
using System.Windows;
using Advanced_PortChecker.Classes;

namespace Advanced_PortChecker.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {

        #region Variables
        private MainWindow _mw;
        #endregion

        public SettingsWindow(MainWindow mainWindow)
        {
            _mw = mainWindow;

            InitializeComponent();
            ChangeVisualStyle();
            LoadSettings();
        }

        /// <summary>
        /// Change the visual style of the controls, depending on the settings.
        /// </summary>
        private void ChangeVisualStyle()
        {
            StyleManager.ChangeStyle(this);
        }

        /// <summary>
        /// Change the GUI to represent the current settings.
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                ChbAutoUpdate.IsChecked = Properties.Settings.Default.AutoUpdate;

                ChbStyle.SelectedValue = Properties.Settings.Default.VisualStyle;
                CpMetroBrush.Color = Properties.Settings.Default.MetroColor;
                IntBorderThickness.Value = Properties.Settings.Default.BorderThickness;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advanced PortChecker", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ChbAutoUpdate.IsChecked != null) Properties.Settings.Default.AutoUpdate = ChbAutoUpdate.IsChecked.Value;
                Properties.Settings.Default.VisualStyle = ChbStyle.Text;

                Properties.Settings.Default.MetroColor = CpMetroBrush.Color;
                if (IntBorderThickness.Value != null) Properties.Settings.Default.BorderThickness = (int)IntBorderThickness.Value;

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advanced PortChecker", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
