using System;
using System.Collections.Generic;
using System.Linq;

namespace ITunesLibrary
{
    public class Podcast : IEquatable<Podcast>
    {
        public IEnumerable<Track> Episodes { get; set; }
        public Track Feed { get; set; }

        public Podcast Copy()
        {
            return MemberwiseClone() as Podcast;
        }

        public bool Equals(Podcast other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Track.Equals(Feed, other.Feed) &&
                   Episodes.SequenceEqual(other.Episodes);
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

            return Equals((Podcast)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Feed, Episodes);
        }

        public override string ToString()
        {
            return $"{Feed.Artist} - {Feed.Name} - {Episodes.Count()} episodes";
        }
    }
}
