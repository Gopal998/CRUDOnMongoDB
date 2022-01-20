using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOnMongoDB
{
    public class Student
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        [BsonElement("CGPA")]
        public double CGPA { get; set; }
        public Student(string firstName, string lastName, double cGPA)
        {
            FirstName = firstName;
            LastName = lastName;
            CGPA = cGPA;
        }
    }
}
