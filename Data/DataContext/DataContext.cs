using Lagalt;
using lagaltApp;
using Microsoft.EntityFrameworkCore;

namespace lagalt
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<PhotoModel> Photos { get; set; }
    public DbSet<SearchWordModel> searchWords { get; set; }

    public DbSet<ProjectModel> Projects { get; set; }
    public DbSet<ProjectUserModel> ProjectUsers { get; set; }

    public DbSet<MessageBoardModel> MessageBoards { get; set; }
    public DbSet<ProjectImageModel> projectImages { get; set; }
    public DbSet<IndustryModel> Industries { get; set; }
    public DbSet<TagModel> Tags { get; set; }
    public DbSet<ChatModel> Chats { get; set; }
    public DbSet<ChatMessageModel> ChatMessages { get; set; }
    public DbSet<SkillModel> skills { get; set; }

    public DbSet<ClickedProjectHistoryModel> ClickedProjectHistories { get; set; }
    public DbSet<AppliedProjectHistoryModel> AppliedProjectHistories { get; set; }
    public DbSet<UserInWaitingListModel> UsersInWaitingLists { get; set; }
    public DbSet<SearchWordModel> SearchWords { get; set; }
    public DbSet<WaitListModel> WaitLists { get; set; }

  }
}