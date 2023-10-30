using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace YprZadachami
{
    public partial class MainWindow : Window
    {
        private List<Task> tasks = new List<Task>();

        public MainWindow()
        {
            InitializeComponent();
            TaskDataGrid.ItemsSource = tasks;
        }

        private void UpdateDataGrid()
        {
            // Метод для обновления DataGrid
            TaskDataGrid.Items.Refresh();
        }

        private void TaskDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Обработка выбора задачи (при необходимости)
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из текстовых полей
            string taskName = TaskNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            string deadline = DeadlineTextBox.Text;
            string priority = PriorityTextBox.Text;

            // Добавляем новую задачу в список
            tasks.Add(new Task(taskName, description, deadline, priority));
            UpdateDataGrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Обновляем DataGrid
            UpdateDataGrid();
        }
    }

    public class Task : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public string Priority { get; set; }
        private bool _isCompleted;

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged("IsCompleted");
            }
        }

        public Task(string name, string description, string deadline, string priority)
        {
            Name = name;
            Description = description;
            Deadline = deadline;
            Priority = priority;
            IsCompleted = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}