namespace CrudOperations.CommonLayer.Model
{
    public class GetRecordRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }

    }

    public class GetRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<GetRecordDataId> GetRecordData { get; set; }

      
    }

    public class GetRecordDataId
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }

}
