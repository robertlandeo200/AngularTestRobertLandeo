using aspNetTest.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetTest.Data
{
    public class ClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionSql");
        }

        private ClientCE ListClients(SqlDataReader reader)
        {
            return new ClientCE()
            {
                ID_Client = (int)reader["ID_Client"],
                T_ClientName = reader["T_ClientName"].ToString(),
                D_Birthdate = reader["D_Birthdate"].ToString(),
            };
        }
        public async Task<ResponseClient> GetAllClient()
        {
            ResponseClient oResponse = new ResponseClient();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_CLIENT_LIST_CLIENT", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        List<ClientCE> ltClient = new List<ClientCE>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ltClient.Add(ListClients(reader));
                            }
                        }

                        if (ltClient == null)
                        {
                            oResponse.oReponse.setResponseSinRegistros();
                        }
                        else
                        {
                            oResponse.oReponse.setResponseSuccessfully();
                            oResponse.ltClient = ltClient;
                        }

                        return oResponse;
                    }
                }
                catch (Exception ex)
                {
                    oResponse.oReponse.setResponseError();
                    oResponse.oReponse.responseMessage = ex.Message;
                    return oResponse;
                }
            }
        }
        public async Task<ResponseClient> GetByClientName(string clientname)
        {
            ResponseClient oResponse = new ResponseClient();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_CLIENT_LIST_CLIENT_X_NAME", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@T_ClientName", clientname));
                        List<ClientCE> ltClient = new List<ClientCE>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ltClient.Add(ListClients(reader));
                            }
                        }

                        if (ltClient == null)
                        {
                            oResponse.oReponse.setResponseSinRegistros();
                        }
                        else
                        {
                            oResponse.oReponse.setResponseSuccessfully();
                            oResponse.ltClient = ltClient;
                        }

                        return oResponse;
                    }
                }
                catch (Exception ex)
                {
                    oResponse.oReponse.setResponseError();
                    oResponse.oReponse.responseMessage = ex.Message;
                    return oResponse;
                }
            }
        }
        public async Task<ResponseClient> Insert(ClientCE client)
        {
            ResponseClient oResponse = new ResponseClient();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_CLIENT_ADD_CLIENT", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@T_ClientName", client.T_ClientName));
                        cmd.Parameters.Add(new SqlParameter("@D_Birthdate", client.D_Birthdate));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        
                        oResponse.oClient = client;
                        oResponse.oReponse.setResponseSuccessfully();
                        
                        return oResponse;
                    }
                }
                catch (Exception ex)
                {
                    oResponse.oReponse.setResponseError();
                    oResponse.oReponse.responseMessage = ex.Message;
                    return oResponse;
                }
            }
        }
        public async Task<ResponseClient> UpdateById(ClientCE client)
        {
            ResponseClient oResponse = new ResponseClient();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_CLIENT_EDIT_CLIENT", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ID_Client", client.ID_Client));
                        cmd.Parameters.Add(new SqlParameter("@T_ClientName", client.T_ClientName));
                        cmd.Parameters.Add(new SqlParameter("@D_Birthdate", client.D_Birthdate));

                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        oResponse.oReponse.setResponseSuccessfully();
                        return oResponse;
                    }
                }
                catch (Exception ex)
                {
                    oResponse.oReponse.setResponseError();
                    oResponse.oReponse.responseMessage = ex.Message;
                    return oResponse;
                }

            }
        }
        public async Task<ResponseClient> DeleteById(int id)
        {
            ResponseClient oResponse = new ResponseClient();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_CLIENT_DELETE_CLIENT", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ID_Client", id));

                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        oResponse.oReponse.setResponseSuccessfully();
                        return oResponse;
                    }
                }
                catch (Exception ex)
                {
                    oResponse.oReponse.setResponseError();
                    oResponse.oReponse.responseMessage = ex.Message;
                    return oResponse;
                }
            }
        }
    }
}
