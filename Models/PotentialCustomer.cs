using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Bourse.Enums;
namespace Bourse.Models
{
    /// <summary>
    /// مشتری بالقوه
    /// </summary>
    public class PotentialCustomer
    {
        /// <summary>
        /// PotentialCustomer
        /// </summary>
        public PotentialCustomer()
        {
            Campaign = false;
            Competition = false;
            BookClub = false;
            Gift = false;
            CreateDate = DateTime.Now;
        }

        /// <summary>
        /// کلید جدول 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [StringLength(100)]
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

        /// <summary>
        /// نام شرکت یا سازمان
        /// </summary>
        [Required]
        [StringLength(200)]
        [Display(Name = "نام شرکت ")]
        public string CompanyName { get; set; }

        /// <summary>
        /// نام واحد 
        /// </summary>
        [Required]
        [StringLength(200)]
        [Display(Name = "نام واحد ")]
        public string UnitName { get; set; }

        /// <summary>
        /// شماره تماس 
        /// </summary>
        [Required]
        [StringLength(15)]
        [Display(Name = "شماره تماس ")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// شماره تلفن همراه 
        /// </summary>
        [StringLength(11)]
        [Display(Name = "تلفن همراه")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// تعداد کارکنان
        /// </summary>
        [Display(Name = "تعداد کارکنان")]
        public int? CreditNumber { get; set; }

        /// <summary>
        /// مبلغ بن برای هر یک از کارکنان
        /// </summary>
        [Display(Name = "مبلغ بن برای هر یک از کارکنان")]
        public int? CreditAmount { get; set; }

        /// <summary>
        /// جشنواره 
        /// </summary>
        [Display(Name = "جشنواره")]
        public bool Campaign { get; set; }

        /// <summary>
        /// مسابقه کتابخوانی یا آزمون
        /// </summary>
        [Display(Name = "مسابقه کتابخوانی یا آزمون")]
        public bool Competition { get; set; }

        /// <summary>
        /// در خواست راه اندازی باشگاه کتابخوانی سازمان
        /// </summary>
        [Display(Name = "در خواست راه اندازی باشگاه کتابخوانی سازمان")]
        public bool BookClub { get; set; }

        /// <summary>
        /// هدرخواست هدیه کتاب به عموم مردم یا قشر خاص ( مدافعان سلامت )
        /// </summary>
        [Display(Name = "درخواست هدیه کتاب به عموم مردم یا قشر خاص ( مدافعان سلامت )")]
        public bool Gift { get; set; }

        /// <summary>
        /// توضیحات مشتری
        /// </summary>
        [StringLength(250)]
        [Display(Name = "توضیحات بیشتر")]
        public string CustomerDescription { get; set; }

        /// <summary>
        /// وضعیت بالقوه مشتری
        /// </summary>
        public PotentialCustomerStatus? StatusId { get; set; }

        /// <summary>
        /// توضیحات مدیر
        /// </summary>
        [StringLength(250)]
        public string AdminDescription { get; set; }

        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// تاریخ ویرایش 
        /// </summary>
        public DateTime? ModifyDate { get; set; }
    }
}