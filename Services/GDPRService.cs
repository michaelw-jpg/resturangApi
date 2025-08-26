using Microsoft.Extensions.Hosting;
using resturangApi.Models;
using resturangApi.Services.Iservices;
namespace resturangApi.Services
{
    public class GDPRService : BackgroundService
    {
        // This service would contain methods to handle GDPR related operations
        // i wanted to play around with OnpropertyChanged
     
        private DateTime _currentTime = DateTime.Now;
        private DateTime _lastChecked;
        private readonly IBookingService _bookingService;
        private readonly IGenericItemService _genericItemService;

        public GDPRService(IBookingService bookingService, IGenericItemService genericItemService)
        {
            _bookingService = bookingService;
            _lastChecked = _currentTime;
            _genericItemService = genericItemService;
        }

         protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Tick();
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); //simulate 24 hours with 1 minute for testing
            }
        }

        private void Tick()
        {
            
            //every 24 hours check for data to delete
            //simulate 24 hours with 1 minute for testing
            // just to try and see how/if i can get this to work
            //say the timer ticks every  minute but we want to check every 24 hours
            _currentTime = _currentTime.AddMinutes(1);

            if (_currentTime.Minute != _lastChecked.Minute) //change to Day for 24 hour check
            {
                CheckForDataToDelete().Wait();
                _lastChecked = _currentTime;
            }
            //when currentTime hits a new day do service check
            //call method to check for data to delete
        }

        private async Task CheckForDataToDelete()
        {
            // Logic to check and delete data older than a certain period
            // This is a placeholder for actual implementation
            Console.WriteLine("Checking for data to delete as per GDPR regulations...");

            var cutoffDateDelete = _currentTime.AddMonths(-6); // Example: delete data older than 6 months
            var cutoffDateAnonymize = _currentTime.AddMonths(-3); // Example: anonymize data older than 3 months

            var bookingsToDelete = await _bookingService.GetOldBookingsForGDPR(cutoffDateDelete);

            var bookingsToAnonymize = await _bookingService.GetOldBookingsForGDPR(cutoffDateAnonymize);

            if (bookingsToDelete.Any())
            {
                foreach (var booking in bookingsToDelete)
                {
                    await _genericItemService.DeleteItem<Booking>(booking.BookingId);
                    Console.WriteLine($"Deleted booking with ID: {booking.BookingId}");
                }
            }

            if (bookingsToAnonymize.Any())
            {
                foreach (var booking in bookingsToAnonymize)
                {
                  
                   if( booking.CustomerId_FK == null) 
                        continue; //if customerID is null skip to next becouse they are registered

                    booking.Name = "Anonymized";
                    booking.PhoneNumber = "Anonymized";

                    
                    await _genericItemService.UpdateItem<Booking, Booking>(booking.BookingId, booking);
                    Console.WriteLine($"Anonymized booking with ID: {booking.BookingId}");
                }
            }

        }
    }
}
