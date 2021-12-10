[ApiController]
[Router('api/[controller]')]
public class UserController : ControllerBase
{
  private readonly UserService _userService;

  public UserController(UserService userService) {
    _userService = userService;
  }


  [HttpGet]
  public ActionResult<User> Get([Required] [FromQuery] string immutableId) {
    var user = _userService.GetByImmutableId(immutableId);

    if( user == null) {
      return NotFound();
    }

    return Ok(user);
  }
}