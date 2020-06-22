using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Bourse.Models
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName(displayName: "نام")]
        public string Name { get; set; }

        [DisplayName("شناسه")]
        public string CategoryId { get; set; }
        public virtual ICollection<SubCategories> SubCategories { get; set; }
    }
}