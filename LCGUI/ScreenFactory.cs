using System.IO;
using LCGBL;
using LCGDL;
using LCGDL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LCGUI
{
    public class ScreenFactory : IScreenFactory
    {
        public IScreen GetScreen(ScreenType p_screenType)
        {
            //Get the configuration from our AppSetting.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSetting.json")
                .Build();
            //Grabs our connectionString from our AppSetting.json file
            string connectionString = configuration.GetConnectionString("LCGDB");

            DbContextOptions<LCGDBContext> options = new DbContextOptionsBuilder<LCGDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            switch(p_screenType)
            {
                case ScreenType.MainScreen :
                    return new MainScreen();
                case ScreenType.SelectStoreScreen :
                    return new SelectStoreScreen(new StoreBL(new Repository(new LCGDBContext(options))));
                case ScreenType.CustomerScreen :
                    return new CustomerScreen();
                case ScreenType.AddCustomerScreen :
                    return new AddCustomerScreen(new StoreBL(new Repository(new LCGDBContext(options))));
                case ScreenType.CustomerListScreen :
                    return new CustomerListScreen(new StoreBL(new Repository(new LCGDBContext(options))));
                case ScreenType.SearchCustomerByPhoneNumberScreen :
                    return new SearchCustomerByPhoneNumberScreen(new StoreBL(new Repository(new LCGDBContext(options))));
                case ScreenType.StoreInventoryListScreen :
                    return new StoreInventoryListScreen(new StoreBL(new Repository(new LCGDBContext(options))));
                case ScreenType.OrderHistoryScreen :
                    return new OrderHistoryScreen(new StoreBL(new Repository(new LCGDBContext(options))));
                case ScreenType.PlaceOrderScreen :
                    return new PlaceOrderScreen(new StoreBL(new Repository(new LCGDBContext(options))));
                default :
                    return null;
            }
        }
    }
}