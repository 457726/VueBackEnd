using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        var newsApiClient = new NewsApiClient("abdac52f05f64ef5805779553a2218e3");
        var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
        {
            Q = "Apple",
            SortBy = SortBys.Popularity,
            Language = Languages.EN,
            From = new DateTime(2018, 1, 25)
        });
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    // title
                    Console.WriteLine(article.Title);
                    // author
                    Console.WriteLine(article.Author);
                    // description
                    Console.WriteLine(article.Description);
                    // url
                    Console.WriteLine(article.Url);
                    // published at
                    Console.WriteLine(article.PublishedAt);
                }
}
Console.ReadLine();
        }

    }
}
