using HotelLibrary.models;
using HotelLibrary.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Maui.ViewModels
{
    public class ServicePersonViewModel : BaseViewModel
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IRoomRepository _roomRepository;
        private ObservableCollection<TaskModel> tasks;
        public ObservableCollection<TaskModel> Tasks
        {
            get => tasks;
            set => SetProperty(ref tasks, value);
        }

        public ICommand UpdateStatusCommand { get; }
        public ICommand AddNoteCommand { get; }

        public ServicePersonViewModel(ITaskRepository taskRepository, IRoomRepository roomRepository)
        {
            _taskRepository = taskRepository;
            _roomRepository = roomRepository;
            LoadTasks();
            UpdateStatusCommand = new Command<TaskModel>(UpdateStatus);
            AddNoteCommand = new Command<TaskModel>(AddNote);
        }

        private async void LoadTasks()
        {
            var tasksFromRepo = await _taskRepository.GetByTypeAsync("Service");
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

                if (newStatus == "Completed")
                {
                    await _roomRepository.MarkAsServicedAsync(task.RoomId);
                } else
                {
                    await _roomRepository.MarkAsNeedsRoomServiceAsync(task.RoomId);
                }

                LoadTasks(); // Refresh the list
            }
        }

        private async void AddNote(TaskModel task)
        {
            string note = await Application.Current.MainPage.DisplayPromptAsync(
                "Add Note",
                "Enter your note:",
                "OK",
                "Cancel",
                "Note",
                maxLength: 250,
                keyboard: Keyboard.Text,
                initialValue: task.Notes);

            if (!string.IsNullOrEmpty(note))
            {
                task.Notes = note;
                await _taskRepository.UpdateAsync(task);
                LoadTasks(); // Refresh the list
            }
        }
    }
}
