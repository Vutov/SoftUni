using System.Collections.Generic;
using System.Text.RegularExpressions;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private readonly Dictionary<string, Person> personsByEmail;
    private readonly Dictionary<string, SortedSet<Person>> personsByDomain;
    private readonly Dictionary<string, SortedSet<Person>> personsByNameAndTown;
    private readonly OrderedDictionary<int, SortedSet<Person>> personsByAge;
    private readonly Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByAgeThanTown;

    public PersonCollection()
    {
        this.personsByEmail = new Dictionary<string, Person>();
        this.personsByDomain = new Dictionary<string, SortedSet<Person>>();
        this.personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        this.personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
        this.personsByAgeThanTown = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person(email, name, age, town);
        this.personsByEmail[email] = person;
        var domain = GetDomain(email);
        if (!this.personsByDomain.ContainsKey(domain))
        {
            this.personsByDomain[domain] = new SortedSet<Person>();
        }

        this.personsByDomain[domain].Add(person);
        var nameAndTown = name + "_" + town;
        if (!this.personsByNameAndTown.ContainsKey(nameAndTown))
        {
            this.personsByNameAndTown[nameAndTown] = new SortedSet<Person>();
        }

        this.personsByNameAndTown[nameAndTown].Add(person);
        if (!this.personsByAge.ContainsKey(age))
        {
            this.personsByAge.Add(age, new SortedSet<Person>());
        }

        this.personsByAge[age].Add(person);
        if (!this.personsByAgeThanTown.ContainsKey(town))
        {
            this.personsByAgeThanTown[town] = new OrderedDictionary<int, SortedSet<Person>>();
        }

        if (!this.personsByAgeThanTown[town].ContainsKey(age))
        {
            this.personsByAgeThanTown[town][age] = new SortedSet<Person>();
        }

        this.personsByAgeThanTown[town][age].Add(person);

        return true;
    }

    public int Count
    {
        get { return this.personsByEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        if (this.personsByEmail.ContainsKey(email))
        {
            return this.personsByEmail[email];
        }

        return null;
    }

    public bool DeletePerson(string email)
    {
        if (!this.personsByEmail.ContainsKey(email))
        {
            return false;
        }

        var person = this.personsByEmail[email];
        this.personsByEmail.Remove(email);
        var domain = GetDomain(email);
        this.personsByDomain[domain].Remove(person);
        this.personsByNameAndTown.Remove(GetNameTownKey(person.Name, person.Town));
        this.personsByAge[person.Age].Remove(person);
        this.personsByAgeThanTown[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!this.personsByDomain.ContainsKey(emailDomain))
        {
            return new Person[0];
        }

        var persons = this.personsByDomain[emailDomain];
        return persons;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var key = GetNameTownKey(name, town);
        if (!this.personsByNameAndTown.ContainsKey(key))
        {
            return new Person[0];
        }

        var persons = this.personsByNameAndTown[key];
        return persons;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange =
            this.personsByAge.Range(startAge, true, endAge, true);
        foreach (var persons in personsInRange)
        {
            foreach (var person in persons.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByAgeThanTown.ContainsKey(town))
        {
            yield break;
        }

        var personsInRange = this.personsByAgeThanTown[town].Range(startAge, true, endAge, true);
        foreach (var persons in personsInRange)
        {
            foreach (var person in persons.Value)
            {
                yield return person;
            }
        }
    }

    private static string GetDomain(string email)
    {
        var domain = Regex.Match(email, "@(.+)").Groups[1].Value;
        return domain;
    }

    private static string GetNameTownKey(string name, string town)
    {
        return name + "_" + town;
    }
}
