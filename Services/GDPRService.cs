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
        private readonly IServiceProvider _serviceProvider;

        public GDPRService(IServiceProvider serviceProvider)
        {
            
            _lastChecked = _currentTime;
            _serviceProvider = serviceProvider;
            
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
            // just to try and see how/if i can get this to work
          
            _currentTime = _currentTime.AddMinutes(1);

            if (_currentTime.Day != _lastChecked.Day) //change to Day for 24 hour check
            {
                CheckForDataToDelete().Wait();
                _lastChecked = _currentTime;
            }
           
        }

        private async Task CheckForDataToDelete()
        {
            // Logic to check and delete data older than a certain period
            // This is a placeholder for actual implementation
            Console.WriteLine("Checking for data to delete as per GDPR regulations...");
            using var scope = _serviceProvider.CreateScope();
            var bookingService = scope.ServiceProvider.GetRequiredService<IBookingService>();
            var genericItemService = scope.ServiceProvider.GetRequiredService<IGenericItemService>();

            var cutoffDateDelete = _currentTime.AddMonths(-6); // Example: delete data older than 6 months
            var cutoffDateAnonymize = _currentTime.AddMonths(-3); // Example: anonymize data older than 3 months

            var bookingsToDelete = await bookingService.GetOldBookingsForGDPR(cutoffDateDelete);

            var bookingsToAnonymize = await bookingService.GetOldBookingsForGDPR(cutoffDateAnonymize);



            if (bookingsToDelete.Any())
            {
                foreach (var booking in bookingsToDelete)
                {
                    await genericItemService.DeleteItem<Booking>(booking.BookingId);
                    Console.WriteLine($"Deleted booking with ID: {booking.BookingId}");
                }
            }

            if (bookingsToAnonymize.Any())
            {
                foreach (var booking in bookingsToAnonymize)
                {
                  
                   if( booking.CustomerId_FK != null) 
                        continue; //if customerID is not null skip to next becouse they are registered

                    if (booking.Name.Contains("Anonymized"))
                        continue; //booking already anonymized

                    booking.Name = "Anonymized";
                    booking.PhoneNumber = "Anonymized";
                    booking.Email = "Anonymized";

                    await genericItemService.UpdateItem<Booking, Booking>(booking.BookingId, booking);
                    Console.WriteLine($"Anonymized booking with ID: {booking.BookingId}");
                }
            }

        }
    }
}
