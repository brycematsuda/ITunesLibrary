﻿using System.Linq;
using ITunesLibrary.Tests.TestObjects;
using NUnit.Framework;

namespace ITunesLibrary.Tests
{
    [TestFixture]
    public class AlbumTest
    {
        private Album subject;

        [SetUp]
        public void SetUp()
        {
            subject = AlbumMother.Create();
        }

        [Test]
        public void Album_ToString()
        {
            Assert.That(subject.ToString(),
                Is.EqualTo($"{subject.Artist} - {subject.Name} - {subject.Tracks.Count()} tracks"));
        }

        [Test]
        public void Copy()
        {
            var result = subject.Copy();

            Assert.That(result, Is.EqualTo(subject));
            Assert.That(result, Is.Not.SameAs(subject));
        }

        [Test]
        public void Equals_Returns_False_When_Not_Equal()
        {
            var other = AlbumMother.Create();
            other.Name = "New Album";

            var result = subject.Equals(other);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_Returns_False_When_Not_SameType()
        {
            var other = PlaylistMother.Create();

            var result = subject.Equals(other);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_Returns_False_When_Null()
        {
            var result = subject.Equals(null);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_Returns_True_When_Equal()
        {
            var other = AlbumMother.Create();

            var result = subject.Equals(other);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Equals_Returns_True_When_Same_Reference()
        {
            var result = subject.Equals(subject);

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetHashCode_Returns_A_Different_HashCode_For_Albums_Not_Equal()
        {
            var other = subject.Copy();
            other.Name = "Blue Trane";
            var expectedHashCode = other.GetHashCode();

            var result = subject.GetHashCode();

            Assert.That(result, Is.Not.EqualTo(expectedHashCode));
        }

        [Test]
        public void GetHashCode_Returns_The_Same_HashCode_For_Equal_Albums()
        {
            var expectedHashCode = subject.Copy().GetHashCode();

            var result = subject.GetHashCode();

            Assert.That(result, Is.EqualTo(expectedHashCode));
        }

        [Test]
        public void Object_Equals_Returns_False_When_Null()
        {
            var result = subject.Equals((object)null);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Object_Equals_Returns_True_When_Equal()
        {
            var other = AlbumMother.Create() as object;

            var result = subject.Equals(other);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Object_Equals_Returns_True_When_ReferenceEqual()
        {
            var result = subject.Equals(subject as object);

            Assert.That(result, Is.True);
        }
    }
}
