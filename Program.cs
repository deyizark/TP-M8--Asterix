using System.Globalization;

namespace ReservationConsoleApp
{
    public class Program
    {
        private static ReservationService _service = new ReservationService();
        static void Main(string[] args)
        {
                        bool quitter = false;
            while (!quitter)
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("   SYSTÈME DE GESTION DE RÉSERVATIONS   ");
                Console.WriteLine("=========================================");
                Console.WriteLine("1. Consulter les ressources");
                Console.WriteLine("2. Gérer les réservations");
                Console.WriteLine("3. Afficher un récapitulatif de réservation");
                Console.WriteLine("0. Quitter");
                Console.WriteLine("=========================================");
                Console.Write("Votre choix : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        MenuRessources();
                        break;
                    case "2":
                        MenuReservations();
                        break;
                    case "3":
                        AfficherRecapReservation();
                        break;
                    case "0":
                        quitter = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Appuyez sur une touche pour continuer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void MenuRessources()
        {
            Console.Clear();
            Console.WriteLine("=== LISTE DES RESSOURCES ===");
            foreach (var r in _service.GetResources())
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour revenir au menu principal.");
            Console.ReadKey();
        }

        private static void MenuReservations()
        {
            bool retour = false;
            while (!retour)
            {
                Console.Clear();
                Console.WriteLine("=== GESTION DES RÉSERVATIONS ===");
                Console.WriteLine("1. Lister toutes les réservations");
                Console.WriteLine("2. Créer une réservation");
                Console.WriteLine("3. Annuler une réservation");
                Console.WriteLine("0. Retour");
                Console.Write("Votre choix : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        ListerReservations();
                        break;
                    case "2":
                        CreerReservation();
                        break;
                    case "3":
                        AnnulerReservation();
                        break;
                    case "0":
                        retour = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Appuyez sur une touche pour continuer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ListerReservations()
        {
            Console.Clear();
            Console.WriteLine("=== LISTE DES RÉSERVATIONS ===");
            foreach (var r in _service.GetReservations())
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour continuer.");
            Console.ReadKey();
        }

         private static void CreerReservation()
        {
            Console.Clear();
            Console.WriteLine("=== CRÉATION D'UNE RÉSERVATION ===");

            Console.WriteLine("Ressources disponibles :");
            foreach (var r in _service.GetResources())
            {
                Console.WriteLine(r);
            }

            Console.Write("Id de la ressource : ");
            if (!int.TryParse(Console.ReadLine(), out int resourceId))
            {
                Console.WriteLine("Id invalide.");
                Console.ReadKey();
                return;
            }

            Console.Write("Nom du client : ");
            string? nomClient = Console.ReadLine();
            Console.Write("Email du client : ");
            string emailClient = Console.ReadLine();

            Console.Write("Date de réservation (jj/mm/aaaa) : ");
            string dateStr = Console.ReadLine();
            if (!DateTime.TryParseExact(dateStr, "dd/MM/yyyy", CultureInfo.GetCultureInfo("fr-FR"), DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("Date invalide.");
                Console.ReadKey();
                return;
            }

            var reservation = _service.CreateReservation(resourceId, nomClient ?? "", emailClient ?? "", date);
            if (reservation != null)
            {
                Console.WriteLine();
                Console.WriteLine("Réservation créée avec succès !");
                Console.WriteLine(reservation.GetSummary());
            }
            Console.WriteLine("Appuyez sur une touche pour continuer.");
            Console.ReadKey();
        }
        
        private static void AnnulerReservation()
        {
            Console.Clear();
            Console.WriteLine("=== ANNULATION D'UNE RÉSERVATION ===");
            ListerReservations();
            Console.Write("Id de la réservation à annuler : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id invalide.");
                Console.ReadKey();
                return;
            }

            bool ok = _service.CancelReservation(id);
            if (ok)
            {
                Console.WriteLine("Réservation annulée.");
            }
            else
            {
                Console.WriteLine("Impossible d'annuler (réservation introuvable ou déjà annulée).");
            }
            Console.WriteLine("Appuyez sur une touche pour continuer.");
            Console.ReadKey();
        }

        private static void AfficherRecapReservation()
        {
            Console.Clear();
            Console.WriteLine("=== RÉCAPITULATIF D'UNE RÉSERVATION ===");
            ListerReservations();
            Console.Write("Id de la réservation à afficher : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id invalide.");
                Console.ReadKey();
                return;
            }

            var reservation = _service.GetReservationById(id);
            if (reservation == null)
            {
                Console.WriteLine("Réservation introuvable.");
            }
            else
            {
                Console.WriteLine(reservation.GetSummary());
            }
            Console.WriteLine("Appuyez sur une touche pour continuer.");
            Console.ReadKey();
        }
    }
}