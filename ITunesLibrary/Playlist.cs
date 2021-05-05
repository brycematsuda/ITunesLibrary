using System;
using System.Collections.Generic;
using System.Linq;

namespace ITunesLibrary
{
    public class Playlist : IEquatable<Playlist>
    {
        public string Name { get; set; }
        public int PlaylistId { get; set; }
        public IEnumerable<Track> Tracks { get; set; }

        public Playlist Copy()
        {
            return MemberwiseClone() as Playlist;
        }

        public bool Equals(Playlist other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return PlaylistId == other.PlaylistId &&
                   Name == other.Name &&
                   Tracks.SequenceEqual(other.Tracks);
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

            return Equals((Playlist)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PlaylistId, Name, Tracks);
        }

        public override string ToString()
        {
            return $"{Name} - {Tracks.Count()} tracks";
        }
    }
}
