using HotelLibrary.models;
using HotelLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF.ViewModels
{
    public class EditRoomViewModel : BaseViewModel
    {
        private readonly IRoomRepository _roomRepository;

        public Room Room { get; set; }

        public ICommand SaveCommand { get; }

        public EditRoomViewModel(IRoomRepository roomRepository, Room room)
        {
            _roomRepository = roomRepository;
            Room = room;
            SaveCommand = new RelayCommand(Save);
        }

        private async void Save()
        {
            await _roomRepository.UpdateAsync(Room);
            MessageBox.Show("Room updated successfully.");
            CloseWindow();
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }
    }
}
