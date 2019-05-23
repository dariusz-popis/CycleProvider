using CycleProvider.Contracts;
using System;

namespace CycleProvider.Library
{
    public class PersonBuilder
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }

        public PersonBuilder()
        {
            FirstName = "Automation";
            LastName = "Automation-LastName";
            BirthDate = DateTime.Now.AddYears(-20);
        }

        public PersonBuilder WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public PersonBuilder WithBirthDate(int year, int month, int day)
        {
            BirthDate = new DateTime(Math.Abs(year), month < 1 ? 1 : month > 12 ? 12 : month, day);
            return this;
        }

        public PersonBuilder WithBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
            return this;
        }

        public PersonBuilder WithPerson(IPerson person)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
            BirthDate = person.BirthDate;
            return this;
        }

        public Person Build()
        {
            return new Person(LastName)
            {
                FirstName = FirstName,
                BirthDate = BirthDate
            };
        }
    }
}
