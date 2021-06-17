Back to [parent README](../README.md)

# GraphQLDemo1

- Framework: .net5
- Template: WebAPI
- Based on lib: GraphQL.Server
- In code notes: search [MCN]

- From tutorial:

  [Build a Basic GraphQL Server with ASP.NET Core and Entity Framework in 10 Minutes](https://thecloudblog.net/post/build-a-basic-graphql-server-with-asp.net-core-and-entity-framework-in-10-minutes/ )

- MCN notes ref:
  
  [2021_06_16__16_17_13] graphql (using GraphQL.Server) ~ "notes. prog''. _\notes. prog''. tutorials .mcn"

## Demo

**Main**

- Query
- Mutation
- GraphQL.Server.Ui.Altair

**Others**

- InMemory Database
- Replace builtin DI with AutoFac

## Test GraphQL Messages

**Query message**

```
query {
  movie(id: "72d95bfd-1dac-4bc2-adc1-f28fd43777fd") {
    id
    name
    reviews {
      reviewer
      stars
    }
  }
}
```

**Mutation Message**

```
mutation addReview($review: ReviewInput!) {
  addReview(id: "72d95bfd-1dac-4bc2-adc1-f28fd43777fd", review: $review) {
    id
    name
    reviews {
      reviewer
      stars
    }
  }
}
```

relevant variables:

```
{
  "review": {
    "reviewer": "Rahul",
    "stars": 5
  }
}
```
