using GraphQL.Types;
using GraphQLDemo1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo1.GraphQL.GraphTypes
{
    public sealed class MovieObject : ObjectGraphType<Movie>
    {
        public MovieObject()
        {
            Name = nameof(Movie);
            Description = "A movie in the collection";

            Field(m => m.Id).Description("Identifier of the movie");
            Field(m => m.Name).Description("Name of the movie");
            Field(
                name: "Reviews",
                description: "Reviews of the movie",
                type: typeof(ListGraphType<ReviewObject>),
                resolve: m => m.Source.Reviews);
        }
    }
}
