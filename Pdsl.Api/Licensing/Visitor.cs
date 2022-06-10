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

        public Visitor(Name name, Organization organization, Email email, Secret secret)
        {
            Name = name;
            Organization = organization;
            Email = email;
            Secret = secret;
        }
    }
}
