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


    }
}