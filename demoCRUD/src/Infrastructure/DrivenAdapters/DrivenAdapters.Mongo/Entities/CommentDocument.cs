using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using DrivenAdapters.Mongo.Entities.Base;
using Domain.Model.Entities;

namespace DrivenAdapters.Mongo.Entities;

public class CommentDocument : IDomainEntityAdapter<Comment>
{
    [BsonId]
    [BsonElement("id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id;

    [BsonElement("content")]
    public string Content;

    [BsonElement("likes")]
    public long Likes;

    public Comment AsEntity()
    {
        return new Comment
        {
            Id = Id,
            Content = Content,
            Likes = Likes
        };
    }
}