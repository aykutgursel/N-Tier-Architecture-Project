using Newtonsoft.Json;

namespace web.GurselFramework.Business.HttpService.Concrete.Models
{
    public class UserInformation
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("roleId")]
        public int RoleId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("employeeId")]
        public int EmployeeId { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("isCustomer")]
        public bool IsCustomer { get; set; }

        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }
        [JsonProperty("eMail")]
        public string Email { get; set; }
    }
}
