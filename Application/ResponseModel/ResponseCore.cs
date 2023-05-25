using System.Text.Json.Serialization;

namespace Application.ResponseModel
{
    public class ResponseCore<T>
    {
        public ResponseCore(bool isSuccess, object errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public ResponseCore(T result)
        {
            Result = result;
        }
        public ResponseCore()
        {

        }

        public bool IsSuccess { get; set; } = true;

        public T Result { get; set; }
        public object Errors { get; set; }
       

      
        

    }
}
