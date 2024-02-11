using AltV.Atlas.Boilerplate.Database.Features.Users.Models;

namespace AltV.Atlas.Boilerplate.Database.Features.Users.Interfaces;

public interface IUserService
{
    User? GetById( uint id );
    Task<User> RegisterAsync( string name, string password, string ipAddress );
    Task<User?> AuthenticateAsync( string name, string password );
}