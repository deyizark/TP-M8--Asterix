namespace ReservationConsoleApp.Models
{
    /// <summary>
    /// Classe ResourceManager - Personne qui gère une ressource en particulier
    /// </summary>
    public class ResourceManager : Person
    {
        public ResourceManager(string fullName, string email)
            : base(fullName, email)
        {
        }
    }
}
