using IntelifoxCodingChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelifoxCodingChallenge.Core.Dtos
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // Add other properties relevant to the article

        public UserDTO User { get; set; }
        public CategoryDTO Category { get; set; }
        public List<TagDTO> Tags { get; set; } = new();
    }
}
