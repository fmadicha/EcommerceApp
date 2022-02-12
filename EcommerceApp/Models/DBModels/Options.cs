using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EcommerceApp.Models.DBModels
{
    public partial class Options
    {
        public Options()
        {
            ProductOptions = new HashSet<ProductOptions>();
        }

        public int Id { get; set; }
        public string OptionName { get; set; }

        public virtual ProductOptions IdNavigation { get; set; }
        public virtual ICollection<ProductOptions> ProductOptions { get; set; }
    }
}
