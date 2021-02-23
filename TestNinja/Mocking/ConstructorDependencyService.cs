using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestNinja.Mocking
{
    public class ConstructorDependencyService
    {
        private IFileReader _fileReader;
        public ConstructorDependencyService()
        {
            _fileReader = new FileReader();
        }
        public ConstructorDependencyService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string ReadVideoTitle(IFileReader fileReader)
        {
            var str = fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Videoo>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string ReadVideoTitleViaProp()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Videoo>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;

        }
        public string ReadVideoTitleViaConstructor()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Videoo>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

            public string GetUnprocessedVideosAsCsv()
            {
                var videoIds = new List<int>();

                using (var context = new VideooContext())
                {
                    var videos =
                        (from video in context.Videos
                         where !video.IsProcessed
                         select video).ToList();

                    foreach (var v in videos)
                        videoIds.Add(v.Id);

                    return String.Join(",", videoIds);
                }
            }
        }

        public class Videoo
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public bool IsProcessed { get; set; }
        }

        public class VideooContext : DbContext
        {
            public DbSet<Videoo> Videos { get; set; }
        }
    }



