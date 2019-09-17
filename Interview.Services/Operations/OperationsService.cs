using Interview.Models;
using Interview.Models.Operations;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Services.Operations
{
    //TO DO Create an interface for DI container
    public class OperationsService
    {
        //TO DO apply Dependency Injection
        private readonly DatabaseMock<Operation> _databaseMock = new DatabaseMock<Operation>();

        public IList<Operation> GetAll()
        {
            var items = _databaseMock.GetAll();

            //perform some business logic

            return items;
        }

        public Operation GetSingular(int applicationId)
        {
            var item = _databaseMock.GetAll()
                .FirstOrDefault(x => x.ApplicationId == applicationId);

            //perform some business logic

            return item;
        }
    }
}
