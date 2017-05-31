using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Areas.FoodArea.Models
{
    [MetadataType(typeof(FoodMetadata))]
    public partial class Food
    {
        private class FoodMetadata
        {
            [DisplayName("商品名稱")]
            public string FoodName { get; set; }

            [DisplayName("商品分類")]
            public string CategoryID { get; set; }

            [DisplayName("價格")]
            [DisplayFormat(DataFormatString = "{0:c0}")]
            public Nullable<decimal> price { get; set; }


            [DisplayName("餐廳名稱")]
            public string RestaurantName { get; set; }

            [DisplayName("商品圖片")]
            public string Foodpicture { get; set; }

            [DisplayName("產品描述")]
            [DataType(DataType.MultilineText)]
            public string Description { get; set; }

        }
    }
}