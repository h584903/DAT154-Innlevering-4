using HotelLibrary.models;
using HotelLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelLibrary.Repositories;
using Microsoft.Maui.Controls;

namespace Maui.ViewModels
{
    public class CleanerViewModel : BaseViewModel
    {
        private readonly ITaskRepository _taskRepository;
        private ObservableCollection<TaskModel> tasks;
        public ObservableCollection<TaskModel> Tasks
        {
            get => tasks;
            set => SetProperty(ref tasks, value);
        }
        
        public ICommand UpdateStatusCommand { get; }

        public CleanerViewModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            LoadTasks();
            UpdateStatusCommand = new Command<TaskModel>(UpdateStatus);
        }
        private async void LoadTasks()
        {
            var tasksFromRepo = await _taskRepository.GetByTypeAsync("Cleaning");
            Tasks = new ObservableCollection<TaskModel>(tasksFromRepo);
        }
        private async void UpdateStatus(TaskModel task)
        {
            task.Status = "Completed";
            await _taskRepository.UpdateAsync(task);
            LoadTasks(); // Refresh the list
        }
    }
}
