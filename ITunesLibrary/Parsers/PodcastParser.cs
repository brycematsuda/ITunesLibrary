using System.Collections.Generic;
using System.Linq;

namespace ITunesLibrary.Parsers
{
    internal class PodcastParser
    {
        internal IEnumerable<Podcast> ParsePodcasts(IEnumerable<Track> tracks)
        {
            var albumGroups = tracks.Where(t => t.IsPodcast).GroupBy(t => t.Album);
            var feeds = new List<Podcast>();

            foreach (var albumGroup in albumGroups.OrderBy(a => a.Key))
            {
                var feed = albumGroup.Where(a => string.IsNullOrEmpty(a.Kind)).FirstOrDefault();
                var episodes = albumGroup.Where(a => !string.IsNullOrEmpty(a.Kind));
                feeds.Add(CreatePodcast(feed, episodes));
            }

            return feeds;
        }

        private static Podcast CreatePodcast(Track feed, IEnumerable<Track> episodes)
        {
            return new Podcast
            {
                Episodes = episodes.ToList(),
                Feed = feed
            };
        }
    }
}
