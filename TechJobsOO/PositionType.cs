using System;
namespace TechJobsOO
{
    public class PositionType : JobField
    {
        public PositionType(string value) : base(value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is PositionType type &&
                   Id == type.Id;
        }
    }
}
