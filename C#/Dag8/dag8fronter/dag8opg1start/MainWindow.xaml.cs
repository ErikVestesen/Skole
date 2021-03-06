﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dag8opg1start
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

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TopStackPanel.DataContext.ToString());
        }

        private void btnSet1_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person)TopStackPanel.DataContext;
            p.Height = 1.70; p.Weight = 70;
        }

        private void btnSet2_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person)TopStackPanel.DataContext;
            p.Height = 1.64; p.Weight = 87;

        }


        Person p = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            p = new Person { Name = "", Height = 1.8, Weight = 80 };
            TopStackPanel.DataContext = p;
            // set binding for tBoxName
            Binding binding = new Binding();
            binding.Source = p;
            binding.Path = new PropertyPath("Name");
            binding.Mode = BindingMode.TwoWay;
            tBoxName.SetBinding(TextBox.TextProperty, binding);

            // set binding for tBoxHeight
            Binding bHeight = new Binding();
            bHeight.Source = p;
            bHeight.Converter = new HeightConverter();
            bHeight.Path = new PropertyPath("Height");
            bHeight.Mode = BindingMode.TwoWay;
            tBoxHeight.SetBinding(TextBox.TextProperty, bHeight);

            // set binding for tBoxWeight
            Binding bWeight = new Binding();
            bWeight.Source = p;
            bWeight.Path = new PropertyPath("Weight");
            bWeight.Mode = BindingMode.TwoWay;
            tBoxWeight.SetBinding(TextBox.TextProperty, bWeight);

            // set binding for rectBmi
            Binding bBmi = new Binding();
            bBmi.Source = p;
            bBmi.Converter = new BMIConverter();
            bBmi.Path = new PropertyPath("BMI");
            bBmi.Mode = BindingMode.OneWay;
            rectBmi.SetBinding(Rectangle.WidthProperty, bBmi);
        }
    }
}
