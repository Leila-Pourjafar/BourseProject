using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Bourse.Enums
{
    /// <summary>
    /// PotentialCustomerStatus
    /// </summary>
    public enum PotentialCustomerStatus : byte
    {

        /// <summary>
        /// در حال انتظار
        /// </summary>
        [Display(Name = "در حال انتظار")]
        AwaitingCall = 1,

        /// <summary>
        /// دوباره تماس بگیر
        /// </summary>
        [Display(Name = "دوباره تماس بگیر")]
        CallAgain = 2,

        /// <summary>
        /// بدون پاسخ
        /// </summary>
        [Display(Name = "بدون پاسخ")]
        NoAnswer = 3,

        /// <summary>
        /// ثبت شده است
        /// </summary>
        [Display(Name = "ثبت شده است")]
        Registered = 4,

        /// <summary>
        /// لغو شد
        /// </summary>
        [Display(Name = "لغو شد")]
        Canceled = 5,
    }
}