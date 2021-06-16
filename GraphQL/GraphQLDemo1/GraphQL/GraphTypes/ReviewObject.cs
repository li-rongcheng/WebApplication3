using GraphQL.Types;
using GraphQLDemo1.Data.Models;

namespace GraphQLDemo1.GraphQL.GraphTypes
{
    public sealed class ReviewObject : ObjectGraphType<Review>
    {
        public ReviewObject()
        {
            Name = nameof(Review);
            Description = "A review of the movie";

            Field(r => r.Reviewer).Description("Name of the reviewer");
            Field(r => r.Stars).Description("Star rating out of five");
        }
    }
}