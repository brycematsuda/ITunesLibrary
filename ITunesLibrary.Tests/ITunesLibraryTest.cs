﻿using System;
using System.Linq;
using ITunesLibrary.Tests.TestObjects;
using ITunesLibrary.Utilities;
using Moq;
using NUnit.Framework;

namespace ITunesLibrary.Tests
{
    [TestFixture]
    public class ITunesLibraryTest
    {
        private const string AlbumNameForMultipleAlbums = "Undercurrent";
        private const string AlbumWithMultipleArtists = "Bags Meets Wes";
        private const string FilePath = "itunes-library-file-location";
        private const string SongWithBadData = "Stairway To The Stars";
        private Mock<IFileSystem> fileSystem;
        private ITunesMusicLibrary subject;

        [SetUp]
        public void Setup()
        {
            fileSystem = new Mock<IFileSystem>();
            subject = new ITunesMusicLibrary(FilePath, fileSystem.Object);
        }

        [Test]
        public void Albums_Groups_Tracks_From_Different_Albums_With_Same_Name()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var result = subject.Albums;

            Assert.That(result.Count(a => a.Name == AlbumNameForMultipleAlbums), Is.EqualTo(2));
        }

        [Test]
        public void Albums_Groups_Tracks_Into_Albums_From_Library()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var results = subject.Albums;

