using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ESFase2.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Username { get; set; } = null!;
    [BsonElement("Password")]
    public string Password { get; set; } = null!;
    [BsonElement("Email")]
    public string Email { get; set; } = null!;
    [BsonElement("Phone")]
    public string Phone { get; set; } = null!;
    [BsonElement("Admin")]
    public bool isAdmin { get; set; }
}

