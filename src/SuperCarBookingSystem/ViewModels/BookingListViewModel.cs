using SuperCarBookingSystem.Models;

namespace SuperCarBookingSystem.ViewModels;

public class BookingListViewModel
{
    public IEnumerable<Booking> Bookings { get; set; }
}