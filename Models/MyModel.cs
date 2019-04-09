using System;
using System.ComponentModel.DataAnnotations;
namespace QuotingDojo.Models
{
    public class MyModel
    {
       
    }
    public class Quote
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2)]
        [Display(Name = "Your Name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Quote is required")]
        public string Quotecomment { get; set; }
        
    }
}