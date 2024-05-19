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
    public class ReservationViewModel : BaseViewModel
    {
        private readonly IReservationRepository _reservationRepository;

        public Reservation Reservation { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                if (Reservation != null)
                {
                    Reservation.Room = value;
                    OnPropertyChanged(nameof(SelectedRoom));
                    OnPropertyChanged(nameof(Reservation.Room.Name));
                }
            }
        }

        public ReservationViewModel(IReservationRepository reservationRepository, ObservableCollection<Room> rooms, Reservation reservation = null)
        {
            _reservationRepository = reservationRepository;
            Rooms = rooms;
            Reservation = reservation ?? new Reservation();
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
            if (reservation != null)
            {
                SelectedRoom = rooms?.FirstOrDefault(r => r.Id == reservation.RoomId);
            }
        }

        private async void Save()
        {
            if (Reservation.Id == 0)
            {
                await _reservationRepository.AddAsync(Reservation);
            }
            else
            {
                await _reservationRepository.UpdateAsync(Reservation);
            }
            Reservation.Room = SelectedRoom;
            MessageBox.Show("Reservation saved successfully.");
            CloseWindow(true);
        }
        private void Cancel()
        {
            CloseWindow(false);
        }
        private void CloseWindow(bool result)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.DialogResult = result;
                    window.Close();
                }
            }
        }
    }
}
