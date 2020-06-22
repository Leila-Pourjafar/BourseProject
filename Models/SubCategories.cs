using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bourse.Models
{
    public class SubCategories
    {
        public int Id { get; set; }

        [DisplayName("نام")]
        [StringLength(200)]
        public string Name { get; set; }

        [DisplayName("نماد")]
        [StringLength(200)]
        public string Symbol { get; set; }

        [DisplayName("عنوان انگلیسی")]
        public string AliasName { get; set; }

        [StringLength(30)]
        public string UniqueID { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Symbol> Symbols { get; set; }
    }
}