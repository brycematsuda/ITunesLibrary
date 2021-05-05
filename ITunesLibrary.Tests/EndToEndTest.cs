﻿using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ITunesLibrary.Tests
{
    [TestFixture]
    public class EndToEndTest
    {
        private readonly string fileLocation = Path.Combine(TestContext.CurrentContext.TestDirectory,
            "sampleiTunesLibrary.xml");
        private ITunesMusicLibrary subject;

        [SetUp]
        public void SetUp()
        {
            subject = new ITunesMusicLibrary(fileLocation);
        }

        [Test]
        public void Tracks_Reads_Library_From_Filesystem_And_Parses()
        {
            var results = subject.Tracks;

            var result = results.First();
            Assert.That(result.TrackId, Is.EqualTo(17714));
            Assert.That(result.Name, Is.EqualTo("Dream Gypsy"));
            Assert.That(result.Artist, Is.EqualTo("Bill Evans & Jim Hall"));
            Assert.That(result.Rating, Is.EqualTo(80));
            Assert.That(result.AlbumRating, Is.EqualTo(60));
            Assert.True(result.AlbumRatingComputed);
        }
    }
}

