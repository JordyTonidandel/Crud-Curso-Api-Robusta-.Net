using Newtonsoft.Json;

namespace Manager.Services.DTO
{
  public class UserDTO
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string Password { get; set; }

    public UserDTO(string name, string email, string password, long id)
    {
      this.Id = id;
      this.Name = name;
      this.Email = email;
      this.Password = password;

    }

    public UserDTO() { }

  }
}
