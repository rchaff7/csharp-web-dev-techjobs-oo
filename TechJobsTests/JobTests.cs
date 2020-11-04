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

        [TestMethod]
        public void TestInheritedEquals()
        {
            Console.WriteLine(ACME.Id + " " + Desert.Id + " " + QualityControl.Id + " " + Persistence.Id);
            Console.WriteLine(Desert.Value);
            Assert.IsFalse(ACME.Equals(Desert));
            Assert.IsTrue(ACME.Equals(ACME));
            Assert.IsTrue(Desert is JobField && ACME.Id == Desert.Id);
            Assert.IsFalse(Desert is Employer && ACME.Id == Desert.Id);
        }
    }
}

/* how does the Equals method of parent class get inherited if you dont override it within the child??
 * does the child class get compared as JobField class or as its own class??
 * (it seems the different child classes are not equal even if they have the same ID
 * when using the Parent Equals method. Does inheriting the method change the logic
 * to compare 'obj is *currentclass*' rather than 'obj is JobField'??)
 * 
 * all child classes share the nextId field from parent instead of having their own counter.
 * this also means they can share the Equals method of the base class 
 * since none of them will ever have the same id as another.
 * 
 * does the Parent nextId field get used by all the children because its static??
 * 
 * is it intended for the Objects to not have sequential ID numbers within their own class??
 * 
 * Should Job class also not inherit from JobField since it also
 * uses some of the same fields and properties???
 * 
 * What is the point of all these child classes that literally dont do anything
 * more than the parent class? everything still works.
 * Is it purely for organization during creation of a Job object with the constructor?
*/