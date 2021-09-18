using aspNetTest.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetTest.Data
{
    public class LoansRepository
    {
        private readonly string _connectionString;

        public LoansRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionSql");
        }

        private LoansCE ListLoans(SqlDataReader reader)
        {
            return new LoansCE()
            {
                ID_Request_Loans = (int)reader["ID_Request_Loans"],
                ID_Client = (int)reader["ID_Client"],
                T_ClientName = reader["T_ClientName"].ToString(),
                D_Date_Request = reader["D_Date_Request"].ToString(),
                N_Request_Amount = Convert.ToDecimal(reader["N_Request_Amount"]),
            };
        }
        public async Task<ResponseLoans> GetAllLoans()
        {
            ResponseLoans oResponse = new ResponseLoans();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_REQUEST_LOANS_LIST_LOANS", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        List<LoansCE> ltLoans = new List<LoansCE>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ltLoans.Add(ListLoans(reader));
                            }
                        }

                        if (ltLoans == null)
                        {
                            oResponse.oReponse.setResponseSinRegistros();
                        }
                        else
                        {
                            oResponse.oReponse.setResponseSuccessfully();
                            oResponse.ltLoans = ltLoans;
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
        public async Task<ResponseLoans> GetLoansByIdClient(int id)
        {
            ResponseLoans oResponse = new ResponseLoans();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_REQUEST_LOANS_LIST_LOANS_X_ID", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ID_Client", id));
                        List<LoansCE> ltLoans = new List<LoansCE>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ltLoans.Add(ListLoans(reader));
                            }
                        }

                        if (ltLoans == null)
                        {
                            oResponse.oReponse.setResponseSinRegistros();
                        }
                        else
                        {
                            oResponse.oReponse.setResponseSuccessfully();
                            oResponse.ltLoans = ltLoans;
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
        public async Task<ResponseLoans> Insert(LoansCE loans)
        {
            ResponseLoans oResponse = new ResponseLoans();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_REQUEST_LOANS_ADD_LOANS", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ID_Client", loans.ID_Client));
                        cmd.Parameters.Add(new SqlParameter("@D_Date_Request", loans.D_Date_Request));
                        cmd.Parameters.Add(new SqlParameter("@N_Request_Amount", loans.N_Request_Amount));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        oResponse.oLoans = loans;
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
        public async Task<ResponseLoans> UpdateById(LoansCE loans)
        {
            ResponseLoans oResponse = new ResponseLoans();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_REQUEST_LOANS_EDIT_LOANS", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ID_Request_Loans", loans.ID_Request_Loans));
                        cmd.Parameters.Add(new SqlParameter("@ID_Client", loans.ID_Client));
                        cmd.Parameters.Add(new SqlParameter("@D_Date_Request", loans.D_Date_Request));
                        cmd.Parameters.Add(new SqlParameter("@N_Request_Amount", loans.N_Request_Amount));

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
        public async Task<ResponseLoans> DeleteById(int id)
        {
            ResponseLoans oResponse = new ResponseLoans();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TB_REQUEST_LOANS_DELETE_LOANS", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ID_Request_Loans", id));

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
