using System.ComponentModel;
using AutoMapper;
using lagalt;
using lagaltApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lagalt
{
  public class AppUserRepository : IAppUserRepository
  {
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public AppUserRepository(DataContext dataContext, IMapper mapper)
    {
      _mapper = mapper;
      _dataContext = dataContext;
    }

    public async Task<ActionResult> GetUserAsync(int id)
    {
      var IsUser = await _dataContext.Users.
      Include(p => p.ProjectUsers).
      ThenInclude(u => u.Project)
      .Include(s => s.Skills)
      .Include(w => w.UsersInWaitingLists)
      .Include(c => c.ClickedProjectHistories)
      .Include(a => a.AppliedProjectHistories)
      .Include(sw => sw.SearchWords).FirstOrDefaultAsync(u => u.Id == id);

      if (IsUser == null) return new BadRequestObjectResult("Incorrect Id");

      return new OkObjectResult(_mapper.Map<UserDto>(IsUser));
    }

    public async Task<ActionResult<UserDto>> UpdateUserAsync(int id, UpdateAppUserDto updateAppUser)
    {
      var IsUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);

      if (IsUser == null) return new BadRequestObjectResult("Incorrect Id");

      var updateInformation = new UserDto
      {
        Id = IsUser.Id,
        Username = updateAppUser.Username == null ? IsUser.Username : updateAppUser.Username,
        CareerTitle = updateAppUser.CareerTitle == null ? IsUser.CareerTitle : updateAppUser.CareerTitle,
        Description = updateAppUser.Description == null ? IsUser.Description : updateAppUser.Description,
        Portfolio = updateAppUser.Portfolio == null ? IsUser.Portfolio : updateAppUser.Portfolio,
        Email = updateAppUser.Email == null ? IsUser.Email : updateAppUser.Email,
        Skills = updateAppUser.Skills == null ? _mapper.Map<List<SkillDto>>(IsUser.Skills) : updateAppUser.Skills,
        AppliedProjectHistories = updateAppUser.AppliedProjectHistories == null ? _mapper.Map<List<AppliedProjectHistoryDto>>(IsUser.AppliedProjectHistories) : updateAppUser.AppliedProjectHistories,
        ClickedProjectHistories = updateAppUser.ClickedProjectHistories == null ? _mapper.Map<List<ClickedProjectHistoryDto>>(IsUser.AppliedProjectHistories) : updateAppUser.ClickedProjectHistories,
        SearchWords = updateAppUser.SearchWords == null ? _mapper.Map<List<SearchWordDto>>(IsUser.SearchWords) : updateAppUser.SearchWords

      };

      _mapper.Map(updateInformation, IsUser);
      _dataContext.Entry(IsUser).State = EntityState.Modified;
      await _dataContext.SaveChangesAsync();

      return new OkResult();
    }

    public async Task<List<ProjectUserDto>> UserAdminProjectsAsync(int id)
    {
      var isUserId = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
      if (isUserId == null)
      {
        throw new Exception("Bad id");
      }

      var ProjectOwnerProjects = await _dataContext.ProjectUsers
      .Include(pu => pu.Project)
      .ThenInclude(p => p.Industry)
      .Include(t => t.Project.Tags)
      .Include(t => t.Project.Skills)
      .Include(m => m.Project.MessageBoards)
      .Where(pu => pu.IsOwner == true && pu.UserId == id).ToListAsync();

      return _mapper.Map<List<ProjectUserDto>>(ProjectOwnerProjects);
    }
    public async Task<List<ProjectUserDto>> UserProjectsAsync(int id)
    {

      //check user id validity
      var isUserId = await _dataContext.ProjectUsers.FindAsync(id);
      if (isUserId == null)
      {
        throw new Exception("Bad id");
      }

      var ProjectOwnerProjects = await _dataContext.ProjectUsers
     .Include(pu => pu.Project)
     .ThenInclude(p => p.Industry)
     .Include(t => t.Project.Tags)
     .Include(t => t.Project.Skills)
     .Where(pu => pu.UserId == id).ToListAsync();

      return _mapper.Map<List<ProjectUserDto>>(ProjectOwnerProjects);
    }
  }
}