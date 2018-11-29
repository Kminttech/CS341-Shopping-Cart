using System.Collections.Generic;

namespace cs341.Models
{
    public class PromoPageModel
    {
        public List<Item> SaleItems { get; set; }
        public List<Promotion> Promotions { get; set; }
    }
}
