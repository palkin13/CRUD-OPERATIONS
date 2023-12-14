using CrudOperations.CommonLayer.Model;
using CrudOperations.RepositoryLayer;
using CrudOperations.Controllers;

namespace CrudOperations.ServiceLayer
{
    public class CrudOperationSL : ICrudOperationSL
    {
        public readonly ICrudOperationRL _crudOperationRL;
        public CrudOperationSL(ICrudOperationRL crudOperationRL)
        {
            _crudOperationRL = crudOperationRL;
        }
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
           return await _crudOperationRL.CreateRecord(request); 
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            return await _crudOperationRL.DeleteRecord(request);        
        }

        public async Task<DeleteRecordReactResponse> DeleteRecordReact(DeleteRecordReactRequest request)
        {
            return await _crudOperationRL.DeleteRecordReact(request);
        }

        public async Task<GetRecordResponse> GetRecord(GetRecordRequest request)
        {
            return await _crudOperationRL.GetRecord(request);
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            return await _crudOperationRL.ReadRecord();
        }

        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            return await _crudOperationRL.UpdateRecord(request);
        }

        public async Task<UpdateRecordByIdResponse> UpdateRecordById(UpdateRecordByIdRequest request)
        {
            return await _crudOperationRL.UpdateRecordById(request);
        }
    }
}
