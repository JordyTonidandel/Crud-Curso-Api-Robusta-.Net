namespace Manager.Services.DTO
{
  public class UserDTO
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserDTO(string name, string email, string password)
    {
      this.Name = name;
      this.Email = email;
      this.Password = password;

    }

    public UserDTO() { }

  }
}
