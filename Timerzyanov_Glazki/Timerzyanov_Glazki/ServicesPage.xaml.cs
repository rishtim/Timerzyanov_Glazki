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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Timerzyanov_Glazki
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();

            var currentAgents = Timerzyanov_GlazkiEntities.GetContext().Agent.ToList();
            AgentListView.ItemsSource = currentAgents;
            SortComb.SelectedIndex = 0;
            FilterComb.SelectedIndex = 0;

            UpdateAgents();
        }

        private void UpdateAgents()
        {
            var CurrentAgents = Timerzyanov_GlazkiEntities.GetContext().Agent.ToList();

            if (SortComb.SelectedIndex == 0)
            {
                CurrentAgents = Timerzyanov_GlazkiEntities.GetContext().Agent.ToList();
            }
            if (SortComb.SelectedIndex == 1)
            {
                CurrentAgents = CurrentAgents.OrderBy(p => p.Title).ToList();
            }
            if (SortComb.SelectedIndex == 2)
            {
                CurrentAgents = CurrentAgents.OrderByDescending(p => p.Title).ToList();
            }
            if (SortComb.SelectedIndex == 3) //скидка доделать
            {
                CurrentAgents = CurrentAgents.OrderBy(p => p.Title).ToList();
            }
            if (SortComb.SelectedIndex == 4) //скидка доделать
            {
                CurrentAgents = CurrentAgents.OrderBy(p => p.Title).ToList();
            }
            if (SortComb.SelectedIndex == 5)
            {
                CurrentAgents = CurrentAgents.OrderBy(p => p.Priority).ToList();
            }
            if (SortComb.SelectedIndex == 6)
            {
                CurrentAgents = CurrentAgents.OrderByDescending(p => p.Priority).ToList();
            }

            CurrentAgents = CurrentAgents.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.Email.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.Phone.Replace("+", "").Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


            if (FilterComb.SelectedIndex == 0)
            {
                CurrentAgents = CurrentAgents.Where(p => p.AgentTypeID==1|| p.AgentTypeID==2|| p.AgentTypeID == 3|| p.AgentTypeID == 4|| p.AgentTypeID == 5|| p.AgentTypeID == 6).ToList();
            }
            if (FilterComb.SelectedIndex == 1)
            {
                CurrentAgents = CurrentAgents.Where(p => p.AgentTypeID == 5).ToList();
            }
            if (FilterComb.SelectedIndex == 2)
            {
                CurrentAgents = CurrentAgents.Where(p => p.AgentTypeID == 4).ToList();
            }
            if (FilterComb.SelectedIndex == 3)
            {
                CurrentAgents = CurrentAgents.Where(p => p.AgentTypeID == 1).ToList();
            }
            if (FilterComb.SelectedIndex == 4)
            {
                CurrentAgents = CurrentAgents.Where(p => p.AgentTypeID == 2).ToList();
            }
            if (FilterComb.SelectedIndex == 5)
            {
                CurrentAgents = CurrentAgents.Where(p => p.AgentTypeID == 3).ToList();
            }
            if (FilterComb.SelectedIndex == 6)
            {
                CurrentAgents = CurrentAgents.Where(p => p.AgentTypeID == 6).ToList();
            }

            AgentListView.ItemsSource = CurrentAgents;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void SortComb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void FilterComb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }
    }
}
