using System.Net.Security;
using AutoMapper;
using Lagalt;
using lagaltApp;
using Microsoft.AspNetCore.DataProtection;

namespace lagalt
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      //login
      CreateMap<UserModel, RegisterAppUserDto>()
      .ForMember(dest => dest.KeycloakId, opt => opt.MapFrom(src => src.KeyCloakId));
      CreateMap<RegisterAppUserDto, UserModel>();
      CreateMap<UserModel, LoginDto>().ReverseMap();
      //user misc


      // .ForMember(dest => dest.ProjectUsers, opt => opt.MapFrom(src => src.ProjectUsers))
      // .ForMember(dest => dest.userInWaitingLists, opt => opt.MapFrom(src => src.UsersInWaitingLists));
      CreateMap<UserModel, PatchUserStatusDto>()
      .ForMember(dest => dest.IsPrivate, opt => opt.MapFrom(src => src.IsPrivate));
      CreateMap<PatchUserStatusDto, UserModel>()
      .ForMember(dest => dest.IsPrivate, opt => opt.MapFrom(src => src.IsPrivate));

      CreateMap<UserDto, UserModel>()
      .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.PhotoUrl))
      .ForMember(dest => dest.SearchWords, opt => opt.Ignore())
      .ForMember(dest => dest.AppliedProjectHistories, opt => opt.MapFrom(src => src.AppliedProjectHistories))
      .ForMember(dest => dest.ClickedProjectHistories, opt => opt.MapFrom(src => src.ClickedProjectHistories))
      .ForMember(dest => dest.SearchWords, opt => opt.MapFrom(src => src.SearchWords));
      CreateMap<UserModel, UserDto>()
      .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photo))
      .ForMember(dest => dest.AppliedProjectHistories, opt => opt.MapFrom(src => src.AppliedProjectHistories))
      .ForMember(dest => dest.ClickedProjectHistories, opt => opt.MapFrom(src => src.ClickedProjectHistories))
      .ForMember(dest => dest.SearchWords, opt => opt.MapFrom(src => src.SearchWords));


      CreateMap<PatchUserHistoryDto, ClickedProjectHistoryModel>()
      .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Id));



      CreateMap<ClickedProjectHistoryModel, PatchUserHistoryDto>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProjectId));


      CreateMap<List<UserModel>, UserDto>().ReverseMap();
      CreateMap<UserModel, UserNameDto>().ReverseMap();
      CreateMap<UserDto, UserNameDto>().ReverseMap();
      CreateMap<ProjectUserModel, List<ProjectDto>>();

      CreateMap<ProjectModel, List<ProjectUserModel>>().ReverseMap();
      CreateMap<UpdateAppUserDto, UserDto>()
      .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl));
      CreateMap<UserDto, UpdateAppUserDto>()
      .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl));

      //skills
      CreateMap<SkillModel, SkillDto>().ReverseMap();
      CreateMap<SkillModel, SkillNameDto>().ReverseMap();
      CreateMap<List<SkillDto>, SkillModel>().ReverseMap();
      CreateMap<SkillDto, SkillNameDto>().ReverseMap();
      CreateMap<UpdateProjectDetailsDto, ProjectModel>()
      .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagNames))
      .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.SkillNames))
      .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry));
      CreateMap<ProjectModel, UpdateProjectDetailsDto>();

      CreateMap<ProjectDto, UpdateProjectDetailsDto>()
      .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry))
      .ForMember(dest => dest.TagNames, opt => opt.MapFrom(src => src.Tags))
      .ForMember(dest => dest.SkillNames, opt => opt.MapFrom(src => src.Skills));
      CreateMap<UpdateProjectDetailsDto, ProjectDto>()
     .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry))
      .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagNames))
      .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.SkillNames));

      //project image 
      CreateMap<ProjectImageDto, ProjectImageModel>();
      CreateMap<ProjectImageModel, ProjectImageDto>();

      //project
      CreateMap<ProjectModel, ProjectDto>()
      .ForMember(dest => dest.WaitList, opt => opt.MapFrom(src => src.WaitList))
      .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
      .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
      .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry));

      CreateMap<ProjectDto, ProjectModel>()
      .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
      .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
      .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry));

      CreateMap<ProjectUserModel, ProjectUserWithoutUserDataDto>()
      .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Project.Title));


      //Project list
      CreateMap<ProjectModel, ProjectListDto>().ReverseMap();



      CreateMap<ProjectSkillListDto, SkillModel>().ReverseMap()
      .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.SkillName));

      CreateMap<ProjectUserModel, ProjectListUserDto>()
      .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username));


      CreateMap<ProjectListUserDto, UserModel>().ReverseMap()
      .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username));


      CreateMap<SkillNameDto, SkillModel>().ReverseMap();


      CreateMap<ProjectModel, CreateProjectDto>().ReverseMap();

      CreateMap<CreateProjectDto, ProjectModel>();


      CreateMap<ProjectDto, CreateProjectDto>().ReverseMap();

      //project userr get users projects for profile page

      CreateMap<ProjectUserModel, ProjectUserDto>();
      CreateMap<ProjectUserDto, ProjectUserModel>();

      CreateMap<UserModel, ProjectUserDto>()
      .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));


      CreateMap<UserModel, ProjectUserModel>()
      .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.Id, opt => opt.Ignore());

      //update project details
      CreateMap<UpdateProjectDetailsDto, ProjectModel>()
      .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagNames))
      .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.SkillNames))
      .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry))
      .ForMember(dest => dest.projectImage, opt => opt.MapFrom(src => src.ProjectImage));

      CreateMap<TagNameDto, TagModel>()
      .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.TagName));
      CreateMap<TagModel, TagNameDto>()
      .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.TagName));

      CreateMap<SkillNameDto, SkillModel>()
      .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.SkillName));
      CreateMap<SkillModel, SkillNameDto>()
      .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.SkillName));

      CreateMap<IndustryNameDto, IndustryModel>()
      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.IndustryName));
      CreateMap<IndustryModel, IndustryNameDto>()
      .ForMember(dest => dest.IndustryName, opt => opt.MapFrom(src => src.Name));


      //Industry
      CreateMap<IndustryModel, IndustryDto>().ReverseMap();
      CreateMap<IndustryModel, IndustryNameDto>().ReverseMap();
      CreateMap<IndustryDto, IndustryNameDto>().ReverseMap();

      CreateMap<IndustryNameDto, IndustryModel>()
      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.IndustryName));
      CreateMap<IndustryModel, UpdateProjectDetailsDto>().ReverseMap();
      // .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Industry.IndustryName));


      CreateMap<IndustryModel, IndustryNameDto>()
      .ForMember(dest => dest.IndustryName, opt => opt.MapFrom(src => src.Name));

      //tags
      CreateMap<TagModel, TagDto>().ReverseMap();

      CreateMap<TagModel, TagNameDto>().ReverseMap();
      CreateMap<TagDto, TagNameDto>().ReverseMap();
      CreateMap<TagNameDto, TagModel>().ReverseMap()
      .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.TagName));

      //userinwaitinglist
      CreateMap<UserInWaitingListDto, ProjectUserModel>();



      CreateMap<UserModel, UserInWaitingListModel>()
    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
     .ForMember(dest => dest.Id, opt => opt.Ignore());


      CreateMap<UserInWaitingListModel, UserModel>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
      //  .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
      CreateMap<UserInWaitingListDto, UserModel>()
     .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

      CreateMap<WaitListModel, UserInWaitingListModel>()
      .ForMember(dest => dest.WaitListId, opt => opt.MapFrom(src => src.Id));


      CreateMap<UserInWaitingListModel, ProjectModel>();
      //  .ForMember(dest => dest, opt => opt.Ignore());
      //  .ForMember(dest => dest., opt => opt.MapFrom(src => src.Id))

      CreateMap<UserModel, UserInWaitingListModel>()
      .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.PendingStatus, opt => opt.Ignore());

      CreateMap<ApplyProjectDto, UserInWaitingListModel>();
      CreateMap<ApplyProjectDto, UserInWaitingListDto>();

      //update user
      CreateMap<UserModel, UpdateAppUserDto>();
      CreateMap<UpdateAppUserDto, UserModel>();


      CreateMap<WaitListModel, UserModel>().ReverseMap();
      CreateMap<WaitListModel, ProjectModel>().ReverseMap();
      CreateMap<ProjectModel, ProjectDto>().ReverseMap();
      CreateMap<ProjectDto, WaitListModel>().ReverseMap();
      CreateMap<ProjectDto, WaitListDto>().ReverseMap();
      CreateMap<WaitListModel, WaitListDto>();

      CreateMap<UserInWaitingListModel, UserInWaitingListDto>()
      .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));
      CreateMap<UserInWaitingListDto, UserInWaitingListModel>();

      CreateMap<UserModel, UserInWaitingListDto>()
      .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

      CreateMap<WaitListModel, UserInWaitingListModel>().ReverseMap();

      //message board 
      CreateMap<MessageBoardModel, MessageBoardDto>()
      .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
      .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
      .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

      CreateMap<MessageBoardDto, MessageBoardModel>();
      CreateMap<UserModel, MessageBoardDto>()
      .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));


      CreateMap<MessageBoardModel, CreateMessageBoardDto>();
      CreateMap<CreateMessageBoardDto, MessageBoardModel>();

      CreateMap<UpdateMessageBoardDto, MessageBoardModel>();
      CreateMap<MessageBoardModel, UpdateMessageBoardDto>()
      .ForMember(dest => dest.messageboardId, opt => opt.MapFrom(src => src.Id));

      //message board list
      CreateMap<MessageBoardModel, MessageBoardListDto>();
      CreateMap<MessageBoardListDto, MessageBoardModel>();

      //photo
      CreateMap<PhotoModel, PhotoDto>();


      //histories 
      CreateMap<AppliedProjectHistoryDto, AppliedProjectHistoryModel>()
      .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId));

      CreateMap<AppliedProjectHistoryModel, AppliedProjectHistoryDto>()
.ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId));

      CreateMap<ClickedProjectHistoryModel, ClickedProjectHistoryDto>()
      .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId));
      CreateMap<ClickedProjectHistoryDto, ClickedProjectHistoryModel>()
.ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId));

      CreateMap<SearchWordModel, SearchWordDto>();

      CreateMap<SearchWordDto, SearchWordModel>();




      // AppliedProjectHistories = updateAppUser.AppliedProjectHistories == null ? _mapper.Map<List<AppliedProjectHistoryDto>>(IsUser.AppliedProjectHistories) : updateAppUser.AppliedProjectHistories,
      //   ClickedProjectHistories = updateAppUser.ClickedProjectHistories == null ? _mapper.Map<List<ClickedProjectHistoryDto>>(IsUser.AppliedProjectHistories) : updateAppUser.ClickedProjectHistories,
      //   SearchWords = updateAppUser.SearchWords == null ? _mapper.Map<List<SearchWordDto>>(IsUser.SearchWords) : updateAppUser.SearchWords


    }
  }
}