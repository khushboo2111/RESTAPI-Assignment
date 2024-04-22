using System;
using System.Collections.Generic;

namespace SocialMediaAPI.Models
{
    public static class SampleCommentData
    {
        public static List<Comment> GenerateSampleComments(List<Account> accounts)
        {
            var comments = new List<Comment>();
            //{
            //    new Comment
            //    {
            //        //CommentId = 1,
            //        Title = "Great post!",
            //        Content = "This is an amazing post. Keep up the good work!",
            //        CreatedOn = DateTime.Parse("2023-01-20"),
            //        AccountId = accounts[0].AccountId,
            //        Account = accounts[0],
                   
            //    },
            //    new Comment
            //    {
            //        //CommentId = 2,
            //        Title = "Interesting perspective",
            //        Content = "I never thought about it that way. Thanks for sharing!",
            //        CreatedOn = DateTime.Parse("2023-02-05"),
            //        AccountId = accounts[1].AccountId,
            //        Account = accounts[1]
            //    },
            //    new Comment
            //    {
            //        //CommentId = 3,
            //        Title = "Looking forward to more",
            //        Content = "Can't wait to see what you post next!",
            //        CreatedOn = DateTime.Parse("2023-03-10"),
            //        AccountId = accounts[2].AccountId,
            //        Account = accounts[2]
            //    }
            //};

            return comments;
        }
    }
}
