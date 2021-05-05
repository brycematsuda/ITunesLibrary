using System;

namespace ITunesLibrary
{
    public class Track : IEquatable<Track>
    {
        private string _album;
        private string _albumArtist;
        private string _artist;

        public string Album
        {
            get => _album;
            set
            {
                _album = value;
                GroupAlbum = value?.TrimStart();
            }
        }

        public string AlbumArtist
        {
            get => _albumArtist;
            set
            {
                _albumArtist = value;
                GroupAlbumArtist = value?.TrimStart();
            }
        }

        public int? AlbumRating { get; set; }
        public bool AlbumRatingComputed { get; set; }
        public string Artist
        {
            get => _artist;
            set
            {
                _artist = value;
                GroupArtist = value?.TrimStart();
            }
        }

        public int? ArtworkCount { get; set; }
        public int? BitRate { get; set; }
        public int? BPM { get; set; }
        public string Comments { get; set; }
        public string Composer { get; set; }
        public string ContentRating { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? DiscCount { get; set; }
        public int? DiscNumber { get; set; }
        public string Episode { get; set; }
        public int? EpisodeOrder { get; set; }
        public string Genre { get; set; }
        public string GroupAlbum { get; private set; }
        public string GroupAlbumArtist { get; private set; }
        public string GroupArtist { get; private set; }
        public string Grouping { get; set; }
        public bool HasVideo { get; set; }
        public bool IsAlbumDisliked { get; set; }
        public bool IsAlbumLoved { get; set; }
        public bool IsClean { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDisliked { get; set; }
        public bool IsExplicit { get; set; }
        public bool IsLoved { get; set; }
        public bool IsMovie { get; set; }
        public bool IsMusicVideo { get; set; }
        public bool IsPodcast { get; set; }
        public bool IsPurchased { get; set; }
        public bool IsTVShow { get; set; }
        public bool IsUnplayed { get; set; }
        public string Kind { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public bool PartOfCompilation { get; set; }
        public string PersistentId { get; set; }
        public int? PlayCount { get; set; }
        public DateTime? PlayDate { get; set; }
        public string PlayingTime { get; set; }
        public int? Rating { get; set; }
        public bool RatingComputed { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? SampleRate { get; set; }
        public int? Season { get; set; }
        public string Series { get; set; }
        public long? Size { get; set; }
        public int? SkipCount { get; set; }
        public DateTime? SkipDate { get; set; }
        public string SortAlbum { get; set; }
        public string SortAlbumArtist { get; set; }
        public string SortArtist { get; set; }
        public string SortComposer { get; set; }
        public string SortName { get; set; }
        public string SortSeries { get; set; }
        public int? TrackCount { get; set; }
        public int TrackId { get; set; }
        public int? TrackNumber { get; set; }
        public string TrackType { get; set; }
        public int? VolumeAdjustment { get; set; }
        public int? Year { get; set; }
        public Track Copy()
        {
            return MemberwiseClone() as Track;
        }

        public bool Equals(Track other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return AlbumRating == other.AlbumRating &&
                Album == other.Album &&
                AlbumArtist == other.AlbumArtist &&
                AlbumRatingComputed == other.AlbumRatingComputed &&
                Artist == other.Artist &&
                ArtworkCount == other.ArtworkCount &&
                BitRate == other.BitRate &&
                BPM == other.BPM &&
                Comments == other.Comments &&
                Composer == other.Composer &&
                ContentRating == other.ContentRating &&
                DateAdded == other.DateAdded &&
                DateModified == other.DateModified &&
                DiscCount == other.DiscCount &&
                DiscNumber == other.DiscNumber &&
                Episode == other.Episode &&
                EpisodeOrder == other.EpisodeOrder &&
                Genre == other.Genre &&
                Grouping == other.Grouping &&
                HasVideo == other.HasVideo &&
                IsAlbumDisliked == other.IsAlbumDisliked &&
                IsAlbumLoved == other.IsAlbumLoved &&
                IsClean == other.IsClean &&
                IsDisabled == other.IsDisabled &&
                IsDisliked == other.IsDisliked &&
                IsExplicit == other.IsExplicit &&
                IsLoved == other.IsLoved &&
                IsMovie == other.IsMovie &&
                IsMusicVideo == other.IsMusicVideo &&
                IsPodcast == other.IsPodcast &&
                IsPurchased == other.IsPurchased &&
                IsTVShow == other.IsTVShow &&
                IsUnplayed == other.IsUnplayed &&
                Kind == other.Kind &&
                Location == other.Location &&
                Name == other.Name &&
                PartOfCompilation == other.PartOfCompilation &&
                PersistentId == other.PersistentId &&
                PlayCount == other.PlayCount &&
                PlayDate == other.PlayDate &&
                PlayingTime == other.PlayingTime &&
                Rating == other.Rating &&
                RatingComputed == other.RatingComputed &&
                ReleaseDate == other.ReleaseDate &&
                SampleRate == other.SampleRate &&
                Season == other.Season &&
                Series == other.Series && 
                Size == other.Size &&
                SkipCount == other.SkipCount &&
                SkipDate == other.SkipDate &&
                SortAlbum == other.SortAlbum &&
                SortAlbumArtist == other.SortAlbumArtist &&
                SortArtist == other.SortArtist &&
                SortComposer == other.SortComposer &&
                SortName == other.SortName &&
                SortSeries == other.SortSeries &&
                TrackCount == other.TrackCount &&
                TrackId == other.TrackId &&
                TrackNumber == other.TrackNumber &&
                TrackType == other.TrackType &&
                VolumeAdjustment == other.VolumeAdjustment &&
                Year == other.Year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Track)obj);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();

            hash.Add(Album);
            hash.Add(AlbumArtist);
            hash.Add(AlbumRating);
            hash.Add(AlbumRatingComputed);
            hash.Add(Artist);
            hash.Add(ArtworkCount);
            hash.Add(BitRate);
            hash.Add(BPM);
            hash.Add(Comments);
            hash.Add(Composer);
            hash.Add(ContentRating);
            hash.Add(DateAdded);
            hash.Add(DateModified);
            hash.Add(DiscCount);
            hash.Add(DiscNumber);
            hash.Add(Episode);
            hash.Add(EpisodeOrder);
            hash.Add(Genre);
            hash.Add(Grouping);
            hash.Add(HasVideo);
            hash.Add(IsAlbumDisliked);
            hash.Add(IsAlbumLoved);
            hash.Add(IsClean);
            hash.Add(IsDisabled);
            hash.Add(IsDisliked);
            hash.Add(IsExplicit);
            hash.Add(IsLoved);
            hash.Add(IsMovie);
            hash.Add(IsMusicVideo);
            hash.Add(IsPodcast);
            hash.Add(IsPurchased);
            hash.Add(IsTVShow);
            hash.Add(IsUnplayed);
            hash.Add(Kind);
            hash.Add(Location);
            hash.Add(Name);
            hash.Add(PartOfCompilation);
            hash.Add(PersistentId);
            hash.Add(PlayCount);
            hash.Add(PlayDate);
            hash.Add(PlayingTime);
            hash.Add(Rating);
            hash.Add(RatingComputed);
            hash.Add(ReleaseDate);
            hash.Add(SampleRate);
            hash.Add(Season);
            hash.Add(Series);
            hash.Add(Size);
            hash.Add(SkipCount);
            hash.Add(SkipDate);
            hash.Add(SortAlbum);
            hash.Add(SortAlbumArtist);
            hash.Add(SortArtist);
            hash.Add(SortComposer);
            hash.Add(SortName);
            hash.Add(SortSeries);
            hash.Add(TrackCount);
            hash.Add(TrackId);
            hash.Add(TrackNumber);
            hash.Add(TrackType);
            hash.Add(VolumeAdjustment);
            hash.Add(Year);

            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return $"Artist: {Artist} - Track: {Name} - Album: {Album}";
        }
    }
}