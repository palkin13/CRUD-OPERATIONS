namespace CrudOperations.CommonLayer.Model
{
   
        public class DeleteRecordReactRequest
        {
            public int Id { get; set; }
        }

        public class DeleteRecordReactResponse
        {


            public bool IsSuccess { get; set; }
            public string Message { get; set; }


        }
   
}
