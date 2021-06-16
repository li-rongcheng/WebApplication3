using GraphQL;
using GraphQL.Types;
using GraphQLDemo1.Data.Models;
using GraphQLDemo1.Data.Repositories;
using GraphQLDemo1.GraphQL.GraphTypes;
using System;

namespace GraphQLDemo1.GraphQL
{
    public sealed class ReviewInputObject : InputObjectGraphType<Review>
    {
        public ReviewInputObject()
        {
            Name = "ReviewInput";
            Description = "A review of the movie";

            Field(r => r.Reviewer).Description("Name of the reviewer");
            Field(r => r.Stars).Description("Star rating out of five");
        }
    }

    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(IMovieRepository repository)
        {
            Name = "Mutations";
            Description = "The base mutation for all the entities in our object graph.";

            FieldAsync<MovieObject, Movie>(
                "addReview",
                "Add review to a movie.",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "The unique GUID of the movie."
                    },
                    new QueryArgument<NonNullGraphType<ReviewInputObject>>
                    {
                        Name = "review",
                        Description = "Review for the movie."
                    }),
                context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    var review = context.GetArgument<Review>("review");
                    return repository.AddReviewToMovieAsync(id, review);
                });
        }
    }
}