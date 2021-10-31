using System.Text.Json;

namespace RestServer.Data
{
    public class Adult : Person
    {
        public string JobTitle { get; set; }
        public int Salary { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}