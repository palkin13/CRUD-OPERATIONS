using CrudOperations.CommonLayer.Model;
using System.Data;
using System.Data.SqlClient;

namespace CrudOperations.RepositoryLayer
{
    public class CrudOperationRL : ICrudOperationRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        public CrudOperationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }

        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            // string msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("uspAddRecord", _sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                cmd.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                _sqlConnection.Open();
                int status = await cmd.ExecuteNonQueryAsync();
                if (status <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;

        }


        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = new DeleteRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";

            try
            {
                //string SqlQuery = "Delete from CrudOperationTable where Id = @Id";
                using (SqlCommand sqlCommand = new SqlCommand("uspDeleteRecord", _sqlConnection))
                {
                    //sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }

        public async Task<DeleteRecordReactResponse> DeleteRecordReact(DeleteRecordReactRequest request)
        {
            DeleteRecordReactResponse response = new DeleteRecordReactResponse();
            response.IsSuccess = true;
            response.Message = "Successful";

            try
            {
                //string SqlQuery = "Delete from CrudOperationTable where Id = @Id";
                using (SqlCommand sqlCommand = new SqlCommand("uspDeleteRecordReact", _sqlConnection))
                {
                    //sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;

        }

        public async Task<GetRecordResponse> GetRecord(GetRecordRequest request)
        {
            GetRecordResponse response = new GetRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";

            try
            {

                using (SqlCommand sqlCommand = new SqlCommand("uspGetRecordId", _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", request.Id);
                    //sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    //sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {

                        if (sqlDataReader.HasRows)
                        {
                            response.GetRecordData = new List<GetRecordDataId>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                GetRecordDataId dbData = new GetRecordDataId();
                                dbData.Id = sqlDataReader[name: "Id"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Id"]) : 0;
                                dbData.UserName = sqlDataReader[name: "UserName"] != DBNull.Value ? sqlDataReader[name: "UserName"].ToString() : string.Empty;
                                dbData.Age = sqlDataReader[name: "Age"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Age"]) : 0;
                                response.GetRecordData.Add(dbData);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            ReadRecordResponse response = new ReadRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";

            try
            {

                using (SqlCommand sqlCommand = new SqlCommand("uspGetRecord", _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.readRecordData = new List<ReadRecordData>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                ReadRecordData dbData = new ReadRecordData();
                                dbData.Id = sqlDataReader[name: "Id"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Id"]) : 0;
                                dbData.UserName = sqlDataReader[name: "UserName"] != DBNull.Value ? sqlDataReader[name: "UserName"].ToString() : string.Empty;
                                dbData.Age = sqlDataReader[name: "Age"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Age"]) : 0;
                                response.readRecordData.Add(dbData);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }


        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = new UpdateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";

            try
            {
                // string SqlQuery = "Update CrudOperationTable Set UserName = @UserName, Age = @Age where Id = @Id";
                using (SqlCommand sqlCommand = new SqlCommand("uspUpdateRecord", _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }

        public async Task<UpdateRecordByIdResponse> UpdateRecordById(UpdateRecordByIdRequest request)
        {
            UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successful";

            try
            {
                // string SqlQuery = "Update CrudOperationTable Set UserName = @UserName, Age = @Age where Id = @Id";
                using (SqlCommand sqlCommand = new SqlCommand("uspUpdateRecordById", _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }

    }
}




//public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
//{
//    CreateRecordResponse response = new CreateRecordResponse();
//    response.IsSuccess = true;
//    response.Message = "Successful";

//    try
//    {
//        string SqlQuery = "Insert into CrudOperationtable (UserName, Age) values (@UserName, @Age)";
//        using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
//        {
//            sqlCommand.CommandType = System.Data.CommandType.Text;
//            sqlCommand.CommandTimeout = 180;
//            sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
//            sqlCommand.Parameters.AddWithValue(parameterName: "@Age", request.Age);
//            _sqlConnection.Open();
//            int status = await sqlCommand.ExecuteNonQueryAsync();
//            if (status <= 0)
//            {
//                response.IsSuccess = false;
//                response.Message = "Something Went Wrong";
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        response.IsSuccess = false;
//        response.Message = ex.Message;
//    }
//    finally
//    {
//        _sqlConnection.Close();
//    }
//    return response;
//}

