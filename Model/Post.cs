﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Model
{
    public class Post
    {
        

        public int Id { get; set; }

        public string content { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

        public int LikesCount { get; set; } = 0;

        public int RepliesCount { get; set; } = 0;

        public int BookmarksCount { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();

        public List<Comment> comments { get; set; } = new List<Comment>();

        public List<Like> likes { get; set; } = new List<Like>();

        public List<Bookmark> bookmarks { get; set; } = new List<Bookmark>();



    }
}
