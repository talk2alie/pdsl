namespace Pdsl.Api.Data
{
    public interface IPressReleaseRepository
    {
        public PressRelease? GetPressReleaseByLocatorId(string locatorId);
        public IQueryable<PressRelease>? Get(Func<PressRelease, bool>? filter);
        public void Add(PressRelease pressRelease);
        public void Update(PressRelease pressRelease);
    }
}
