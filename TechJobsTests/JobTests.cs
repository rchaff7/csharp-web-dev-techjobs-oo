using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {

        Employer ACME = new Employer("ACME");
        Location Desert = new Location("Desert");
        PositionType QualityControl = new PositionType("Quality Control");
        CoreCompetency Persistence = new CoreCompetency("Persistence");

        Job job1 = new Job();
        Job job2 = new Job();
        Job job3;
        Job job4;

        [TestInitialize]
        public void Initialize()
        {
            job3 = new Job("Product Tester", ACME, Desert, QualityControl, Persistence);
            job4 = new Job("Product Tester", ACME, Desert, QualityControl, Persistence);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(10, 10);
        }

        [TestMethod]
        public void TestSettingJobID()
        {
            Assert.AreEqual(job1.Id, job2.Id-1);
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



    }
}
