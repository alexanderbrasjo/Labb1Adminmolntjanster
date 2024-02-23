using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using CV.ClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CV.ClassLibrary.Models
{
    public class Skills
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
		[Required(ErrorMessage = "Name is required.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Description is required.")]
		public string Description { get; set; }
		[Range(0, 100, ErrorMessage = "Years of Experience must be between 0 and 100.")]
		public int YearsOfExp { get; set; }
		[Range(1, 10, ErrorMessage = "Skill Level must be between 1 and 10.")]
		public int Level {  get; set; } 
    }
}
