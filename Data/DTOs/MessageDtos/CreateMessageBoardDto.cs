namespace Lagalt
{
  public class CreateMessageBoardDto
  {
    // public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    //if doesnt work create another table for messages
    public int ProjectId { get; set; }
  }
}