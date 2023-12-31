using System.Text.Json.Serialization;

namespace Lagalt
{
  public class UserInWaitingListDto
  {
    public int Id { get; set; }
    [JsonIgnore]
    public int ProjectId { get; set; }

    public int UserId { get; set; }
    public string Username { get; set; }
    //false
    public bool? PendingStatus { get; set; }
    public string MotivationLetter { get; set; }
    //id we want to accept


    // [JsonIgnore]
    // public int? WaitListId { get; set; }
    // public WaitListModel WaitList { get; set; }
  }
}