namespace TelekomunikacjaZad2
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
            Form1 form = new Form1();
            form.Text = "Telekomunikacja Zadanie 3 Pawe³ Stus, Andrzej Szlaski";
            Application.Run(form);
        }
    }
}