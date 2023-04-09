using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MvcSQL.Domain
{
    public class Article
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Название статьи")]
        public string Title { get; set; }

        [Display(Name ="Содержание статьи")]
        public string Text { get; set; }
    }
}
