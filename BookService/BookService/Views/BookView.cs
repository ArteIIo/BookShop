using System.Collections.Generic;

namespace BookApi.Views
{
    public class BookView
    {
        public string Name { get; set; }

        public List<string> Authors { get; set; }

        public List<string> Genres { get; set; }
    }
}
