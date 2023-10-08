﻿using System.Reflection.PortableExecutable;

namespace CodePulse.Api.Models.Domain
{
    public class BlogPost
    {
        public Guid  Id { get; set; }
        public string  Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public string author { get; set; }

        public DateTime PublichedDate { get; set; }

        public bool IsVisible { get; set; }



    }
}