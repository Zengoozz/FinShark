#region AppUserStock
// Create the JOIN model ☑
// Add the Portfolio to the AppUser ☑
// Add the Portfolio to the Stock ☑
// Add TableNames Annotation for all tables ☑
// Add DbSet to the context ☑
// setup onModelCreating Add the Relation and the Navigation Properties for each model linked between ☑
#endregion

using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public string AppUserId { get; set; }
        public int StockId { get; set; }
        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }
}