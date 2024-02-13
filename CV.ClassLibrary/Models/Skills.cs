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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int YearsOfExp { get; set; }
        [Range(0, 10)]
        public int Level {  get; set; } 
    }
}
