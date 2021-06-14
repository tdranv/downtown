using Downtown.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Downtown.Rest.Controllers
{
    [ApiController]
    [Route("rss")]
    public class RssController : ControllerBase
    {
        private readonly IEventRepository eventRepository;

        public RssController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Rss()
        {
            var feed = new SyndicationFeed("Events", "List of all events", new Uri("http://localhost:3000/"), "RSSUrl", DateTime.Now);
            feed.Copyright = new TextSyndicationContent($"{DateTime.Now.Year} Downtown app Team");

            var items = new List<SyndicationItem>();
            var events = await eventRepository.GetAllAsync().ConfigureAwait(false);
            foreach (var item in events)
            {
                items.Add(new SyndicationItem(item.Name, item.Description, null, item.Id.ToString(), item.HappensOn));
            }

            feed.Items = items;

            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                NewLineHandling = NewLineHandling.Entitize,
                NewLineOnAttributes = true,
                Indent = true
            };
            using (var stream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(stream, settings))
                {
                    var rssFormatter = new Rss20FeedFormatter(feed, false);
                    rssFormatter.WriteTo(xmlWriter);
                    xmlWriter.Flush();
                }

                return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
            }
        }
    }
}
