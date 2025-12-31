using ReservationConsoleApp.Models;

public class ReservationService
{
    private readonly List<Resource> _resources = new();
    private readonly List<Client> _clients = new();
    private readonly List<Reservation> _reservations = new();
    private int _nextResourceId = 1;
    private int _nextReservationId = 1;

    /// <summary>
    /// Classe ReservationService - Pour modeliser les réservations de ressources
    /// </summary>
    public ReservationService()
    {
        var managerSalle = new ResourceManager("Monmsen MERESU", "momnsen.mereus@student.ueh.edu.ht");
        var managerEq = new ResourceManager("Whitchy AUGUSTIN", "witchy.augustin@student.ueh.edu.ht");
        var managerCh = new ResourceManager("Wanguy CALVERT", "wanguy.calvert@student.ueh.edu.ht");

        _resources.Add(new Resource(_nextResourceId++, ResourceType.Salle, "Salle de réunion A", managerSalle));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Salle, "Salle de réunion B", managerSalle));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Salle, "Salle de réunion C", managerSalle));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Salle, "Salle de réunion D", managerSalle));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Chambre, "Chambre 101", managerCh));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Chambre, "Chambre 102", managerCh));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Chambre, "Chambre 103", managerCh));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Chambre, "Chambre 104", managerCh));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Equipement, "Projecteur 1", managerEq));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Equipement, "Projecteur 2", managerEq));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Equipement, "Kit Réseau 1", managerEq));
        _resources.Add(new Resource(_nextResourceId++, ResourceType.Equipement, "Kit Réseau 2", managerEq));

        var client = new Client("Jean Dupont", "jean.dupont@entreprise.com");
        _clients.Add(client);

        var reservation = new Reservation(_nextReservationId++, _resources[0], client, DateTime.Today);
        _reservations.Add(reservation);
    }
    public List<Resource> GetResources() => _resources;
    public List<Reservation> GetReservations() => _reservations;

    public Resource GetResourceById(int id)
    {
        return _resources.FirstOrDefault(r => r.Id == id);
    }

    public Reservation GetReservationById(int id)
    {
        return _reservations.FirstOrDefault(r => r.Id == id);
    }

    public Client GetOrCreateClient(string fullName, string email)
    {
        var existing = _clients.FirstOrDefault(c =>
            c.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase)
            && c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        if (existing != null)
            return existing;

        var client = new Client(fullName, email);
        _clients.Add(client);
        return client;
    }


    public Reservation CreateReservation(int resourceId, string clientName, string clientEmail, DateTime date)
    {
        var resource = GetResourceById(resourceId);
        if (resource == null)
        {
            Console.WriteLine("Ressource introuvable.");
            return null;
        }

        var conflict = _reservations.Any(r =>
            r.Resource.Id == resourceId &&
            r.DateReservation.Date == date.Date &&
            r.Status == ReservationStatus.Confirmee);

        if (conflict)
        {
            Console.WriteLine("Conflit : la ressource est déjà réservée à cette date.");
            return null;
        }

        var client = GetOrCreateClient(clientName, clientEmail);
        var reservation = new Reservation(_nextReservationId++, resource, client, date);
        _reservations.Add(reservation);
        return reservation;
    }

    public bool CancelReservation(int id)
    {
        var reservation = GetReservationById(id);
        if (reservation == null)
            return false;

        if (reservation.Status == ReservationStatus.Annulee)
            return false;

        reservation.Status = ReservationStatus.Annulee;
        return true;
    }
}