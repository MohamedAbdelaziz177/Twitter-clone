﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; } = "";

        [ForeignKey(nameof(Post))]
        public int PostId {  get; set; }
        public Post Post { get; set; } = new Post();

        [ForeignKey(nameof(ApplicationUser))]
        public string? UserId {  get; set; }
        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
    }
}
