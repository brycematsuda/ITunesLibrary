using System;
using System.Collections.Generic;
using System.Linq;

namespace ITunesLibrary.Parsers
{
    internal class AlbumParser
    {
        private static readonly string CompilationArtistName = "Various Artists";
        private static readonly string UnknownAlbumName = "Unknown Album";
        private static readonly string UnknownArtistName = "Unknown Artist";

        internal IEnumerable<Album> ParseAlbums(IEnumerable<Track> tracks)
        {
            var albums = new List<Album>();

            if (tracks == null || !tracks.Any())
            {
                return albums;
            }

            var albumGroups = tracks.GroupBy(t => t.GroupAlbum,
                StringComparer.InvariantCultureIgnoreCase);
            
            foreach (var albumGroup in albumGroups)
            {
                SubGroupByAlbumArtistToCreateAlbums(albumGroup, albums);
            }

            return albums;
        }

        private static Album CreateAlbum(IEnumerable<Track> tracks)
        {
            // Sort the tracks in the same order that iTunes sorts them (by disc, track, and name)
            // This has an influence in what iTunes uses for some of the album-related information such as
            // the album's genre and album art when the tracks do not all match.
            var orderedTracks = tracks.OrderBy(t => t.DiscNumber ?? 1)
                .ThenBy(t => t.TrackNumber ?? int.MaxValue)
                .ThenBy(t => t.Name);

            return new Album
            {
                Artist = GetArtistName(orderedTracks),
                Genre = orderedTracks.First().Genre,
                IsCompilation = tracks.Any(t => t.PartOfCompilation),
                Name = GetAlbumName(orderedTracks),
                Tracks = orderedTracks.ToList(),
                Year = tracks.Max(t => t.Year)
            };
        }

        private static string GetAlbumName(IEnumerable<Track> tracks)
        {
            if (tracks.Any(t => !string.IsNullOrWhiteSpace(t.Album)))
            {
                return tracks.Select(t => t.Album).First(aa => !string.IsNullOrWhiteSpace(aa));
            }

            return UnknownAlbumName;
        }

        private static string GetArtistName(IEnumerable<Track> tracks)
        {
            if (tracks.Any(t => !string.IsNullOrWhiteSpace(t.AlbumArtist)))
            {
                return tracks.Select(t => t.AlbumArtist).First(aa => !string.IsNullOrWhiteSpace(aa));
            }

            if (tracks.All(t => string.IsNullOrWhiteSpace(t.Artist)))
            {
                return UnknownArtistName;
            }

            return tracks.Any(t => t.PartOfCompilation) ? CompilationArtistName : tracks.Select(t => t.Artist).First();
        }

        private static string GetGroupByArtistName(Track track)
        {
            // Track with the same Album Artist value are always grouped together.
            if (!string.IsNullOrWhiteSpace(track.GroupAlbumArtist))
            {
                return track.GroupAlbumArtist;
            }

            // Tracks with the compilation flag set and no Album Artist value
            // are grouped together as a "Various Artists" compilation in iTunes.
            if (track.PartOfCompilation)
            {
                return CompilationArtistName;
            }

            // Tracks without the compilation flag, and no Album Artist or Artist, are grouped together as
            // "Unknown Artist", but are not combined with any tracks that have "Unknown Artist" entered
            // into the Artist or Album Artist field because that's how iTunes does it.
            if (string.IsNullOrWhiteSpace(track.GroupArtist))
            {
                return null;
            }

            // Tracks without the compilation flag that have an Artist, but no Album Artist value,
            // assume that the Album Artist is the same as the Artist.
            return track.GroupArtist;
        }

        private static void SubGroupByAlbumArtistToCreateAlbums(IEnumerable<Track> albumGroup, List<Album> albums)
        {
            var groupByAlbumArtist = albumGroup.GroupBy(t => GetGroupByArtistName(t),
                StringComparer.InvariantCultureIgnoreCase);
            albums.AddRange(groupByAlbumArtist.Select(CreateAlbum));
        }
    }
}