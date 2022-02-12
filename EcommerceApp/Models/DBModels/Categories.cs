using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EcommerceApp.Models.DBModels
{
    public partial class Categories
    {
        public Categories()
        {
            ProductCategories = new HashSet<ProductCategories>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Thumbnail { get; set; }

        public virtual ICollection<ProductCategories> ProductCategories { get; set; }
    }
}
