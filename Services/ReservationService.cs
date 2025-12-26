using ReservationConsoleApp.Models;

public class ReservationService
{
    private readonly List<Resource> _resources = new();
    private readonly List<Client> _clients = new();
    private readonly List<Reservation> _reservations = new();
    private int _nextResourceId = 1;
    private int _nextReservationId = 1;
}