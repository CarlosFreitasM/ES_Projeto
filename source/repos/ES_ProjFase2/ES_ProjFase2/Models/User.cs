using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ES_ProjFase2.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public bool isAdmin { get; set; }
}

