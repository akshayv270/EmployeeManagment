namespace EmployeeManagment.Models
{
    public class StateModel
    {
        public int Id { get; set; }
        public string StateName { get; set; }

        public bool IsActive { get; set; }
    }

    public class CityModel
    {
        public int Id { get; set; }

        public int StateId{ get; set; }
        public string CityName { get; set; }

        public bool IsActive { get; set; }
    }
}
