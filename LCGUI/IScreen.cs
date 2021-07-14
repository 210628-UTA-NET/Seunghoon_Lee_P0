namespace LCGUI
{
    public enum ScreenType
    {
        MainScreen,
        SelectStoreScreen,
        CustomerScreen,
        AddCustomerScreen,
        CustomerListScreen,
        SearchCustomerByPhoneNumberScreen,
        StoreInventoryListScreen,
        OrderHistoryScreen,
        PlaceOrderScreen,
        Exit
    }

    public interface IScreen
    {
        /// <summary>
        /// Display screen options to be selected by user
        /// </summary>
        void Render();

        /// <summary>
        /// Get user input and return screen type to be routed to
        /// </summary>
        /// <returns></returns>
        ScreenType GetRoute();
    }
}