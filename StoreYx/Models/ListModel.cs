namespace StoreYx.Models
{
    public class ListModel
    {
        public IList<Article> ArticleModel { get; set; }
        public IList<Service> ServiceModel { get; set; }
        public Page PageModel{ get; set; }

    }
}
