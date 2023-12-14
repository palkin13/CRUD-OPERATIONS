namespace CrudOperations.CommonLayer.Model
{
    public class UpdateRecordByIdRequest
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

      


    }

    public class UpdateRecordByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
