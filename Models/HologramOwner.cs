using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bourse.Models
{
    /// <summary>
    /// جدولی برای ذخیره مالک هولوگرام ها و بازه های الحاقی 
    /// </summary>
    public class HologramOwner
    {
        /// <summary>
        /// سازنده 
        /// </summary>
        public HologramOwner()
        {
            CreateDate = DateTime.Now;
            IsActive = true;
        }

        /// <summary>
        /// کلید 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ناشر کتاب 
        /// </summary>
        public int PublisherId { get; set; }

        /// <summary>
        /// ابتدای بازه 
        /// </summary>
        public int StartSerialNumber { get; set; }

        /// <summary>
        /// انتهای بازه 
        /// </summary>
        public int EndSerialNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? BookId { get; set; }

        /// <summary>
        /// وضعیت 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// تاریخ ایجاد 
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// مالک برچسب
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// لیستی از ناشر ها 
        /// </summary>
        [NotMapped]
        public List<SelectItem> SelectItems { get; set; }
    }

    public class SelectItem
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}