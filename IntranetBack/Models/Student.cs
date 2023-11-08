namespace Intranet.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int MajorId { get; set; }
        public Major StudentMajor { get; set; }
    }
}
