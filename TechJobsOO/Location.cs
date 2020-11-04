using System;
namespace TechJobsOO
{
    public class Location : JobField
    {
        public new int Id { get; }
        private static int nextId = 1;

        public Location(string value) : base(value)
        {
            Id = nextId;
            nextId++;
        }

        public override bool Equals(object obj)
        {
            return obj is JobField field &&
                   Id == field.Id;
        }
    }
}
