namespace GamerSchool.Web.ViewModels.Comment
{
    using System;
    using AutoMapper;
    using GamerSchool.Data.Models;
    using GamerSchool.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        public int EntityId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(r => r.UserName, opts => opts.MapFrom(x => x.User.UserName));
        }
    }
}
