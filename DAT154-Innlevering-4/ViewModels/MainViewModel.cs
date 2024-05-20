using HotelLibrary.models;
using HotelLibrary.Repositories;
using WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WPF.Views;

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
            set
            {
                if (SetProperty(ref _selectedRoom, value))
                {
                    UpdateRoomCommandStates();
                }
            }
        }

        private Reservation _selectedReservation;
        public Reservation SelectedReservation
        {
            get => _selectedReservation;
            set
            {
                if (SetProperty(ref _selectedReservation, value))
                {
                    UpdateReservationCommandStates();
                    OnPropertyChanged(nameof(CheckInCheckOutButtonContent));
                    OnPropertyChanged(nameof(CheckInCheckOutCommand));
                }
            }
        }
        
        public string CheckInCheckOutButtonContent => SelectedReservation != null && SelectedReservation.IsCheckedIn ? "Check Out" : "Check In";
        public ICommand CheckInCheckOutCommand => SelectedReservation != null && SelectedReservation.IsCheckedIn ? CheckOutCommand : CheckInCommand;



        public RelayCommand AddRoomCommand { get; }
        public RelayCommand EditRoomCommand { get; }
        public RelayCommand DeleteRoomCommand { get; }
        public RelayCommand AddReservationCommand { get; }
        public RelayCommand EditReservationCommand { get; }
        public RelayCommand DeleteReservationCommand { get; }
        public RelayCommand CheckInCommand { get; }
        public RelayCommand CheckOutCommand { get; }
        public RelayCommand MarkRoomAsNeedsCleaningCommand { get; }
        public RelayCommand MarkRoomAsNeedsMaintenanceCommand { get; }
        public RelayCommand MarkRoomAsCleanedCommand { get; }
        public RelayCommand MarkRoomAsMaintainedCommand { get; }
        public RelayCommand MarkRoomAsNeedsRoomServiceCommand { get; }


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
            CheckInCommand = new RelayCommand(_ => CheckIn());
            CheckOutCommand = new RelayCommand(_ => CheckOut());
            MarkRoomAsNeedsCleaningCommand = new RelayCommand(_ => MarkRoomAsNeedsCleaning(), _ => CanMarkRoomAsNeedsCleaning());
            MarkRoomAsNeedsMaintenanceCommand = new RelayCommand(_ => MarkRoomAsNeedsMaintenance(), _ => CanMarkRoomAsNeedsMaintenance());
            MarkRoomAsCleanedCommand = new RelayCommand(_ => MarkRoomAsCleaned(), _ => CanMarkRoomAsCleaned());
            MarkRoomAsMaintainedCommand = new RelayCommand(_ => MarkRoomAsMaintained(), _ => CanMarkRoomAsMaintained());
            MarkRoomAsNeedsRoomServiceCommand = new RelayCommand(_ => MarkRoomAsNeedsRoomService(), _ => CanMarkRoomAsNeedsRoomService());

            LoadData();
        }

        private async void LoadData()
        {
            // Henter info fra database
            var rooms = await _roomRepository.GetAllAsync();
            var reservations = await _reservationRepository.GetAllAsync();

            // Legger til rom
            Rooms.Clear();
            foreach (var room in rooms)
            {
                room.IsAvailable = _roomRepository.IsRoomAvailable(room.Id, DateTime.Today);
                Rooms.Add(room);
            }

            // Legger til reservasjoner og knytter til rom
            Reservations.Clear();
            foreach (var reservation in reservations)
            {
                // Her kommer Room inn i bildet fra modellen
                reservation.Room = rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
                Reservations.Add(reservation);
            }
        }

        private async void AddRoom()
        {
            var newRoom = new Room
            {
                Name = "New Room",
                Beds = 1,
                Size = "Medium",
                IsAvailable = true,
                NeedsCleaning = false,
                NeedsMaintenance = false,
                NeedsRoomService = false  // Default value

            };
            await _roomRepository.AddAsync(newRoom);
            Rooms.Add(newRoom);
            SelectedRoom = newRoom;
        }

        private void EditRoom()
        {
            if (SelectedRoom != null)
            {
                var editRoomViewModel = new EditRoomViewModel(_roomRepository, SelectedRoom);
                var editRoomWindow = new EditRoomWindow
                {
                    DataContext = editRoomViewModel
                };
                editRoomWindow.ShowDialog();

            }
        }

        private async void DeleteRoom()
        {
            if (SelectedRoom != null)
            {
                await _roomRepository.DeleteAsync(SelectedRoom.Id);
                Rooms.Remove(SelectedRoom);
                SelectedRoom = null;
                UpdateRoomCommandStates();
            }
        }

        private bool CanEditOrDeleteRoom()
        {
            return SelectedRoom != null;
        }

        private void AddReservation()
        {
            var newReservation = new Reservation
            {
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(1),
                IsCheckedIn = false, // Utgangspunktet er at reservasjonen ikke er sjekket inn
                CustomerName = "New Customer"

            };
            var reservationViewModel = new ReservationViewModel(_reservationRepository, Rooms, newReservation);
            var reservationWindow = new ReservationWindow
            {
                DataContext = reservationViewModel
            };
            reservationWindow.ShowDialog();

            if (reservationWindow.DialogResult == true)
            {
                Reservations.Add(newReservation);
                OnPropertyChanged(nameof(Reservations));
            }
        }

        private void EditReservation()
        {
            if (SelectedReservation != null)
            {
                var reservationViewModel = new ReservationViewModel(_reservationRepository, Rooms, SelectedReservation);
                var reservationWindow = new ReservationWindow
                {
                    DataContext = reservationViewModel
                };
                reservationWindow.ShowDialog();

                if (reservationWindow.DialogResult == true)
                {
                    var index = Reservations.IndexOf(SelectedReservation);
                    Reservations[index] = SelectedReservation;
                    OnPropertyChanged(nameof(Reservations));
                }
                LoadData();

            }
        }

        private async void DeleteReservation()
        {
            if (SelectedReservation != null)
            {
                await _reservationRepository.DeleteAsync(SelectedReservation.Id);
                Reservations.Remove(SelectedReservation);
                SelectedReservation = null;
                UpdateReservationCommandStates();
            }
        }

        private bool CanEditOrDeleteReservation()
        {
            return SelectedReservation != null;
        }
        private bool IsRoomReserved(int roomId)
        {
            foreach (var reservation in Reservations)
            {
                if (reservation.RoomId == roomId)
                {
                    return true;
                }
            }
            return false;
        }
        private async void CheckIn()
        {
            if (SelectedReservation != null)
            {
                await _reservationRepository.CheckInAsync(SelectedReservation.Id);
                SelectedReservation.IsCheckedIn = true;
                OnPropertyChanged(nameof(CheckInCheckOutButtonContent));
                OnPropertyChanged(nameof(CheckInCheckOutCommand));
                OnPropertyChanged(nameof(Reservations));
                LoadData();

            }
        }

        private async void CheckOut()
        {
            if (SelectedReservation != null)
            {
                await _reservationRepository.CheckOutAsync(SelectedReservation.Id);
                await _roomRepository.MarkAsNeedsCleaningAsync(SelectedReservation.RoomId);
                SelectedReservation.IsCheckedIn = false;
                OnPropertyChanged(nameof(CheckInCheckOutButtonContent));
                OnPropertyChanged(nameof(CheckInCheckOutCommand));
                OnPropertyChanged(nameof(Reservations));
                LoadData();


            }
        }
        private async void MarkRoomAsNeedsCleaning()
        {
            if (SelectedRoom != null)
            {
                await _roomRepository.MarkAsNeedsCleaningAsync(SelectedRoom.Id);
                LoadData();
            }
        }

        private async void MarkRoomAsNeedsMaintenance()
        {
            if (SelectedRoom != null)
            {
                await _roomRepository.MarkAsNeedsMaintenanceAsync(SelectedRoom.Id);
                LoadData();

            }
        }

        private async void MarkRoomAsCleaned()
        {
            if (SelectedRoom != null)
            {
                await _roomRepository.MarkAsCleanedAsync(SelectedRoom.Id);
                LoadData();

            }
        }

        private async void MarkRoomAsMaintained()
        {
            if (SelectedRoom != null)
            {
                await _roomRepository.MarkAsMaintainedAsync(SelectedRoom.Id);
                LoadData();
            }
        }
        private async void MarkRoomAsNeedsRoomService()
        {
            if (SelectedRoom != null)
            {
                await _roomRepository.MarkAsNeedsRoomServiceAsync(SelectedRoom.Id);
                LoadData();
            }
        }


        private void UpdateRoomCommandStates()
        {
            EditRoomCommand.RaiseCanExecuteChanged();
            DeleteRoomCommand.RaiseCanExecuteChanged();
            MarkRoomAsNeedsCleaningCommand.RaiseCanExecuteChanged();
            MarkRoomAsNeedsMaintenanceCommand.RaiseCanExecuteChanged();
            MarkRoomAsCleanedCommand.RaiseCanExecuteChanged();
            MarkRoomAsMaintainedCommand.RaiseCanExecuteChanged();
            MarkRoomAsNeedsRoomServiceCommand.RaiseCanExecuteChanged();
        }
        private void UpdateReservationCommandStates()
        {
            EditReservationCommand.RaiseCanExecuteChanged();
            DeleteReservationCommand.RaiseCanExecuteChanged();
            OnPropertyChanged(nameof(CheckInCheckOutButtonContent));
            OnPropertyChanged(nameof(CheckInCheckOutCommand));
        }
        private bool CanMarkRoomAsNeedsCleaning()
        {
            return SelectedRoom != null && !SelectedRoom.NeedsCleaning && !SelectedRoom.NeedsMaintenance;
        }

        private bool CanMarkRoomAsNeedsMaintenance()
        {
            return SelectedRoom != null && !SelectedRoom.NeedsCleaning && !SelectedRoom.NeedsMaintenance;
        }

        private bool CanMarkRoomAsCleaned()
        {
            return SelectedRoom != null && SelectedRoom.NeedsCleaning;
        }

        private bool CanMarkRoomAsMaintained()
        {
            return SelectedRoom != null && SelectedRoom.NeedsMaintenance;
        }
        private bool CanMarkRoomAsNeedsRoomService()
        {
            return SelectedRoom != null && !SelectedRoom.NeedsRoomService;
        }
    }
    

}
