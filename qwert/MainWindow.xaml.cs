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

namespace qwert
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        qwertEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new qwertEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridRental.ItemsSource = context.ClientService.ToList();
        }

       
        private void BtnAddData_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteData_Click_1(object sender, RoutedEventArgs e)
        {
            var currentRental = DataGridRental.SelectedItem as ClientService;
            if (currentRental == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удадить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.ClientService.Remove(currentRental);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEditData_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
