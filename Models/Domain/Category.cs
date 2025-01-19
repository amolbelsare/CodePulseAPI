﻿namespace CodePulseAPI.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string urlHandle { get; set; }
        public ICollection<BlogPost> BlogPost { get; set; }
    }
}
