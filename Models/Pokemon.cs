using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_pokemon_review.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}