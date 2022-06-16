using System.Text.Json;

namespace PowerSarj_2022.Entities.Concrete.ErrorModels
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; } // 500 300 400 lü kodlar 200 lü kodları yazarız
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
