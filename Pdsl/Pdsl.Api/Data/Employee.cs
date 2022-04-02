namespace Pdsl.Api.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public string? LocatorId { get; set; }
        public virtual ICollection<PressRelease> PressReleases { get; set; }

        public Employee()
        {
            PressReleases = new HashSet<PressRelease>();
        }
    }
}
