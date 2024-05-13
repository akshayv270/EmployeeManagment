using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeManagment.Models
{
    public class CityDataAccess
    {
        string connectionString = " Data Source=DESKTOP-59IEF9L;Initial Catalog = Employee_Managment; Integrated Security = True";

        public IEnumerable<CityModel> GetAllCity()
        {
            List<CityModel> listCityModels = new List<CityModel>();
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_City_Select", connect);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connect.Open();
                SqlDataReader rdr = command.ExecuteReader();
                
                while (rdr.Read())
                {
                    CityModel S = new CityModel();
                    S.Id = Convert.ToInt32(rdr["Id"]);
                    S.StateId = Convert.ToInt32(rdr["StateId"]);
                    S.CityName = Convert.ToString(rdr["CityName"]);
                    S.IsActive = Convert.ToBoolean(rdr["isActive"]);
                    listCityModels.Add(S);
                }
                connect.Close();
            }
            return listCityModels;
        }

        public void InsertCityModel(CityModel Smodel)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_City_Insert", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateId", Smodel.StateId);
                cmd.Parameters.AddWithValue("@CityName", Smodel.CityName);
                cmd.Parameters.AddWithValue("@City_Isactive", Smodel.IsActive);

                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public void DeleteItem(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_City_Delete", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CityId", itemId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public CityModel GetCityDataById(int? id)
        {
            CityModel cityModel = new CityModel();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_City_GetById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CityId", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cityModel.Id = Convert.ToInt32(rdr["Id"]);
                    cityModel.StateId = Convert.ToInt32(rdr["StateId"]);
                    cityModel.CityName = rdr["CityName"].ToString();
                    cityModel.IsActive = Convert.ToBoolean(rdr["isactive"]);

                }
                con.Close();
            }
            return cityModel;
        }



        public void UpdateCity(CityModel cityModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_City_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateId", cityModel.StateId);
                cmd.Parameters.AddWithValue("@CityId", cityModel.Id);

                cmd.Parameters.AddWithValue("@CityName", cityModel.CityName);
                cmd.Parameters.AddWithValue("@City_Isactive", cityModel.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public IEnumerable<StateModel> GetAllState()
        {
            List<StateModel> listStateModels = new List<StateModel>();
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_State_Select", connect);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connect.Open();
                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    StateModel S = new StateModel();
                    S.Id = Convert.ToInt32(rdr["Id"]);
                    S.StateName = Convert.ToString(rdr["StateName"]);
                    S.IsActive = Convert.ToBoolean(rdr["isActive"]);
                    listStateModels.Add(S);
                }
                connect.Close();
            }
            return listStateModels;
        }

    }
}
