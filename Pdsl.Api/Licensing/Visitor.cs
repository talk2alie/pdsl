using System.Collections.ObjectModel;
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

        private readonly List<Visit> visits;
        public ReadOnlyCollection<Visit> Visits => new(visits);

        public Visitor(Guid id, Name name, Organization organization, Email email, Secret secret)
        {
            if(id == Empty)
            {
                id = NewGuid();
            }
            Id = id;
            Name = name;
            Organization = organization;
            Email = email;
            Secret = secret;
            LastUpdatedUtcDateTime = DateTime.UtcNow;
            visits = new List<Visit>();
        }

        public void Add(Visit visit) => visits.Add(visit);
    }
}
