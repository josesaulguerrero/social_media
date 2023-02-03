using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;

using DrivenAdapters.Mongo.Entities;

using MongoDB.Driver;

namespace DrivenAdapters.Mongo.Adapters;

public class PostRepositoryAdapter : IPostsRepositoryGateway
{
    private readonly IMongoCollection<PostDocument> _postsCollection;

    public PostRepositoryAdapter(IContext db)
    {
        _postsCollection = db.Posts;
    }

    public async Task<Comment> AppendComment(string postId, Comment comment)
    {
        CommentDocument commentDocument = new CommentDocument
        {
            Id = Guid.NewGuid().ToString(),
            Likes = 0,
            Content = comment.Content
        };
        UpdateDefinition<PostDocument> changes = Builders<PostDocument>
            .Update
            .AddToSet(post => post.Comments, commentDocument);
        await _postsCollection
            .UpdateOneAsync(
                Builders<PostDocument>.Filter.Eq(post => post.Id, postId),
                changes
            );

        return commentDocument.AsEntity();
    }

    public async Task<bool> Delete(string id)
    {
        DeleteResult results = await _postsCollection.DeleteOneAsync((post => post.Id == id));
        return results.IsAcknowledged && results.DeletedCount == 1;
    }

    public async Task<IEnumerable<Post>> FindAll()
    {
        IAsyncCursor<PostDocument> results = await _postsCollection.FindAsync(Builders<PostDocument>.Filter.Empty);
        List<Post> posts = results
                .ToEnumerable()
                .Select(postDocument => postDocument.AsEntity()).ToList();

        return posts;
    }

    public async Task<Post> FindPostById(string postId)
    {
        PostDocument post = await _postsCollection
            .Find((post => post.Id == postId))
            .FirstOrDefaultAsync();

        if (post is null) throw new ArgumentException("The given Id is not linked to any Post.");

        return post.AsEntity();
    }

    public async Task<bool> RemoveComment(string postId, string commentId)
    {
        UpdateDefinition<PostDocument> changes = Builders<PostDocument>
            .Update
            .PullFilter(
                post => post.Comments,
                comment => comment.Id == commentId
            );
        UpdateResult result = await _postsCollection
            .UpdateOneAsync(
                Builders<PostDocument>.Filter.Eq(post => post.Id, postId),
                changes
            );

        return result.IsAcknowledged && result.ModifiedCount == 1;
    }

    public async Task<Post> SavePostAsync(Post post)
    {
        PostDocument postDocument = new PostDocument
        {
            Id = Guid.NewGuid().ToString(),
            Comments = new List<CommentDocument>(),
            Content = post.Content,
            Likes = 0
        };
        await _postsCollection.InsertOneAsync(postDocument);

        return postDocument.AsEntity();
    }

    public async Task<Post> Update(string id, Post changes)
    {
        UpdateDefinition<PostDocument> documentChanges = Builders<PostDocument>
            .Update
            .Set(post => post.Content, changes.Content)
            .Set(post => post.Likes, changes.Likes);

        UpdateResult result = await _postsCollection
            .UpdateOneAsync(
                Builders<PostDocument>.Filter.Eq(post => post.Id, id),
                documentChanges
            );

        return await FindPostById(id);
    }
}