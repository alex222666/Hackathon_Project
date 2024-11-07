using APP_CIH_CAHUL_BAC_SIGN_IN__SIGN_UP;

namespace APP_CIH_CAHUL_BAC
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new StartUp());
        }
    }
}