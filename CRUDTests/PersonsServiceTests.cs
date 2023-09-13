﻿using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Xunit;

namespace CRUDTests
{
    public class PersonsServiceTests
    {
        private readonly IPersonsService _personsService;
        public PersonsServiceTests()
        {
            _personsService = new PersonsService();
        }

        #region AddPerson

        [Fact]
        public void AddPerson_NullPerson()
        {
            PersonAddRequest? request = null;

            Assert.Throws<ArgumentNullException>(() => _personsService.AddPerson(request));
        }

        #endregion
    }
}
