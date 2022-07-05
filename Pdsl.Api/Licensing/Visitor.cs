using static System.Guid;
namespace Pdsl.Api.Licensing
{
    public class Visitor
    {
        public Guid Id { get; set; }

        public Name Name { get; set; }

        public Organization Organization { get; set; }

        public Email Email { get; set; }

        public Secret Secret { get; set; }

        public bool IsVerified { get; set; }

        public DateTime CreationUtcDateTime { get; set; }

        public DateTime LastUpdatedUtcDateTime { get; private set; }

        private readonly List<Visit> _visits;
        public ICollection<Visit> Visits => _visits;

        public Visitor(Guid id, Name name, Organization organization, Email email, Secret secret)
        {
            if (id == Empty)
            {
                id = NewGuid();
            }
            Id = id;
            Name = name;
            Organization = organization;
            Email = email;
            Secret = secret;
            LastUpdatedUtcDateTime = DateTime.UtcNow;
            _visits = new List<Visit>();
        }

        public void Add(Visit visit) => _visits.Add(visit);
    }
}
