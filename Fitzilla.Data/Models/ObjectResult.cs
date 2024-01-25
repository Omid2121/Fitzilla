namespace Fitzilla.DAL.Models
{
    public class ObjectResult
    {
        public string Message { get; set; }

        public object Data { get; set; }

        public ObjectResult(object data)
        {
            Data = data;
            Message = "Operation successful";
        }

        public ObjectResult(string errorMessage)
        {
            Data = null;
            Message = errorMessage;
        }
    }
}
