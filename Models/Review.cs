using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_pokemon_review.Models
{
    public class Review
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Text { get; set; }
    }
}