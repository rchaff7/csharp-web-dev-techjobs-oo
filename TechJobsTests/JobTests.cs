using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        private static Employer ACME = new Employer("ACME");
        private static Location Desert = new Location("Desert");
        private static PositionType QualityControl = new PositionType("Quality Control");
        private static CoreCompetency Persistence = new CoreCompetency("Persistence");

        private static Job job1 = new Job();
        private static Job job2 = new Job();
        private static Job job3 = new Job("Product Tester", ACME, Desert, QualityControl, Persistence);
        private static Job job4 = new Job("Product Tester", ACME, Desert, QualityControl, Persistence);

        private string output2 = job2.ToString();
        private string output3 = job3.ToString();
        private string output4;

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(10, 10);
        }

        [TestMethod]
        public void TestSettingJobID()
        {
            Assert.AreEqual(job1.Id, job2.Id - 1);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.IsTrue(
                job3.Id == 3 &&
                job3.Name == "Product Tester" &&
                job3.EmployerName.Value == "ACME" &&
                job3.EmployerLocation.Value == "Desert" &&
                job3.JobType.Value == "Quality Control" &&
                job3.JobCoreCompetency.Value == "Persistence"
            );
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job3.Equals(job4));
        }

        [TestMethod]
        public void TestJobToStringMethodForBlankLines()
        {
            Assert.IsTrue(
                output3.IndexOf('\n') == 0 &&
                output3.LastIndexOf('\n') == output3.Length - 1
            );
        }

        [TestMethod]
        public void TestJobToStringMethodFieldDataOnOwnLines()
        {
            string[] splitStr = output3.Split('\n');
            Console.WriteLine(splitStr[1]);

            Assert.IsTrue(
                splitStr[1] == "ID: 3" &&
                splitStr[2] == "Name: Product Tester" &&
                splitStr[3] == "Employer: ACME" &&
                splitStr[4] == "Location: Desert" &&
                splitStr[5] == "Position Type: Quality Control" &&
                splitStr[6] == "Core Competency: Persistence"
            );
        }

        [TestMethod]
        public void TestJobToStringMethodForEmptyFields()
        {
            job4.Name = "";
            job4.EmployerName.Value = null;
            output4 = job4.ToString();
            Console.WriteLine(output4);

            string[] splitStr = output4.Split('\n');
            Console.WriteLine(splitStr[2]);

            Assert.IsTrue(
                splitStr[2] == "Name: Data not available" &&
                splitStr[3] == "Employer: Data not available"
            );
        }

        [TestMethod]
        public void TestJobToStringMethodForOnlyIDHasValue()
        {
            Console.Write(output2);

            Assert.IsTrue(
                output2 == "OOPS! This job does not seem to exist."
            );
        }



    }
}
