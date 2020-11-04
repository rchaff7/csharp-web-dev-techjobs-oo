using System;
namespace TechJobsOO
{
    public class CoreCompetency : JobField
    {
        public CoreCompetency(string v) : base(v)
        {
            Value = v;
        }

        public override bool Equals(object obj)
        {
            return obj is CoreCompetency competency &&
                   Id == competency.Id;
        }
    }
}
