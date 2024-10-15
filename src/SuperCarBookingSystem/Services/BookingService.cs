using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using SuperCarBookingSystem.Models;

namespace SuperCarBookingSystem.Services;

public class BookingService(CarBookingDbContext carDbContext) : IBookingService
{
    public void AddBooking(Booking newBooking)
    {
        var bookedCar = carDbContext.Cars.FirstOrDefault(c => c.Id == newBooking.CarId);
        if (bookedCar == null)
        {
            throw new ArgumentException("The car to be booked cannot be found.");
        }

        newBooking.CarModel = bookedCar.Model;

        bookedCar.IsBooked = true;
        carDbContext.Cars.Update(bookedCar);

        carDbContext.Bookings.Add(newBooking);

        carDbContext.ChangeTracker.DetectChanges();
        Console.WriteLine(carDbContext.ChangeTracker.DebugView.LongView);

        carDbContext.SaveChanges();
    }

    public void DeleteBooking(Booking booking)
    {
        var bookedCar = carDbContext.Cars.FirstOrDefault(c => c.Id == booking.CarId);
        bookedCar.IsBooked = false;

        var bookingToDelete = carDbContext.Bookings.FirstOrDefault(b => b.Id == booking.Id);

        if (bookingToDelete != null)
        {
            carDbContext.Bookings.Remove(bookingToDelete);
            carDbContext.Cars.Update(bookedCar);

            carDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(carDbContext.ChangeTracker.DebugView.LongView);

            carDbContext.SaveChanges();
        }
        else
        {
            throw new ArgumentException("The booking to delete cannot be found.");
        }
    }

    public void EditBooking(Booking updatedBooking)
    {
        var bookingToUpdate = carDbContext.Bookings.FirstOrDefault(b => b.Id == updatedBooking.Id);


        if (bookingToUpdate != null)
        {
            bookingToUpdate.StartDate = updatedBooking.StartDate;
            bookingToUpdate.EndDate = updatedBooking.EndDate;


            carDbContext.Bookings.Update(bookingToUpdate);

            carDbContext.ChangeTracker.DetectChanges();
            carDbContext.SaveChanges();

            Console.WriteLine(carDbContext.ChangeTracker.DebugView.LongView);
        }
        else
        {
            throw new ArgumentException("Booking to be updated cannot be found");
        }

    }

    public IEnumerable<Booking> GetAllBookings()
    {
        return carDbContext.Bookings.OrderBy(b => b.StartDate).AsNoTracking().AsEnumerable<Booking>();
    }

    public Booking? GetBookingById(ObjectId id)
    {
        return carDbContext.Bookings.AsNoTracking().FirstOrDefault(b => b.Id == id);
    }
}