using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudOperations.CommonLayer.Model;
using CrudOperations.ServiceLayer;


namespace CrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        public readonly ICrudOperationSL _crudOperationSL;

        public CrudOperationController(ICrudOperationSL crudOperationSL)
        {
            _crudOperationSL = crudOperationSL;
        }

        [HttpPost]
        [Route(template: "CreateRecord")]
        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.CreateRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [Route(template: "ReadRecord")]
        public async Task<IActionResult> ReadRecord()
        {
            ReadRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.ReadRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }

            return Ok(response);
        }

        [HttpPut]
        [Route(template: "UpdateRecord")]

        public async Task<IActionResult> UpdateRecord( UpdateRecordRequest request)
        {
            UpdateRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.UpdateRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPut]
        [Route(template: "UpdateRecordById/{id}")]

        public async Task<IActionResult> UpdateRecordById(UpdateRecordByIdRequest request)
        {
            UpdateRecordByIdResponse response = null;

            try
            {
                response = await _crudOperationSL.UpdateRecordById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpDelete]
        [Route(template: "DeleteRecord/{id}")]

        public async Task<IActionResult> DeleteRecord([FromRoute] DeleteRecordRequest request)
        {
            DeleteRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.DeleteRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpDelete]
        [Route(template: "DeleteRecordReact")]

        public async Task<IActionResult> DeleteRecordReact(DeleteRecordReactRequest request)
        {
            DeleteRecordReactResponse response = null;

            try
            {
                response = await _crudOperationSL.DeleteRecordReact(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }



        [HttpGet]
        [Route(template: "GetRecord/{id}")]
        public async Task<IActionResult> GetRecord([FromRoute] int id)
        {
            GetRecordResponse response = new GetRecordResponse(); 
            try

            {
                GetRecordRequest getRecordRequest = new GetRecordRequest
                {
                    Id = id,
                 
                
                  
                };
                response = await _crudOperationSL.GetRecord(getRecordRequest);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }


    }
}
