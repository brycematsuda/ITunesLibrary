using System;
using System.Collections.Generic;
using System.Linq;

namespace ITunesLibrary
{
    public class Album : IEquatable<Album>
    {
        public string Artist { get; set; }
        public string Genre { get; set; }
        public bool IsCompilation { get; set; }
        public string Name { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
        public int? Year { get; set; }

        public Album Copy()
        {
            return MemberwiseClone() as Album;
        }

        public bool Equals(Album other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Artist == other.Artist &&
                   Name == other.Name &&
                   Genre == other.Genre &&
                   Year == other.Year &&
                   IsCompilation == other.IsCompilation &&
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

            return Equals((Album)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Artist, Name, Genre, Year, IsCompilation, Tracks);
        }

        public override string ToString()
        {
            return $"{Artist} - {Name} - {Tracks.Count()} tracks";
        }
    }
}