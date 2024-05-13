using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeManagment.Models
{
    public class StateDataAccess
    {
        string connectionString = " Data Source=DESKTOP-59IEF9L;Initial Catalog = Employee_Managment; Integrated Security = True";

        public IEnumerable<StateModel> GetAllState()
        {
            List<StateModel> listStateModels = new List<StateModel>();
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_State_Select", connect);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connect.Open();
                SqlDataReader rdr= command.ExecuteReader();
                
                while (rdr.Read()) 
                {
                    StateModel S = new StateModel();
                    S.Id=Convert.ToInt32(rdr["Id"]);
                    S.StateName = Convert.ToString(rdr["StateName"]);
                    S.IsActive = Convert.ToBoolean(rdr["isActive"]);
                    listStateModels.Add(S);
                }
                connect.Close();
            }
            return listStateModels;
        }

        public void InsertStateModel(StateModel Smodel)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_State_Insert_New", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateName", Smodel.StateName);
                cmd.Parameters.AddWithValue("@isActive", Smodel.IsActive);

                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public void DeleteItem(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_State_Delete", connection);
                
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StateId", itemId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

            }
        }
      
            public  StateModel GetStateData(int? id)
        {
            StateModel stateModel = new StateModel();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                /*
                string sqlQuery = "SELECT * FROM tbl_State WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                */
                SqlCommand cmd = new SqlCommand("sp_State_ByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateId", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    stateModel.Id = Convert.ToInt32(rdr["Id"]);
                    stateModel.StateName = rdr["StateName"].ToString();
                    stateModel.IsActive = Convert.ToBoolean(rdr["isactive"]);
                   
                }
                con.Close();
            }
            return stateModel;
        }



        public void UpdateState(StateModel stateModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_State_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StateId", stateModel.Id);
              
                cmd.Parameters.AddWithValue("@SateName", stateModel.StateName);
                cmd.Parameters.AddWithValue("@State_Isactive", stateModel.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<CityModel> GetAllCityByStateID(int stateId)
        {
            List<CityModel> listCityModels = new List<CityModel>();
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_City_Drop", connect);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StateId", stateId);
                connect.Open();
               // SqlDataReader rdr = command.ExecuteReader();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CityModel city = new CityModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            CityName = reader["CityName"].ToString()
                        };
                        listCityModels.Add(city);
                    }
                }
                connect.Close();
            }
            return listCityModels;
        }

    }
}
