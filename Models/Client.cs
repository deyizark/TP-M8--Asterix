namespace ReservationConsoleApp.Models
{

    /// <summary>
    /// Classe Client - spécialisation de Person
    /// </summary>
    public class Client : Person
    {
        public Client(string fullName, string email)
            : base(fullName, email)
        {
        }
    }
}