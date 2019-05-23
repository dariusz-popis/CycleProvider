using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class PersonBuilderTests
    {
        [TestMethod]
        public void Build_Demo()
        {
            var builder = new PersonBuilder();

            Person defaultPerson = builder.Build();
            Person alex = builder.WithFirstName("Alex").Build();
            Person darkoAzure = builder
                .WithFirstName("Darko")
                .WithLastName("Azure")
                .Build();
            Person darkoAzure10 = builder.WithBirthDate(2010, 12, 11).Build();
            Person alex10 = builder
                .WithPerson(alex)
                .WithBirthDate(darkoAzure10.BirthDate)
                .Build();

            Console.WriteLine(defaultPerson);
            Console.WriteLine(alex);
            Console.WriteLine(darkoAzure);
            Console.WriteLine(darkoAzure10);
            Console.WriteLine(alex10);
        }
    }
}
