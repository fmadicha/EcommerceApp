using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EcommerceApp.Models.DBModels
{
    public partial class ProductOptions
    {
        public int Id { get; set; }
        public int OptionId { get; set; }
        public int ProductId { get; set; }

        public virtual Options Option { get; set; }
        public virtual Products Product { get; set; }
        public virtual Options Options { get; set; }
    }
}
