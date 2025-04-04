﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Model
{
    public class Post
    {
        public int Id { get; set; }

        public string content { get; set; } = "";

        public string ImgUrl { get; set; } = string.Empty;

        public int LikesCount { get; set; }

        public int RepliesCount { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();

        public List<Comment> comments { get; set; } = new List<Comment>();

        public List<Like> likes { get; set; } = new List<Like>();

        public List<Bookmark> bookmarks { get; set; } = new List<Bookmark>();



    }
}
