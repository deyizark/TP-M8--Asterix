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
        public IReadOnlyList<Resource> GetResources() => _resources;
        public IReadOnlyList<Reservation> GetReservations() => _reservations;

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
        

        public Reservation? CreateReservation(int resourceId, string clientName, string clientEmail, DateTime date)
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