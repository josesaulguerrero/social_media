using System.Collections.Generic;

namespace Domain.Model.Entities;

public class Post
{
    public string Id;
    public string Content;
    public long Likes;
    public IList<Comment> Comments;
}