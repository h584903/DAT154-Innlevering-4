using HotelLibrary.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelLibrary.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(int id);
        System.Threading.Tasks.Task AddAsync(Reservation reservation);
        System.Threading.Tasks.Task UpdateAsync(Reservation reservation);
        System.Threading.Tasks.Task DeleteAsync(int id);
        System.Threading.Tasks.Task CheckInAsync(int reservationId);
        System.Threading.Tasks.Task CheckOutAsync(int reservationId);
    }
}
