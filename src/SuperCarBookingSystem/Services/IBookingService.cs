using MongoDB.Bson;
using SuperCarBookingSystem.Models;

namespace SuperCarBookingSystem.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
        Booking? GetBookingById(ObjectId id);
        void AddBooking(Booking newBooking);
        void EditBooking(Booking updatedBooking);
        void DeleteBooking(Booking bookingToDelete);
    }
}
