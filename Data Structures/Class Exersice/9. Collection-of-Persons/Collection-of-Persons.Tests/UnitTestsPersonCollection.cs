using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class UnitTestsPersonCollection
{
    private IPersonCollection persons;

    [TestInitialize]
    public void TestInitialize()
    {
        //this.persons = new PersonCollectionSlow();
        this.persons = new PersonCollection();
    }

    [TestMethod]
    public void AddPerson_ShouldWorkCorrectly()
    {
        // Arrange

        // Act
        var isAdded =
            this.persons.AddPerson("pesho@gmail.com", "Peter", 18, "Sofia");

        // Assert
        Assert.IsTrue(isAdded);
        Assert.AreEqual(1, this.persons.Count);
    }

    [TestMethod]
    public void AddPerson_DuplicatedEmail_ShouldWorkCorrectly()
    {
        // Arrange

        // Act
        var isAddedFirst =
            this.persons.AddPerson("pesho@gmail.com", "Peter", 18, "Sofia");
        var isAddedSecond =
            this.persons.AddPerson("pesho@gmail.com", "Maria", 24, "Plovdiv");

        // Assert
        Assert.IsTrue(isAddedFirst);
        Assert.IsFalse(isAddedSecond);
        Assert.AreEqual(1, this.persons.Count);
    }

    [TestMethod]
    public void FindPerson_ExistingPerson_ShouldReturnPerson()
    {
        // Arrange
        this.persons.AddPerson("pesho@gmail.com", "Peter", 28, "Plovdiv");

        // Act
        var person = this.persons.FindPerson("pesho@gmail.com");

        // Assert
        Assert.IsNotNull(person);
    }

    [TestMethod]
    public void FindPerson_NonExistingPerson_ShouldReturnNothing()
    {
        // Arrange

        // Act
        var person = this.persons.FindPerson("pesho@gmail.com");

        // Assert
        Assert.IsNull(person);
    }

    [TestMethod]
    public void DeletePerson_ShouldWorkCorrectly()
    {
        // Arrange
        this.persons.AddPerson("pesho@gmail.com", "Peter", 28, "Plovdiv");

        // Act
        var isDeletedExisting =
            this.persons.DeletePerson("pesho@gmail.com");
        var isDeletedNonExisting =
            this.persons.DeletePerson("pesho@gmail.com");

        // Assert
        Assert.IsTrue(isDeletedExisting);
        Assert.IsFalse(isDeletedNonExisting);
        Assert.AreEqual(0, persons.Count);
    }

    [TestMethod]
    public void FindPersonsByEmailDomain_ShouldReturnMatchingPersons()
    {
        // Arrange
        this.persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        this.persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
        this.persons.AddPerson("mary@gmail.com", "Maria", 21, "Plovdiv");
        this.persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");

        // Act
        var personsGmail = this.persons.FindPersons("gmail.com");
        var personsYahoo = this.persons.FindPersons("yahoo.co.uk");
        var personsHoo = this.persons.FindPersons("hoo.co.uk");

        // Assert
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com", "mary@gmail.com", "pesho@gmail.com" },
            personsGmail.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "kiro@yahoo.co.uk" },
            personsYahoo.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsHoo.Select(p => p.Email).ToList());
    }

    [TestMethod]
    public void FindPersonsByNameAndTown_ShouldReturnMatchingPersons()
    {
        // Arrange
        this.persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        this.persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
        this.persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
        this.persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
        this.persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");

        // Act
        var personsPeshoPlovdiv = this.persons.FindPersons("Pesho", "Plovdiv");
        var personsLowercase = this.persons.FindPersons("pesho", "plovdiv");
        var personsPeshoNoTown = this.persons.FindPersons("Pesho", null);
        var personsAnnaBourgas = this.persons.FindPersons("Anna", "Bourgas");

        // Assert
        CollectionAssert.AreEqual(
            new string[] { "pepi@gmail.com", "pepi2@yahoo.fr", "pesho@gmail.com" },
            personsPeshoPlovdiv.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsLowercase.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsPeshoNoTown.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com" },
            personsAnnaBourgas.Select(p => p.Email).ToList());
    }

    [TestMethod]
    public void FindPersonsByAgeRange_ShouldReturnMatchingPersons()
    {
        // Arrange
        this.persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        this.persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
        this.persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
        this.persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
        this.persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
        this.persons.AddPerson("asen@gmail.com", "Asen", 21, "Rousse");

        // Act
        var personsAgedFrom21to22 = this.persons.FindPersons(21, 22);
        var personsAgedFrom10to11 = this.persons.FindPersons(10, 11);
        var personsAged21 = this.persons.FindPersons(21, 21);
        var personsAged19 = this.persons.FindPersons(19, 19);
        var personsAgedFrom0to1000 = this.persons.FindPersons(0, 1000);

        // Assert
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk" },
            personsAgedFrom21to22.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsAgedFrom10to11.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr" },
            personsAged21.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com" },
            personsAged19.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com", "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk", "pesho@gmail.com" },
            personsAgedFrom0to1000.Select(p => p.Email).ToList());
    }

    [TestMethod]
    public void FindPersonsByAgeRangeAndTown_ShouldReturnMatchingPersons()
    {
        // Arrange
        this.persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        this.persons.AddPerson("kirosofia@yahoo.co.uk", "Kiril", 22, "Sofia");
        this.persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
        this.persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
        this.persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
        this.persons.AddPerson("ani17@gmail.com", "Anna", 17, "Bourgas");
        this.persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
        this.persons.AddPerson("asen.rousse@gmail.com", "Asen", 21, "Rousse");
        this.persons.AddPerson("asen@gmail.com", "Asen", 21, "Plovdiv");

        // Act
        var personsAgedFrom21to22Plovdiv = this.persons.FindPersons(21, 22, "Plovdiv");
        var personsAgedFrom10to11Sofia = this.persons.FindPersons(10, 11, "Sofia");
        var personsAged21Plovdiv = this.persons.FindPersons(21, 21, "Plovdiv");
        var personsAged19Bourgas = this.persons.FindPersons(19, 19, "Bourgas");
        var personsAgedFrom0to1000Plovdiv = this.persons.FindPersons(0, 1000, "Plovdiv");
        var personsAgedFrom0to1000NewYork = this.persons.FindPersons(0, 1000, "New York");

        // Assert
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk" },
            personsAgedFrom21to22Plovdiv.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsAgedFrom10to11Sofia.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr" },
            personsAged21Plovdiv.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com" },
            personsAged19Bourgas.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk", "pesho@gmail.com" },
            personsAgedFrom0to1000Plovdiv.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
           new string[] { },
           personsAgedFrom0to1000NewYork.Select(p => p.Email).ToList());
    }

    [TestMethod]
    public void FindDeletedPersons_ShouldReturnEmptyCollection()
    {
        // Arrange
        this.persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        this.persons.AddPerson("kirosofia@yahoo.co.uk", "Kiril", 22, "Sofia");
        this.persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
        this.persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
        this.persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
        this.persons.AddPerson("ani17@gmail.com", "Anna", 17, "Bourgas");
        this.persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
        this.persons.AddPerson("asen.rousse@gmail.com", "Asen", 21, "Rousse");
        this.persons.AddPerson("asen@gmail.com", "Asen", 21, "Plovdiv");

        this.persons.DeletePerson("pesho@gmail.com");
        this.persons.DeletePerson("kirosofia@yahoo.co.uk");
        this.persons.DeletePerson("kiro@yahoo.co.uk");
        this.persons.DeletePerson("pepi@gmail.com");
        this.persons.DeletePerson("ani@gmail.com");
        this.persons.DeletePerson("ani17@gmail.com");
        this.persons.DeletePerson("pepi2@yahoo.fr");
        this.persons.DeletePerson("asen.rousse@gmail.com");
        this.persons.DeletePerson("asen@gmail.com");

        // Act
        var personPeshoGmail = this.persons.FindPerson("pesho@gmail.com");

        var personsGmail = this.persons.FindPersons("gmail.com");
        var personsYahoo = this.persons.FindPersons("yahoo.co.uk");

        var personsPeshoPlovdiv = this.persons.FindPersons("Pesho", "Plovdiv");

        var personsAgedFrom21to22 = this.persons.FindPersons(21, 22);
        var personsAgedFrom0to1000 = this.persons.FindPersons(0, 1000);

        var personsAgedFrom21to22Plovdiv = this.persons.FindPersons(21, 22, "Plovdiv");
        var personsAged19Bourgas = this.persons.FindPersons(19, 19, "Bourgas");

        // Assert
        Assert.AreEqual(null, personPeshoGmail);

        Assert.AreEqual(0, personsGmail.Count());
        Assert.AreEqual(0, personsYahoo.Count());

        Assert.AreEqual(0, personsPeshoPlovdiv.Count());

        Assert.AreEqual(0, personsAgedFrom21to22.Count());
        Assert.AreEqual(0, personsAgedFrom0to1000.Count());

        Assert.AreEqual(0, personsAgedFrom21to22Plovdiv.Count());
        Assert.AreEqual(0, personsAged19Bourgas.Count());
    }

    [TestMethod]
    public void MultipleOperations_ShouldReturnWorkCorrectly()
    {
        var isAdded = this.persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        Assert.IsTrue(isAdded);
        Assert.AreEqual(1, this.persons.Count);

        isAdded = this.persons.AddPerson("pesho@gmail.com", "Pesho2", 222, "Plovdiv222");
        Assert.IsFalse(isAdded);
        Assert.AreEqual(1, this.persons.Count);

        this.persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
        Assert.AreEqual(2, this.persons.Count);

        this.persons.AddPerson("asen@gmail.com", "Asen", 22, "Sofia");
        Assert.AreEqual(3, this.persons.Count);

        Person person = persons.FindPerson("non-existing person");
        Assert.IsNull(person);

        person = persons.FindPerson("pesho@gmail.com");
        Assert.IsNotNull(person);
        Assert.AreEqual("pesho@gmail.com", person.Email);
        Assert.AreEqual("Pesho", person.Name);
        Assert.AreEqual(28, person.Age);
        Assert.AreEqual("Plovdiv", person.Town);

        var personsGmail = this.persons.FindPersons("gmail.com");
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pesho@gmail.com" },
            personsGmail.Select(p => p.Email).ToList());

        var personsPeshoPlovdiv = this.persons.FindPersons("Pesho", "Plovdiv");
        CollectionAssert.AreEqual(
            new string[] { "pesho@gmail.com" },
            personsPeshoPlovdiv.Select(p => p.Email).ToList());

        var personsPeshoSofia = this.persons.FindPersons("Pesho", "Sofia");
        Assert.AreEqual(0, personsPeshoSofia.Count());

        var personsKiroPlovdiv = this.persons.FindPersons("Kiro", "Plovdiv");
        Assert.AreEqual(0, personsKiroPlovdiv.Count());

        var personsAge22To28 = this.persons.FindPersons(22, 28);
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "kiro@yahoo.co.uk", "pesho@gmail.com" },
            personsAge22To28.Select(p => p.Email).ToList());

        var personsAge22To28Plovdiv = this.persons.FindPersons(22, 28, "Plovdiv");
        CollectionAssert.AreEqual(
            new string[] { "kiro@yahoo.co.uk", "pesho@gmail.com" },
            personsAge22To28Plovdiv.Select(p => p.Email).ToList());

        var isDeleted = this.persons.DeletePerson("pesho@gmail.com");
        Assert.IsTrue(isDeleted);

        isDeleted = this.persons.DeletePerson("pesho@gmail.com");
        Assert.IsFalse(isDeleted);

        person = persons.FindPerson("pesho@gmail.com");
        Assert.IsNull(person);

        personsGmail = this.persons.FindPersons("gmail.com");
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com" },
            personsGmail.Select(p => p.Email).ToList());

        personsPeshoPlovdiv = this.persons.FindPersons("Pesho", "Plovdiv");
        CollectionAssert.AreEqual(
            new string[] { },
            personsPeshoPlovdiv.Select(p => p.Email).ToList());

        personsPeshoSofia = this.persons.FindPersons("Pesho", "Sofia");
        Assert.AreEqual(0, personsPeshoSofia.Count());

        personsKiroPlovdiv = this.persons.FindPersons("Kiro", "Plovdiv");
        Assert.AreEqual(0, personsKiroPlovdiv.Count());

        personsAge22To28 = this.persons.FindPersons(22, 28);
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "kiro@yahoo.co.uk" },
            personsAge22To28.Select(p => p.Email).ToList());

        personsAge22To28Plovdiv = this.persons.FindPersons(22, 28, "Plovdiv");
        CollectionAssert.AreEqual(
            new string[] { "kiro@yahoo.co.uk" },
            personsAge22To28Plovdiv.Select(p => p.Email).ToList());
    }
}
