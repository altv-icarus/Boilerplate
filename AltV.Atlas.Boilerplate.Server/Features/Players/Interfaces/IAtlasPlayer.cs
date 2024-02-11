using AltV.Atlas.Boilerplate.Database.Features.Users.Models;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Boilerplate.Server.Features.Players.Interfaces;

public interface IAtlasPlayer : IPlayer
{
    public User? User { get; set; }
}