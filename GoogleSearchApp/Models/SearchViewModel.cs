using DAL.Models;

namespace GoogleSearchApp.Models
{
    public class SearchViewModel
    {
        public string SearchWord { get; set; }
        public List<Result> Results { get; set; }
        public string filterWord { get; set; }
        
    }
}
