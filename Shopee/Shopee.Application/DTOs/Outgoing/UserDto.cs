using System.Collections.Generic;
using System.Text.Json.Serialization;  // Make sure to include this for JSON serialization attributes

namespace Shopee.Application.DTOs.Outgoing
{
    public class UserDto
    {
        [JsonPropertyName("username")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Username { get; set; }

        [JsonPropertyName("email")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Email { get; set; }

        [JsonPropertyName("roles")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<string>? Roles { get; set; }

        [JsonPropertyName("jwtToken")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? JwtToken { get; set; }

        // Constructor for initializing UserDto with all parameters
        public UserDto(string? username = null, string? email = null, IList<string>? roles = null, string? jwtToken = null)
        {
            Username = username;
            Email = email;
            Roles = roles;
            JwtToken = jwtToken;
        }

        // Default parameterless constructor for serialization purposes
        public UserDto() { }
    }
}