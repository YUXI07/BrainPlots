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

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool flag = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var txtButton = sender as Button;
            if (txtButton == null)
                return;
            int intIndex = 0;
            switch (txtButton.Content.ToString())
            {
                case "第一步":
                    intIndex = 0; break;
                case "第二步":
                    intIndex = 1; break;
                case "第三步":
                    intIndex = 2; break;
                case "第四步":
                    intIndex = 3; break;
                default:

                    break;
            }


            if (flag)
            {
                stepBar1.Next(intIndex);

            }
            else
            {
                flag = false;
                stepBar1.Prev(intIndex);
            }
        }
    }
}