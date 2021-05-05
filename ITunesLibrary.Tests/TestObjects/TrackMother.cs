using System;

namespace ITunesLibrary.Tests.TestObjects
{
    public static class TrackMother
    {
        public static Track Create()
        {
            return new Track
            {
                Album = "Speak No Evil",
                AlbumArtist = "Wayne Shorter",
                AlbumRating = 60,
                AlbumRatingComputed = true,
                Artist = "Wayne Shorter",
                ArtworkCount = 1,
                BitRate = 330,
                Comments = "Recorded at the Rudy Van Gelder Studio, Englewood Cliffs, New Jersey.",
                Composer = "Wayne Shorter",
                DateAdded = DateTime.Today,
                DateModified = DateTime.Today,
                DiscCount = 1,
                DiscNumber = 1,
                Genre = "Jazz",
                IsPodcast = false,
                IsPurchased = true,
                Kind = "AAC Audio File",
                Location = "file://localhost/C:/Users/anthony/Music/iTunes/iTunes%20Music/Wayne%20Shorter/Speak%20No%20Evil/01%20Witch%20Hunt.m4a",
                Name = "Witch Hunt",
                PartOfCompilation = false,
                PlayCount = 55,
                PlayDate = DateTime.Today,
                PlayingTime = "4:35",
                Rating = 50,
                RatingComputed = true,
                ReleaseDate = new DateTime(1964, 12, 24),
                SampleRate = 44100,
                Size = 5768594,
                TrackCount = 6,
                TrackId = 456,
                TrackNumber = 1,
                Year = 1964
            };
        }
    }
}