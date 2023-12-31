using Lagalt;
using lagaltApp;

namespace lagalt
{
  public class UserDto
  {
    public int Id { get; set; }
    public bool IsPrivate { get; set; }
    public string Username { get; set; }
    public string CareerTitle { get; set; }


    public string PhotoUrl { get; set; }
    public string Email { get; set; }

    public string Portfolio { get; set; }

    public string Description { get; set; }


    // public List<SearchWordModel> SearchWords { get; set; } = new();


    public List<ProjectUserWithoutUserDataDto> ProjectUsers { get; set; }
    public List<SkillDto> Skills { get; set; } = new();

    public List<UserInWaitingListDto> userInWaitingLists { get; set; }

    //WIP 
    public List<AppliedProjectHistoryDto> AppliedProjectHistories { get; set; } = new();
    public List<ClickedProjectHistoryDto> ClickedProjectHistories { get; set; } = new();
    public List<SearchWordDto> SearchWords { get; set; } = new();


  }
}