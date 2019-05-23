using System;

namespace CycleProvider.Library
{
    public class PersonDto
    {
        private readonly PersonBase _personBase;

        public int Id { get => _personBase.Id; }
        public DateTime BirthDate { get => _personBase.BirthDate ; }

        public PersonDto(PersonBase personBase)
        {
            _personBase = personBase;
        }
    }
}
