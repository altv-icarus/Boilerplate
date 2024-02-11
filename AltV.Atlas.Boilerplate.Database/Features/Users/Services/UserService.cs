using System.Threading.Tasks;
using AltV.Atlas.Boilerplate.Database.Context;
using AltV.Atlas.Boilerplate.Database.Features.Users.Interfaces;
using AltV.Atlas.Boilerplate.Database.Features.Users.Models;
using AltV.Atlas.Database.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AltV.Atlas.Boilerplate.Database.Features.Users.Services;

public class UserService( IAtlasRepository<AtlasDbContext, User> userRepository, PasswordHasher<User> passwordHasher ) : IUserService
{
    public User? GetById( uint id )
    {
        return userRepository.GetById( id );
    }

    public async Task<User> RegisterAsync( string name, string password, string ipAddress )
    {
        var user = new User
        {
            Name = name,
            IpAddress = ipAddress,
            Kills = 0,
            Deaths = 0
        };
        user.Password = passwordHasher.HashPassword( user, password );
        
        userRepository.Insert( user );
        await userRepository.SaveChangesAsync( );

        return user;
    }

    public async Task<User?> AuthenticateAsync( string name, string password )
    {
        var user = userRepository.FirstOrDefault( u => u.Name == name );

        if( user is null )
            return default;

        if( passwordHasher.VerifyHashedPassword( user, user.Password, password ) == PasswordVerificationResult.Failed )
            return default;
        
        return user;
    }
}