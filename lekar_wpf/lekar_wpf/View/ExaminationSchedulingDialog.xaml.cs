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
using System.Windows.Shapes;

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for ExaminationSchedulingDialog.xaml
    /// </summary>
    public partial class ExaminationSchedulingDialog : Window
    {
        public ExaminationSchedulingDialog()
        {
            InitializeComponent();
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}