using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Specifications.ProductSpecifications
{
    public class ProductSpecificationPram
    {
        private int pagesize = 1;
        public string? sort { get; set; }
        public int?  brandId { get; set; }
        public int? categoryId { get; set; }
        public int PageSize 
        {
            get { return pagesize; } 
            set 
            {
                pagesize = value>10? 10:value;
            } 
        }

        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value.ToLower(); }
        }

        public int index { get; set; } = 1;
    }
}
