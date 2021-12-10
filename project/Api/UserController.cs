[ApiController]
[Router("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly UserService _userService;
  private readonly UserSyncService _userSyncService;

  public UserController(UserService userService, UserSyncService userSyncService) {
    _userService = userService;
    _userSyncService = userSyncService;
  }


  [HttpGet]
  public ActionResult<User> Get([Required] [FromQuery] string immutableId) {
    var user = _userService.GetByImmutableId(immutableId);

    if( user == null) {
      return NotFound();
    }

    return Ok(user);
  }

  [HttpPut("Sync")]
  public ActionResult Sync([Required][FromQuery] string immutableId) {
    _userSyncService.Sync(immutableId);

    return Ok();
  }
}