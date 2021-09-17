using System.Collections.Generic;

namespace Shop_Store.Application.Services.Products.Queries.GetProductForSite
{
    public class ResultProductForSiteDto
    {

        public List<ProductForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }

}
