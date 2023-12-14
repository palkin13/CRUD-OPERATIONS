using CrudOperations.CommonLayer.Model;


namespace CrudOperations.ServiceLayer
{
    public interface ICrudOperationSL 
    {
        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);

        public Task<ReadRecordResponse> ReadRecord();

        public Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);

        public Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);

        public Task<GetRecordResponse> GetRecord(GetRecordRequest request);

        public Task<UpdateRecordByIdResponse> UpdateRecordById(UpdateRecordByIdRequest request);

        public Task<DeleteRecordReactResponse> DeleteRecordReact(DeleteRecordReactRequest request);



    }
}
