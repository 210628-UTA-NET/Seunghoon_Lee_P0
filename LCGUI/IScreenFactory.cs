namespace LCGUI
{
    public interface IScreenFactory
    {
        /// <summary>
        /// Create new Screen
        /// </summary>
        /// <param name="p_screenType"></param>
        /// <returns>Screen</returns>
        IScreen GetScreen(ScreenType p_screenType);
    }
}