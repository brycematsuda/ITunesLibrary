using ITunesLibrary.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ITunesLibrary.Parsers
{
    internal class TrackParser : LibraryItemParserBase
    {
        internal IEnumerable<Track> ParseTracks(string libraryContents)
        {
            return ParseElements(libraryContents).Select(CreateTrack);
        }

        protected override string GetCollectionNodeName()
        {
            return "dict";
        }

        private static Track CreateTrack(XElement trackElement)
        {
            return new Track
            {
                Album = XElementParser.ParseStringValue(trackElement, "Album"),
                AlbumArtist = XElementParser.ParseStringValue(trackElement, "Album Artist"),
                AlbumRating = XElementParser.ParseNullableIntValue(trackElement, "Album Rating"),
                AlbumRatingComputed = XElementParser.ParseBoolean(trackElement, "Album Rating Computed"),
                Artist = XElementParser.ParseStringValue(trackElement, "Artist"),
                ArtworkCount = XElementParser.ParseNullableIntValue(trackElement, "Artwork Count"),
                BitRate = XElementParser.ParseNullableIntValue(trackElement, "Bit Rate"),
                BPM = XElementParser.ParseNullableIntValue(trackElement, "BPM"),
                Comments = XElementParser.ParseStringValue(trackElement, "Comments"),
                Composer = XElementParser.ParseStringValue(trackElement, "Composer"),
                ContentRating = XElementParser.ParseStringValue(trackElement, "Content Rating"),
                DateAdded = XElementParser.ParseNullableDateValue(trackElement, "Date Added"),
                DateModified = XElementParser.ParseNullableDateValue(trackElement, "Date Modified"),
                DiscCount = XElementParser.ParseNullableIntValue(trackElement, "Disc Count"),
                DiscNumber = XElementParser.ParseNullableIntValue(trackElement, "Disc Number"),
                Episode = XElementParser.ParseStringValue(trackElement, "Episode"),
                EpisodeOrder = XElementParser.ParseNullableIntValue(trackElement, "Episode Order"),
                Genre = XElementParser.ParseStringValue(trackElement, "Genre"),
                Grouping = XElementParser.ParseStringValue(trackElement, "Grouping"),
                HasVideo = XElementParser.ParseBoolean(trackElement, "Has Video"),
                IsAlbumDisliked = XElementParser.ParseBoolean(trackElement, "AlbumDisliked"),
                IsAlbumLoved = XElementParser.ParseBoolean(trackElement, "Album Loved"),
                IsClean = XElementParser.ParseBoolean(trackElement, "Clean"),
                IsDisabled = XElementParser.ParseBoolean(trackElement, "Disabled"),
                IsDisliked = XElementParser.ParseBoolean(trackElement, "Disliked"),
                IsExplicit = XElementParser.ParseBoolean(trackElement, "Explicit"),
                IsLoved = XElementParser.ParseBoolean(trackElement, "Loved"),
                IsMovie = XElementParser.ParseBoolean(trackElement, "Movie"),
                IsMusicVideo = XElementParser.ParseBoolean(trackElement, "Music Video"),
                IsPodcast = XElementParser.ParseBoolean(trackElement, "Podcast"),
                IsPurchased = XElementParser.ParseBoolean(trackElement, "Purchased"),
                IsTVShow = XElementParser.ParseBoolean(trackElement, "TV Show"),
                IsUnplayed = XElementParser.ParseBoolean(trackElement, "Unplayed"),
                Kind = XElementParser.ParseStringValue(trackElement, "Kind"),
                Location = XElementParser.ParseStringValue(trackElement, "Location"),
                Name = XElementParser.ParseStringValue(trackElement, "Name"),
                PartOfCompilation = XElementParser.ParseBoolean(trackElement, "Compilation"),
                PersistentId = XElementParser.ParseStringValue(trackElement, "Persistent ID"),
                PlayCount = XElementParser.ParseNullableIntValue(trackElement, "Play Count"),
                PlayDate = XElementParser.ParseNullableDateValue(trackElement, "Play Date UTC"),
                PlayingTime = TimeConvert.MillisecondsToFormattedMinutesAndSeconds(XElementParser.ParseNullableLongValue(trackElement, "Total Time")),
                Rating = XElementParser.ParseNullableIntValue(trackElement, "Rating"),
                RatingComputed = XElementParser.ParseBoolean(trackElement, "Rating Computed"),
                ReleaseDate = XElementParser.ParseNullableDateValue(trackElement, "Release Date"),
                SampleRate = XElementParser.ParseNullableIntValue(trackElement, "Sample Rate"),
                Season = XElementParser.ParseNullableIntValue(trackElement, "Season"),
                Series = XElementParser.ParseStringValue(trackElement, "Series"),
                Size = XElementParser.ParseNullableLongValue(trackElement, "Size"),
                SkipCount = XElementParser.ParseNullableIntValue(trackElement, "Skip Count"),
                SkipDate = XElementParser.ParseNullableDateValue(trackElement, "Skip Date"),
                SortAlbum = XElementParser.ParseStringValue(trackElement, "Sort Album"),
                SortAlbumArtist = XElementParser.ParseStringValue(trackElement, "Sort Album Artist"),
                SortArtist = XElementParser.ParseStringValue(trackElement, "Sort Artist"),
                SortComposer = XElementParser.ParseStringValue(trackElement, "Sort Composer"),
                SortName = XElementParser.ParseStringValue(trackElement, "Sort Name"),
                SortSeries = XElementParser.ParseStringValue(trackElement, "Sort Series"),
                TrackCount = XElementParser.ParseNullableIntValue(trackElement, "Track Count"),
                TrackId = int.Parse(XElementParser.ParseStringValue(trackElement, "Track ID")),
                TrackNumber = XElementParser.ParseNullableIntValue(trackElement, "Track Number"),
                TrackType = XElementParser.ParseStringValue(trackElement, "Track Type"),
                VolumeAdjustment = XElementParser.ParseNullableIntValue(trackElement, "Volume Adjustment"),
                Year = XElementParser.ParseNullableIntValue(trackElement, "Year")
            };
        }
    }
}