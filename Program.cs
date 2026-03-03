using MyGraphQLDotNet.GraphQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<BookType>(); 

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

app.UseStaticFiles(); 
app.Run();
