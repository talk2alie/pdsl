using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdsl.Api.Models
{
    public class Release
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TitleImagePath { get; set; }
        public string FilePath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string UploaderId { get; set; }

        public Release(string id, string title, string description, string titleImagePath, string filePath, DateTime releaseDate, string updaterId)
        {
            Id = id;
            Title = title;
            Description = description;
            TitleImagePath = titleImagePath;
            FilePath = filePath;
            ReleaseDate = releaseDate;
            UploaderId = updaterId;
        }
    }
}
