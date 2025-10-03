namespace AdoptAMonsterSite.Models;

public class User
{
    public int Id { get; set; }                         //Primary key in the database structure and unique identifier which is to be auto generated
    public required string Username { get; set; }       //Username which is required for login and used to display the user's name in the site
    public required string Email { get; set; }          //MOSTLY nonfunctional, but as quarter goes on this might actually have a good use case
    public required string Password { get; set; }       //Password which is required to login to a users account

    public User(int id, string username, string email, string password) 
    { 
        this.Id = id;
        this.Username = username;
        this.Email = email;
        this.Password = password;
    }
}
