using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace kakeibo3.Models
{
    public class CashRow
    {
        public int ID { get; set; }

        /// <summary>
        /// 支払日
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime PayDate { get; set; }

        /// <summary>
        /// 品目
        /// </summary>
        [Required]
        public string PayItem { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        [BindRequired]
        public int Price { get; set; }

        /// <summary>
        /// 支払者
        /// </summary>
        [Required]
        public string Payer { get; set; }

        /// <summary>
        /// 支払者の列挙型
        /// </summary>
        [NotMapped]
        public PayerEnum PayersEnum { get; set; }

        /// <summary>
        /// 支払者を名ひらがなで
        /// </summary>
        [NotMapped]
        public string PayerStr
        {
            get
            {
                int num = int.Parse(Payer);
                PayerEnum payer = (PayerEnum)Enum.ToObject(typeof(PayerEnum), num);
                return payer.ToString();
            }
        }

        /// <summary>
        /// 支払い方法
        /// </summary>
        [Required]
        public string Payment { get; set; }

        /// <summary>
        /// 支払い方法の列挙型
        /// </summary>
        [NotMapped]
        public PaymentEnum PaymentsEnum { get; set; }

        /// <summary>
        /// 支払い方法をひらがなで
        /// </summary>
        [NotMapped]
        public string PaymentStr
        {
            get
            {
                int num = int.Parse(Payment);
                PaymentEnum payment = (PaymentEnum)Enum.ToObject(typeof(PaymentEnum), num);
                return payment.ToString();
            }
        }

        /// <summary>
        /// 分類
        /// </summary>
        [Required]
        public string CostType { get; set; }

        /// <summary>
        /// 分類の列挙型
        /// </summary>
        [NotMapped]
        public CostTypeEnum CostTypesEnum { get; set; }

        /// <summary>
        /// 分類をひらがなで
        /// </summary>
        [NotMapped]
        public string CostTypeStr
        {
            get
            {
                int num = int.Parse(CostType);
                CostTypeEnum costType = (CostTypeEnum)Enum.ToObject(typeof(CostTypeEnum), num);
                return costType.ToString();
            }
        }

        /// <summary>
        /// 期間開始日
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 期間終了日
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// ○月分
        /// </summary>
        public string ForMonth { get; set; }
    }

    /// <summary>
    /// 支払者
    /// </summary>
    public enum PayerEnum
    {
        [Display(Name = "ゆうや")]
        Yuya,

        [Display(Name = "あんじゅ")]
        Anju
    }

    /// <summary>
    /// 支払い方法
    /// </summary>
    public enum PaymentEnum
    {
        [Display(Name = "現金")]
        Money,

        [Display(Name = "ウォルマートカード")]
        WalmartCard,

        [Display(Name = "Suica")]
        Suica,

        [Display(Name = "その他")]
        Other
    }

    /// <summary>
    /// 分類
    /// </summary>
    public enum CostTypeEnum
    {
        [Display(Name = "食費")]
        Food,

        [Display(Name = "日用品費")]
        DailyItem,

        [Display(Name = "電気")]
        Electlic,

        [Display(Name = "ガス")]
        Gas,

        [Display(Name = "水道")]
        Water,

        [Display(Name = "家賃")]
        Home,

        [Display(Name = "通信費")]
        Network,

        [Display(Name = "その他")]
        Other

    }
}
