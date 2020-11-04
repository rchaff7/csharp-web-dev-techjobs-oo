using System;
using System.Collections.Generic;

namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }


        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            if(Name == null)
            {
                return "OOPS! This job does not seem to exist.";
            }

            string nameString = Name;
            string employerNameString = EmployerName.Value;
            string employerLocationString = EmployerLocation.Value;
            string jobTypeString = JobType.Value;
            string jobCoreCompetencyString = JobCoreCompetency.Value;

            int emptyFieldCount = 0;

            List<string> stringList = new List<string>
            {
                nameString,
                employerNameString,
                employerLocationString,
                jobTypeString,
                jobCoreCompetencyString
            };

            for (int i = 0; i < stringList.Count; i++)
            {
                if (stringList[i] == "" || stringList[i] == null)
                {
                    emptyFieldCount++;
                    stringList[i] = "Data not available";
                }
            };

            if (emptyFieldCount >= stringList.Count)
            {
                return "OOPS! This job does not seem to exist.";
            }

            return "\n" +
                "ID: " + Id + "\n" +
                "Name: " + stringList[0] + "\n" +
                "Employer: " + stringList[1] + "\n" +
                "Location: " + stringList[2] + "\n" +
                "Position Type: " + stringList[3] + "\n" +
                "Core Competency: " + stringList[4] + "\n" +
                "\n";
        }
    }
}
