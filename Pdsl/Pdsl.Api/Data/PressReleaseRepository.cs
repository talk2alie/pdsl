namespace Pdsl.Api.Data
{
    public class PressReleaseRepository : IPressReleaseRepository
    {
        private readonly PdslDbContext dbContext;

        public PressReleaseRepository(PdslDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(PressRelease pressRelease) => dbContext.PressReleases?.Add(pressRelease);

        public IQueryable<PressRelease>? Get(Func<PressRelease, bool>? filter)
        {
            if (filter is null)
            {
                return dbContext.PressReleases;
            }

            return dbContext.PressReleases?.Where(pressRelease => filter(pressRelease));
        }

        public PressRelease? GetPressReleaseByLocatorId(string locatorId) =>
            Get(pressRelease => pressRelease.LocatorId == locatorId)?.FirstOrDefault();

        public void Update(PressRelease pressRelease) => dbContext.PressReleases?.Update(pressRelease);
    }
}
