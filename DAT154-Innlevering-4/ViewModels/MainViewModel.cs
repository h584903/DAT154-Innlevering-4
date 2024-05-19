using HotelLibrary.models;
using HotelLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<Reservation> Reservations { get; set; }

        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set => SetProperty(ref _selectedRoom, value);
        }

        private Reservation _selectedReservation;
        public Reservation SelectedReservation
        {
            get => _selectedReservation;
            set => SetProperty(ref _selectedReservation, value);
        }

        public ICommand AddRoomCommand { get; }
        public ICommand EditRoomCommand { get; }
        public ICommand DeleteRoomCommand { get; }
        public ICommand AddReservationCommand { get; }
        public ICommand EditReservationCommand { get; }
        public ICommand DeleteReservationCommand { get; }

        public MainViewModel(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;

            Rooms = new ObservableCollection<Room>();
            Reservations = new ObservableCollection<Reservation>();

            AddRoomCommand = new RelayCommand(_ => AddRoom());
            EditRoomCommand = new RelayCommand(_ => EditRoom(), _ => CanEditOrDeleteRoom());
            DeleteRoomCommand = new RelayCommand(_ => DeleteRoom(), _ => CanEditOrDeleteRoom());

            AddReservationCommand = new RelayCommand(_ => AddReservation());
            EditReservationCommand = new RelayCommand(_ => EditReservation(), _ => CanEditOrDeleteReservation());
            DeleteReservationCommand = new RelayCommand(_ => DeleteReservation(), _ => CanEditOrDeleteReservation());

            LoadData();
        }

        private async void LoadData()
        {
            var rooms = await _roomRepository.GetAllAsync();
            var reservations = await _reservationRepository.GetAllAsync();

            Rooms.Clear();
            foreach (var room in rooms)
            {
                Rooms.Add(room);
            }

            Reservations.Clear();
            foreach (var reservation in reservations)
            {
                Reservations.Add(reservation);
            }
        }

        private void AddRoom()
        {
            // Implement logic to add room
        }

        private void EditRoom()
        {
            // Implement logic to edit selected room
        }

        private void DeleteRoom()
        {
            // Implement logic to delete selected room
        }

        private bool CanEditOrDeleteRoom()
        {
            return SelectedRoom != null;
        }

        private void AddReservation()
        {
            // Implement logic to add reservation
        }

        private void EditReservation()
        {
            // Implement logic to edit selected reservation
        }

        private void DeleteReservation()
        {
            // Implement logic to delete selected reservation
        }

        private bool CanEditOrDeleteReservation()
        {
            return SelectedReservation != null;
        }
    }
    

}
