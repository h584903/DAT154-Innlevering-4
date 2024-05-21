﻿using HotelLibrary.models;
using HotelLibrary.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Maui.ViewModels
{
    public class MaintainerViewModel : BaseViewModel
    {
        private readonly ITaskRepository _taskRepository;
        private ObservableCollection<TaskModel> tasks;
        public ObservableCollection<TaskModel> Tasks
        {
            get => tasks;
            set => SetProperty(ref tasks, value);
        }

        public ICommand UpdateStatusCommand { get; }

        public MaintainerViewModel(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            LoadTasks();
            UpdateStatusCommand = new Command<TaskModel>(UpdateStatus);
        }

        private async void LoadTasks()
        {
            var tasksFromRepo = await _taskRepository.GetByTypeAsync("Maintenance");
            Tasks = new ObservableCollection<TaskModel>(tasksFromRepo);
        }

        private async void UpdateStatus(TaskModel task)
        {
            string newStatus = await Application.Current.MainPage.DisplayActionSheet(
                "Select new status",
                "Cancel",
                null,
                "New", "In Progress", "Completed");

            if (!string.IsNullOrEmpty(newStatus) && newStatus != "Cancel")
            {
                task.Status = newStatus;
                await _taskRepository.UpdateAsync(task);
                LoadTasks(); // Refresh the list
            }
        }
    }
}
