using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data.Repositories;

namespace WebApplication3.GraphQL
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            Field<ListGraphType<OwnerType>>(
               "owners",
               resolve: context => repository.GetAll()
           );
        }
    }
}
