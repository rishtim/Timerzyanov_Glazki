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

namespace Timerzyanov_Glazki
{
    /// <summary>
    /// Логика взаимодействия для AgentSalePage.xaml
    /// </summary>
    public partial class AgentSalePage : Page
    {
        private Agent currentAgent = new Agent();
        public AgentSalePage(Agent agent)
        {
            InitializeComponent();
            currentAgent = agent;
            var currentSales = Timerzyanov_GlazkiEntities.GetContext().ProductSale.ToList();
            currentSales = currentSales.Where(p => p.AgentID == currentAgent.ID).ToList();
            AgentSaleListView.ItemsSource = currentSales;
        }

        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddSalesPage(currentAgent as Agent));
        }

        public void UpdateSales()
        {
            var currentProduct = Timerzyanov_GlazkiEntities.GetContext().ProductSale.ToList();
            AgentSaleListView.ItemsSource = currentProduct.Where(p => p.AgentID == currentAgent.ID);
        }
        private void DeleteSales_Click(object sender, RoutedEventArgs e)
        {
            var currentSale = (sender as Button).DataContext as ProductSale;
            var currentSalesList = Timerzyanov_GlazkiEntities.GetContext().ProductSale.ToList();
            currentSalesList = currentSalesList.Where(p => p.ID == currentSale.ID).ToList();
            if (currentSalesList.Count != 0)
            {
                if (MessageBox.Show("Вы точно хотите выполнить удаление?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Timerzyanov_GlazkiEntities.GetContext().ProductSale.Remove(currentSale);
                        Timerzyanov_GlazkiEntities.GetContext().SaveChanges();
                        Manager.MainFrame.GoBack();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateSales();
        }
    }
}
