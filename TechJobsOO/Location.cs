using System;
namespace TechJobsOO
{
    public class Location : JobField
    {
        public Location(string value) : base(value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   Id == location.Id;
        }
    }
}
