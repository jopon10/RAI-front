﻿using RAI.Controls;
using RAI.ViewModel;
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

namespace RAI.Pages.Agricola.AnalisesSolo
{
    public partial class PageAnaliseSoloInclude : WindowBase
    {
        public AnaliseSolo analise { get; set; }

        public PageAnaliseSoloInclude()
        {
            InitializeComponent();
        }

        private void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}