using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EcommerceApp.Models.DBModels
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
            ProductCategories = new HashSet<ProductCategories>();
            ProductOptions = new HashSet<ProductOptions>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public byte[] Image { get; set; }
        public string Category { get; set; }
        public string Stock { get; set; }
        public byte[] Thumbnail { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductCategories> ProductCategories { get; set; }
        public virtual ICollection<ProductOptions> ProductOptions { get; set; }
    }
}
