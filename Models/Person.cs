namespace ReservationConsoleApp.Models
{
    public class Person
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public Person(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public override string ToString()
        {
            return $"{FullName} ({Email})";
        }
    }
}
