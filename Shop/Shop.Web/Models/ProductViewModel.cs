

namespace Shop.Web.Models
{
    using Data.Entities;
    using Microsoft.AspNetCore.Http;
    using System;

    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel : Product
    {
        [Display(Name="Image")]
        public IFormFile ImageFile { get; set; }
    }
}
