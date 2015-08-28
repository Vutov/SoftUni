using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class PerformanceTestsPersonCollection
{
    private IPersonCollection persons;

    [TestInitialize]
    public void TestInitialize()
    {
        //this.persons = new PersonCollectionSlow();
        this.persons = new PersonCollection();
    }

    private void AddPersons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            this.persons.AddPerson(
                email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                name: "Pesho" + (i % 100),
                age: i % 100,
                town: "Sofia" + (i % 100));
        }
    }

    [TestMethod]
    [Timeout(250)]
    public void TestPerformance_AddPerson()
    {
        // Act
        AddPersons(5000);
        Assert.AreEqual(5000, this.persons.Count);
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformance_FindPerson()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 100000; i++)
        {
            var existingPerson = this.persons.FindPerson("pesho1@gmail1.com");
            Assert.IsNotNull(existingPerson);
            var nonExistingPerson = this.persons.FindPerson("non-existing email");
            Assert.IsNull(nonExistingPerson);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByEmailDomain()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 10000; i++)
        {
            var existingPersons = 
                this.persons.FindPersons("gmail1.com").ToList();
            Assert.AreEqual(50, existingPersons.Count);
            var notExistingPersons = 
                this.persons.FindPersons("non-existing email").ToList();
            Assert.AreEqual(0, notExistingPersons.Count);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByNameAndTown()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 10000; i++)
        {
            var existingPersons = 
                this.persons.FindPersons("Pesho1", "Sofia1").ToList();
            Assert.AreEqual(50, existingPersons.Count);
            var notExistingPersons =
                this.persons.FindPersons("Pesho1", "Sofia5").ToList();
            Assert.AreEqual(0, notExistingPersons.Count);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByAgeRange()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 2000; i++)
        {
            var existingPersons =
                this.persons.FindPersons(20, 21).ToList();
            Assert.AreEqual(100, existingPersons.Count);
            var notExistingPersons =
                this.persons.FindPersons(500, 600).ToList();
            Assert.AreEqual(0, notExistingPersons.Count);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByTownAndAgeRange()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 5000; i++)
        {
            var existingPersons =
                this.persons.FindPersons(18, 22, "Sofia20").ToList();
            Assert.AreEqual(50, existingPersons.Count);
            var notExistingTownPersons =
                this.persons.FindPersons(20, 30, "Missing town").ToList();
            Assert.AreEqual(0, notExistingTownPersons.Count);
            var notExistingAgePersons =
                this.persons.FindPersons(200, 300, "Sofia1").ToList();
            Assert.AreEqual(0, notExistingTownPersons.Count);
        }
    }
}
