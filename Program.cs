using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOnMongoDB
{
    class Program
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("studentDB");
        static IMongoCollection<Student> collection = db.GetCollection<Student>("students");
        static void Main(string[] args)
        {
            Student student = new Student("Rupesh", "Rao", 9.1);
            ReadAll();
            CreateOne(student);
            ReadAll();
            UpdateOne();
            ReadAll();
            DeleteOne();
            ReadAll();
            Console.ReadKey();
        }
        public static void CreateOne(Student student)
        {
            collection.InsertOne(student);
        }
        public static void ReadAll()
        {
            List<Student> list = collection.AsQueryable().ToList<Student>();
            var students = from s in list select s;
            Console.WriteLine("The current Document/s:");
            foreach (var item in students)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.CGPA );

            }
        }
        public static void UpdateOne()
        {
            var updatedStudent = Builders<Student>.Update.Set(s => s.FirstName, "Pawan");
            collection.UpdateOne(s => s.FirstName == "Rupesh", updatedStudent);
        }
        public static void DeleteOne()
        {
            collection.DeleteOne(s => s.FirstName == "Pawan");
        }
    }
}
