namespace ReservationConsoleApp.Models
{
    /// <summary>
    /// Classe Resource - Pour modeliser les ressources de l'entreprise
    /// </summary>
    public class Resource
    {
        public int Id { get; set; }
        public ResourceType Type { get; set; }
        public string Name { get; set; }
        public ResourceManager Manager { get; set; }

        public Resource(int id, ResourceType type, string name, ResourceManager manager)
        {
            Id = id;
            Type = type;
            Name = name;
            Manager = manager;
        }

        public override string ToString()
        {
            return $"ID: {Id} - TYPE: {Type} - NOM: {Name} (RESPONSABLE: {Manager.FullName} -- {Manager.Email})";
        }
    }
}