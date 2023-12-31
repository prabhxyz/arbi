﻿using System;
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
using System.Windows.Threading;

namespace Arbi
{
    /// <summary>
    /// Interaction logic for browserActivities.xaml
    /// </summary>
    public partial class browserActivities : Window
    {
        /// <summary>
        /// 
        /// Most of the code below is just there to navigates between the pages.
        /// 
        /// </summary>

        public browserActivities()
        {
            InitializeComponent();
            homeBrowse hb = new homeBrowse();
            browseFrame.Content = hb;
            ttlPointsLabel.Content = globalVar.ttlPoints;
            var _activeTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(15)
            };
            _activeTimer.Tick += delegate (object sender, EventArgs e) {
                recheckPoints();
            };
            _activeTimer.Start();
        }

        public void recheckPoints()
        {
            ttlPointsLabel.Content = globalVar.ttlPoints;
        }

        // To Help Move Around The App
        private void MainBrowse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void exitBtnClick(object sender, RoutedEventArgs e)
        {
            globalVar gv = new globalVar();
            gv.saveAll();
            Application.Current.Shutdown();
        }

        private void lastBtn_Click(object sender, RoutedEventArgs e)
        {
            share s = new share();
            browseFrame.Content = s;
        }

        private void firstBtn_Click(object sender, RoutedEventArgs e)
        {
            homeBrowse hb = new homeBrowse();
            browseFrame.Content = hb;
        }

        private void secondBtn_Click(object sender, RoutedEventArgs e)
        {
            random r = new random();
            browseFrame.Content = r;
        }

        private void thirdBtn_Click(object sender, RoutedEventArgs e)
        {
            learnWindow lw = new learnWindow();
            lw.Show();
        }
    }
}
