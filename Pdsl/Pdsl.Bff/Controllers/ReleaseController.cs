using Microsoft.AspNetCore.Mvc;
using Pdsl.Bff.Models;
using Pdsl.Bff.Services;
using System.IO;

namespace Pdsl.Bff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleaseController : ControllerBase
    {
        private readonly ILogger<ReleaseController> logger;
        private readonly PdslService pdslService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ReleaseController(ILogger<ReleaseController> logger, PdslService pdslService, IWebHostEnvironment hostEnvironment)
        {
            this.logger = logger;
            this.pdslService = pdslService;
            this.webHostEnvironment = hostEnvironment;
        }

        [HttpGet("archived")]
        public async Task<IActionResult> GetArchivedReleases() => Ok(await pdslService.GetArchivedReleases());

        [HttpGet("most-recent")]
        public async Task<IActionResult> GetMostRecentReleases() => Ok(await pdslService.GetMostReleases());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReleaseById([FromRoute] string id)
        {
            var release = await pdslService.GetReleaseById(id);
            if(release is null)
            {
                return NotFound();
            }

            return Ok(release);
        }

        [HttpPost]
        public async Task<IActionResult> AddRelease([FromForm] ReleaseInputViewModel releaseToAdd)
        {
            var bannerImage = releaseToAdd.BannerImage;
            if(bannerImage is null || bannerImage.Length > 500000)
            {
                return BadRequest("Banner image is required and it must be at most 500Kb");
            }
            var bannerImagePath = await Task.Run(() => CreateBannerImageFile(bannerImage));


            var releaseDocument = releaseToAdd.Document;
            if (releaseDocument is null || releaseDocument.Length > 5000000)
            {
                return BadRequest("A Release document is required and it must be at most 5MB");
            }
            var releaseFilePath = await Task.Run(() => CreateReleaseFile(releaseDocument));

            var response = await pdslService.AddRelease(new ReleaseToAdd
            {
                BannerImagePath = bannerImagePath,
                Description = releaseToAdd.Description,
                FilePath = releaseFilePath,
                ReleaseDate = DateTime.UtcNow,
                Title = releaseToAdd.Title,
                UploaderId = releaseToAdd.UploaderId
            });

            return Ok(response);
        }

        private string CreateReleaseFile(IFormFile releaseDocument)
        {
            var bannerImageFileName = releaseDocument.FileName;
            var hostPath = webHostEnvironment.WebRootPath;
            var releaseFilePath = Path.Combine(hostPath, "releases", $"{DateTime.UtcNow.ToFileTime()}_{bannerImageFileName}");

            using var stream = System.IO.File.Create(releaseFilePath);
            releaseDocument.CopyTo(stream);

            return releaseFilePath;
        }

        private string CreateBannerImageFile(IFormFile bannerImage)
        {
            var bannerImageFileName = bannerImage.FileName;
            var hostPath = webHostEnvironment.WebRootPath;
            var bannerImagePath = Path.Combine(hostPath,"images", $"{DateTime.UtcNow.ToFileTime()}_{bannerImageFileName}");

            using var stream = System.IO.File.Create(bannerImagePath);
            bannerImage.CopyTo(stream);

            return bannerImagePath;
        }
    }
}