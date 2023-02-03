using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

using System.Collections.Generic;
using DrivenAdapters.Mongo.Entities.Base;
using Domain.Model.Entities;
using System.Linq;

namespace DrivenAdapters.Mongo.Entities;

public class PostDocument : IDomainEntityAdapter<Post>
{
    [BsonId]
    [BsonElement("id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Content { get; set; }

    [BsonElement("likes")]
    public long Likes { get; set; }

    [BsonElement("comments")]
    public IList<CommentDocument> Comments { get; set; }

    public Post AsEntity()
    {
        return new Post
        {
            Id = Id,
            Content = Content,
            Likes = Likes,
            Comments = Comments
                .Select(doc => doc.AsEntity())
                .ToList()
        };
    }
}