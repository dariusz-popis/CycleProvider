using CycleProvider.Contracts;
using System;

namespace CycleProvider.Library
{
    public abstract class PersonBase : IPerson
    {
        public static int Counter { get; private set; } = 0;

        public int Id { get; }
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract DateTime BirthDate { get; set; }

        public PersonBase(string lastName)
        {
            Id = ++Counter;
        }

        public override string ToString()
        {
            return $"Person {Id} of {Counter} => {LastName} {FirstName}, was born {BirthDate}";
        }

        protected virtual void CalculateAge()
        {
            PrivateCalculationInvoked();
        }

        private static void PrivateCalculationInvoked()
        {
            Console.WriteLine("Base calculation");
        }
    }
}
