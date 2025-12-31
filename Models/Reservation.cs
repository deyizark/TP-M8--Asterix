using System;
using System.Text;

namespace ReservationConsoleApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Resource Resource { get; set; }
        public Client Client { get; set; }
        public DateTime DateReservation { get; set; }
        public ReservationStatus Status { get; set; }

        public Reservation(int id, Resource resource, Client client, DateTime dateReservation)
        {
            Id = id;
            Resource = resource;
            Client = client;
            DateReservation = dateReservation;
            Status = ReservationStatus.Confirmee;
        }

        /// <summary>
        /// Affichage personnalisé pour un récapitulatif des réservations
        /// </summary>
        public string GetSummary()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=========================================");
            sb.AppendLine("         RÉCAPITULATIF DE RÉSERVATION    ");
            sb.AppendLine("=========================================");
            sb.AppendLine();
            sb.AppendLine("Ressource");
            sb.AppendLine("---------");
            sb.AppendLine($"Type        : {Resource.Type}");
            sb.AppendLine($"Nom         : {Resource.Name}");
            sb.AppendLine($"Responsable : {Resource.Manager.FullName}");
            sb.AppendLine($"Contact     : {Resource.Manager.Email}");
            sb.AppendLine();
            sb.AppendLine("Client");
            sb.AppendLine("------");
            sb.AppendLine($"Nom   : {Client.FullName}");
            sb.AppendLine($"Email : {Client.Email}");
            sb.AppendLine();
            sb.AppendLine("Réservation");
            sb.AppendLine("-----------");
            sb.AppendLine($"Date   : {DateReservation:dd MMMM yyyy}");
            sb.AppendLine($"Statut : {Status}");
            sb.AppendLine("=========================================");
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"[{Id}] {Resource.Name} pour {Client.FullName} le {DateReservation:dd/MM/yyyy} ({Status})";
        }
    }
}
