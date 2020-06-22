using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Bourse.Models
{
    /// <summary>
    /// کلاسی برای ذخیره لاگ های الحاق سریالی هولوگرام ها به یک  محصول 
    /// </summary>
    public class JoinedHologram
    {
        /// <summary>
        /// سازنده کلاس 
        /// </summary>
        public JoinedHologram()
        {
            IsReversed = false;
            CreateDate = DateTime.Now;
        }

        /// <summary>
        /// key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// از سریال 
        ///// </summary>
        //[Required(ErrorMessage = Const.FillRequired)]
        [Display(Name = "از سریال")]
        public int StartSerialNumber { get; set; }

        /// <summary>
        /// تا سریال 
        /// </summary>
        //[Required(ErrorMessage = Const.FillRequired)]
        [Display(Name = "تا سریال")]
        public int EndSerialNumber { get; set; }

        /// <summary>
        /// ایدی محصول 
        /// </summary>
        [Required]
        //[Display(Name = Const.BookName)]
        public Guid BookId { get; set; }

        /// <summary>
        /// Reversed
        /// </summary>
        [Display(Name = "کنسل شده")]
        public bool IsReversed { get; set; }

        /// <summary>
        /// ارتباط با جدول الحاق هولوگرام به یک ناشر 
        /// </summary>
        //[Required(ErrorMessage = Const.FillRequired)]
        public int PublisherHologramId { get; set; }

        /// <summary>
        /// CreateUserId
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// ModifiedUsedId
        /// </summary>
        [Display(Name = "کاربری که ویرایش کرده")]
        public Guid? ModifiedUsedId { get; set; }

        /// <summary>
        /// توضیحات 
        /// </summary>
        //[Display(Name = Const.Description)]
        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// تاریخ ایجاد رکورد 
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// ReversedDate
        /// </summary>
        [Display(Name = "تاریخ کنسلی")]
        public DateTime? ReversedDate { get; set; }

        /**************************************/
        /// <summary>
        /// Users 
        /// </summary>
       // public virtual aspnet_Users Users { get; set; }

        /// <summary>
        /// ModifiyUsers
        /// </summary>
      //  public virtual aspnet_Users ModifiyUsers { get; set; }

        /// <summary>
        /// ارتباط با جدول book
        /// </summary>
      //  public virtual book Book { get; set; }

        /// <summary>
        /// ارتباط با جدول PublisherHologram
        /// </summary>

      //  public virtual PublisherHologram PublisherHologram { get; set; }

        /// <summary>
        /// کالکشنی از هولوگرام ها
        /// </summary>
     //   public virtual ICollection<randomNumber> RandomNumbers { get; set; }

        /**************************************/
    }

    //public class JoinedHologramEntityConfiguration : EntityTypeConfiguration<JoinedHologram>
    //{
    //    public JoinedHologramEntityConfiguration()
    //    {

    //        this
    //            .HasMany(e => e.RandomNumbers)
    //            .WithOptional(e => e.JoinedHologram)
    //            .HasForeignKey(e => e.JoinedHologramId)
    //            .WillCascadeOnDelete(false);
    //    }
    //}
}