﻿using Microsoft.Win32;
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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Agent _currentAgent = new Agent();
        public bool CheckStatusEdit = false;
        public AddEditPage(Agent SelectedAgent)
        {
            InitializeComponent();

            if (SelectedAgent != null)
            {
                _currentAgent = SelectedAgent;
                EditComb.SelectedIndex = _currentAgent.AgentTypeID-1;
                CheckStatusEdit = true;
            }
            if (CheckStatusEdit == false)
            {
                DeleteButton.IsEnabled = false;
            }
            DataContext = _currentAgent;
        }

        private void LogoEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            if (myOpenFileDialog.ShowDialog() == true)
            {
                _currentAgent.Logo = myOpenFileDialog.FileName;
                LogoImageEdit.Source = new BitmapImage(new Uri(myOpenFileDialog.FileName));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentAgent.Title))
                errors.AppendLine("Укажите наименование агента!");

            if (EditComb.SelectedItem == null)
                errors.AppendLine("Укажите тип агента");

            if (string.IsNullOrWhiteSpace(_currentAgent.Priority.ToString()))
                errors.AppendLine("Укажите приоритет");

            if (string.IsNullOrWhiteSpace(_currentAgent.Address))
                errors.AppendLine("Укажите адрес");

            if (string.IsNullOrWhiteSpace(_currentAgent.INN))
                errors.AppendLine("Укажите ИНН");
            

            if (string.IsNullOrWhiteSpace(_currentAgent.KPP))
                errors.AppendLine("Укажите КПП");
            

            if (string.IsNullOrWhiteSpace(_currentAgent.DirectorName))
                errors.AppendLine("Укажите имя директора");

            if (string.IsNullOrWhiteSpace(_currentAgent.Phone))
                errors.AppendLine("Укажите номер телефона");

            if (string.IsNullOrWhiteSpace(_currentAgent.Email))
                errors.AppendLine("Укажите email");

            if (_currentAgent.Priority < 0)
                errors.AppendLine("Укажите корректный приоритет!");

            _currentAgent.AgentTypeID = EditComb.SelectedIndex+1;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            var allAgents = Timerzyanov_GlazkiEntities.GetContext().Agent.ToList();
            allAgents = allAgents.Where(p => p.Title == _currentAgent.Title).ToList();

            if (allAgents.Count == 0 || CheckStatusEdit == true)
            {
                if (_currentAgent.ID == 0)
                    Timerzyanov_GlazkiEntities.GetContext().Agent.Add(_currentAgent);
                try
                {
                    Timerzyanov_GlazkiEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    if (ex.InnerException != null)
                        MessageBox.Show(ex.InnerException.ToString());
                    MessageBox.Show("Ошибка" + ex.HResult + "\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Агент уже существует!");
                return;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var currentAgent = (sender as Button).DataContext as Agent;

            var CurrentProductSale = Timerzyanov_GlazkiEntities.GetContext().ProductSale.ToList();
            CurrentProductSale = CurrentProductSale.Where(p => p.AgentID == _currentAgent.ID).ToList();

            var CurrentPriorityHistory = Timerzyanov_GlazkiEntities.GetContext().AgentPriorityHistory.ToList();
            CurrentPriorityHistory=CurrentPriorityHistory.Where(p=>p.AgentID==_currentAgent.ID).ToList();

            if (CurrentProductSale.Count != 0)
                MessageBox.Show("Невозможно выполнить удаление, так как у агента есть продажи!");
            else
            {
                if (MessageBox.Show("Вы точно хотите выполнить удаление?", "Внимание!",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Timerzyanov_GlazkiEntities.GetContext().Agent.Remove(_currentAgent);
                        //Timerzyanov_GlazkiEntities.GetContext().AgentPriorityHistory.Remove(_currentAgent);
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

        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AgentSalePage(_currentAgent));
        }
    }
}
