public abstract class Ressource : IPayable
{
    public string Nom { get; set; }
    public bool EstDisponible { get; set; } = true;

    public abstract double CalculerPrix();
}