            var result = results.First();
            Assert.That(results.Count(), Is.GreaterThan(0));
            Assert.That(result.Artist, Is.EqualTo("Bill Evans & Jim Hall"));
            Assert.That(result.Name, Is.EqualTo("Undercurrent"));
            Assert.That(result.Genre, Is.EqualTo("Jazz"));
            Assert.That(result.IsCompilation, Is.False);
            Assert.That(result.Year, Is.EqualTo(1962));
            Assert.That(result.Tracks.Count(), Is.EqualTo(8));
        }

        [Test]
        public void Albums_Groups_Tracks_With_Different_Artists_From_Same_Album()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath))
                .Returns(TestLibraryData.CreateXml());

            var results = subject.Albums;

            Assert.That(results.Any(a => a.Tracks.GroupBy(t => t.Artist).Count() > 1), Is.True);
        }

        [Test]
        public void Albums_Is_Empty_If_No_Albums_In_Library()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXmlWithNoTracks());

            var result = subject.Albums;

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Album_Name_And_Artist_Is_Unknown_If_Field_Is_Blank()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXmlWithUnknownArtistAndAlbumTracks());
            var results = subject.Albums;
            var result = results.First();

            Assert.That(result.Name, Is.EqualTo("Unknown Album"));
            Assert.That(result.Artist, Is.EqualTo("Unknown Artist"));

        }

        [Test]
        public void Albums_Uses_AlbumArtist_For_Artist_When_It_Exists()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var results = subject.Albums;

            var result = results.First(r => r.Name.StartsWith(AlbumWithMultipleArtists));
            Assert.That(result.Artist, Is.EqualTo(result.Tracks.First().AlbumArtist));
        }

        [Test]
        public void Albums_Uses_VariousArtists_As_Artist_When_Compilation_And_No_AlbumArtist_Defined()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var results = subject.Albums;

            Assert.That(results, Has.Some.Property("Artist").EqualTo("Various Artists"));
        }

        [Test]
        public void Playlists_Adds_Each_Track_To_Playlist()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var results = subject.Playlists;

            var result = results.First();
            Assert.That(result.PlaylistId, Is.EqualTo(29475));
            Assert.That(result.Name, Is.EqualTo("MILES JAZZ - 3/2/06"));
            var firstTrack = result.Tracks.First();
            Assert.That(firstTrack.Name, Is.EqualTo("So What"));
        }

        [Test]
        public void Playlists_Parses_And_Returns_All_Playlists()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var results = subject.Playlists;

            Assert.That(results.Count(), Is.EqualTo(15));
        }

        [Test]
        public void Podcasts_Parses_And_Returns_All_Podcasts()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var results = subject.Podcasts;

            Assert.That(results.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Tracks_Converts_Milliseconds_TotalTime_To_String_Playing_Time_Minutes_And_Seconds()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var result = subject.Tracks.First();

            Assert.That(result.PlayingTime, Is.EqualTo("4:35"));
        }

        [Test]
        public void Tracks_Handles_Missing_Size_Values_In_Library()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var result = subject.Tracks.First(t => t.Name == SongWithBadData);

            Assert.That(result.Size, Is.Null.Or.Empty);
        }

        [Test]
        public void Tracks_Handles_Missing_TotalTime_Values_In_Library()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var result = subject.Tracks.First(t => t.Name == SongWithBadData);

            Assert.That(result.PlayingTime, Is.Null.Or.Empty);
        }

        [Test]
        public void Tracks_Only_Parses_File_Once_For_ITunesLibrary_Lifetime()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var results = subject.Tracks;
            results = subject.Tracks;

            fileSystem.Verify(fs => fs.ReadTextFromFile(FilePath), Times.Once);
            Assert.That(results, Is.Not.Null);
        }

        [Test]
        public void Tracks_Parses_AlbumArtist_Node_If_Present()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var results = subject.Tracks;

            Assert.That(results.Any(t => !string.IsNullOrWhiteSpace(t.AlbumArtist)), Is.True);
        }

        [Test]
        public void Tracks_Parses_All_Tracks_From_Library()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var result = subject.Tracks;

            Assert.That(result.Count(), Is.EqualTo(37));
        }
        [Test]
        public void Tracks_Parses_Fields_On_Track()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var result = subject.Tracks.First();

            Assert.That(result.TrackId, Is.EqualTo(17714));
            Assert.That(result.Name, Is.EqualTo("Dream Gypsy"));
            Assert.That(result.Artist, Is.EqualTo("Bill Evans & Jim Hall"));
            Assert.That(result.Composer, Is.EqualTo("Judith Veevers"));
            Assert.That(result.Album, Is.EqualTo(AlbumNameForMultipleAlbums));
            Assert.That(result.Genre, Is.EqualTo("Jazz"));
            Assert.That(result.Kind, Is.EqualTo("AAC audio file"));
            Assert.That(result.Size, Is.EqualTo(11550486));
            Assert.That(result.TrackNumber, Is.EqualTo(3));
            Assert.That(result.Year, Is.EqualTo(1962));
            Assert.That(result.DateModified.Value.Date, Is.EqualTo(new DateTime(2012, 2, 25)));
            Assert.That(result.DateAdded.Value.Date, Is.EqualTo(new DateTime(2012, 2, 25)));
            Assert.That(result.BitRate, Is.EqualTo(320));
            Assert.That(result.SampleRate, Is.EqualTo(44100));
            Assert.That(result.PlayCount, Is.EqualTo(11));
            Assert.That(result.PlayDate.Value.Date, Is.EqualTo(new DateTime(2012, 8, 15)));
            Assert.That(result.PartOfCompilation, Is.False);
            Assert.That(result.Rating, Is.EqualTo(80));
            Assert.That(result.AlbumRating, Is.EqualTo(60));
            Assert.That(result.AlbumRatingComputed, Is.True);
            Assert.That(result.Location, Is.EqualTo("file://localhost/C:/Users/anthony/Music/iTunes/iTunes%20Music/Bill%20Evans%20&%20Jim%20Hall/Undercurrent/03%20Dream%20Gypsy.m4a"));
            Assert.That(result.PersistentId, Is.EqualTo("C7B8EDD04F93004D"));
        }
        [Test]
        public void Tracks_Populates_Null_Values_For_Nonexistent_Elements()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            var result = subject.Tracks.First();

            Assert.That(result.AlbumArtist, Is.Null.Or.Empty);
        }

        [Test]
        public void Tracks_Sets_Boolean_Properties_To_True_For_Existing_Boolean_Nodes()
        {
            fileSystem.Setup(fs => fs.ReadTextFromFile(FilePath)).Returns(TestLibraryData.CreateXml());

            Assert.That(subject.Tracks.Count(t => t.PartOfCompilation), Is.EqualTo(1));
        }
    }
}
