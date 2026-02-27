namespace BankingSystem.Presentation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // BURASI KRİTİK: Form1 yazan yere senin oluşturduğun formun adını yazmalısın
            Application.Run(new ApplicationEntryForm());
        }
    }
}