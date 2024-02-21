using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Comments;
using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Mappings;
public class CommentsProfile : Profile
{
    public CommentsProfile()
    {
        CreateMap<AddCommentRequest, Comment>()
            .ForMember(a => a.AuthorName, y => y.MapFrom(b => b.AuthorName))
            .ForMember(a => a.Body, y => y.MapFrom(b => b.Body))
            .ForMember(a => a.GameAlias, y => y.MapFrom(b => b.GameAlias))
            .ForMember(dest => dest.AsReplyToCommentId, opt => opt.MapFrom(src => src.AsReplyTo))
            .ForMember(dest => dest.AsQuoteToCommentId, opt => opt.MapFrom(src => src.AsQuoteTo))
            .ForMember(a => a.UserId, y => y.MapFrom(b => b.UserId));

        CreateMap<Comment, CommentListingModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.AuthorName))
            .ForMember(dest => dest.AsReplyTo, opt => opt.MapFrom(src => src.AsReplyToCommentId))
            .ForMember(dest => dest.AsQuoteTo, opt => opt.MapFrom(src => src.AsQuoteToCommentId))
            .ForMember(dst => dst.BanUntil, opt => opt.MapFrom(src => src.BanUntil))
            .ForMember(dest => dest.CanBeDeletedByUser, opt => opt.Ignore())
            .AfterMap((src, dest, context) =>
            {
                var cookieId = context.Items["UserId"] as string;
                if (src.UserId == cookieId)
                {
                    dest.CanBeDeletedByUser = true;
                }
            });
    }
}
