using Microsoft.Extensions.Hosting;
using Twitter.DTOs.BookmarkDtos;
using Twitter.Model;

namespace Twitter.Mappers
{
    public static class BookmarkMapper
    {
        public static BookmarkDto toDto(this Bookmark bookmark)
        {
            BookmarkDto dto = new();

            dto.Id = bookmark.Id;
            dto.AuthorId = bookmark.User.Id;
            dto.Author = bookmark.User.FirstName + " " + bookmark.User.LastName;
            dto.CreatedAt = bookmark.BookmarkedAt;
            dto.ImgUrl = bookmark.Post.ImgUrl;
            dto.CommentsCount = bookmark.Post.BookmarksCount;
            dto.LikesCount = bookmark.Post.LikesCount;
            dto.BookmarksCount = bookmark.Post.BookmarksCount;

            foreach (Comment comment in bookmark.Post.comments)
                dto.Comments.Add(comment.toDto());

            return dto;
        }
    }
}
