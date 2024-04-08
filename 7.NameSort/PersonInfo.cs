using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NameSort
{
    public class PersonInfo : IComparable<PersonInfo>
    {
        public string Name { private set; get; }

        public int Height { private set; get; }

        public PersonInfo(string name, int height)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException("Name cannot be null, empty, or whitespace.");
            Height = height > 0 ? height : throw new ArgumentException("Height must be greater than 0");
        }

        public int CompareTo(PersonInfo? other)
        {
            return this.Height.CompareTo(other.Height);
        }
    }
}
