using System.Collections.Generic;

namespace RestServer.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public int Height { get; set; }
        public string Sex { get; set; }
        private List<Person> persons = new List<Person>();
    }
}