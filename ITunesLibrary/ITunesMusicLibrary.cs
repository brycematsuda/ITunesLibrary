using ITunesLibrary.Parsers;
using ITunesLibrary.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace ITunesLibrary
{
    public class ITunesMusicLibrary
    {
        private readonly AlbumParser albumParser;
        private readonly IFileSystem fileSystem;
        private readonly PodcastParser podcastParser;
        private readonly TrackParser trackParser;
        private readonly string xmlLibraryFileLocation;

        private IEnumerable<Album> albums;
        private IEnumerable<Playlist> playlists;
        private IEnumerable<Podcast> podcasts;
        private IEnumerable<Track> tracks;

        public ITunesMusicLibrary(string xmlLibraryFileLocation) : this(xmlLibraryFileLocation, new FileSystemWrapper()) 
        {
        }

        public ITunesMusicLibrary(string xmlLibraryFileLocation, IFileSystem fileSystem)
        {
            this.xmlLibraryFileLocation = xmlLibraryFileLocation;
            this.fileSystem = fileSystem;
            this.trackParser = new TrackParser();
            this.albumParser = new AlbumParser();
            this.podcastParser = new PodcastParser();
        }

        public IEnumerable<Album> Albums => albums ??= albumParser.ParseAlbums(Music);
        public IEnumerable<Track> Music => Playlists.Where(p => p.Name == "Music").FirstOrDefault()?.Tracks ?? Tracks;
        public IEnumerable<Playlist> Playlists => playlists ??= new PlaylistParser(Tracks).ParsePlaylists(ReadTextFromLibraryFile());
        public IEnumerable<Podcast> Podcasts => podcasts ??= podcastParser.ParsePodcasts(Tracks);
        public IEnumerable<Track> Tracks => tracks ??= trackParser.ParseTracks(ReadTextFromLibraryFile());

        private string ReadTextFromLibraryFile()
        {
            return fileSystem.ReadTextFromFile(xmlLibraryFileLocation);
        }
    }
}
