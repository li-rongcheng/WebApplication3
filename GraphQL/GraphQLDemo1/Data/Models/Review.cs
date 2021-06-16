using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDemo1.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Guid MovieId { get; set; }
        public string Reviewer { get; set; }
        public int Stars { get; set; }
    }
}
