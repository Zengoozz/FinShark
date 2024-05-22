
using api.Dtos.Comment;
using api.Models;

namespace api.Mapper
{
    public static class CommentMapper
    {
        public static CommentDto ToDto(this Comment entity)
        {
            return new CommentDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                CreatedOn = entity.CreatedOn,
                StockId = entity.StockId
            };
        }
    }
}