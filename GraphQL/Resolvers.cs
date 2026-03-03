using MyGraphQLDotNet.Models;

namespace MyGraphQLDotNet.GraphQL
{
    public class Resolvers
    {

        public string GetFormattedDate([Parent] Book e)
        {
            return e.PublishDate.ToShortDateString();
        }
    }
}
