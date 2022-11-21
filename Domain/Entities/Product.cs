using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace valexis.Domain.Entities
{
    public class Product
    {
        public static List<string> categories = new List<string>() { "модульные гостиные", "гостиные", "кухни", "детская мебель", "модульные спальни", "спальни", "шкафы и прихожие", "столы и стулья", "садовая мебель" };

        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        public float Price { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Фото")]
        public string ImageLink { get; set; }


        [Display(Name = "SEO Ключевые слова")]
        public string MetaKeywords { get; set; }

        public Product() 
        {
            Name = "";
            Price = 0;
            Category = "";
            Description = "";
            ImageLink = "nopic.png";
            MetaKeywords = "";
        }
    }
}
