namespace Pdsl.Api.PressReleases
{
    public interface IPressReleaseRepository
    {
        void Add(PressRelease release);

        PressRelease Get(string id);

        IEnumerable<PressRelease> GetByUploaderId(string uploaderId);

        void Update(PressRelease release);

        void DeactivateById(string id, string deactivatorId);

        IEnumerable<PressRelease> GetLatest();

        IEnumerable<PressRelease> GetArchived();
    }
}
