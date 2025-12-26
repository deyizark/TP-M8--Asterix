using ReservationConsoleApp.Models;

public class ReservationService
{
    private readonly List<Resource> _resources = new();
    private readonly List<Client> _clients = new();
    private readonly List<Reservation> _reservations = new();
    private int _nextResourceId = 1;
    private int _nextReservationId = 1;

     private void SeedData()
        {
            var managerSalle = new ResourceManager("Marie Laurent", "marie.laurent@entreprise.com");
            var managerEq = new ResourceManager("Paul Martin", "paul.martin@entreprise.com");

            _resources.Add(new Resource(_nextResourceId++, ResourceType.Salle, "Salle de réunion A", managerSalle));
            _resources.Add(new Resource(_nextResourceId++, ResourceType.Salle, "Salle de réunion B", managerSalle));
            _resources.Add(new Resource(_nextResourceId++, ResourceType.Chambre, "Chambre 101", managerSalle));
            _resources.Add(new Resource(_nextResourceId++, ResourceType.Equipement, "Projecteur 1", managerEq));

            var client = new Client("Jean Dupont", "jean.dupont@entreprise.com");
            _clients.Add(client);

            var reservation = new Reservation(_nextReservationId++, _resources[0], client, DateTime.Today);
            _reservations.Add(reservation);
        }
}