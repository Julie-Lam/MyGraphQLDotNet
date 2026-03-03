using MyGraphQLDotNet.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MyGraphQLDotNet.GraphQL
{
    public class Query
    {
        public List<Book> Books(string nameContains = "")
        {
            var books = ReadAllBooks();
            if (string.IsNullOrWhiteSpace(nameContains))
            {
                return books;
            }


            return books.Where(b => b.Name.Contains(nameContains)).ToList();


        }

        private List<Book> ReadAllBooks()
        {
            string fileName = "Database/books.json";
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
        }
    }

    public class BookType : ObjectType<Book> 
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field("publishDate").ResolveWith<Resolvers>(r => r.GetFormattedDate(default!)); 
        }
    }
}
