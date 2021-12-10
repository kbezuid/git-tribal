public class UserSyncService {
  private readonly UserService _userService;
  private readonly AdService _adService;

  public UserSyncService(UserService userService, AdService adService) {
    _userService = userService;
    _adService = adService;
  }

  void Sync(string immutableId) {
    var dbUser = _userService.GetByImmutableId(immutableId);
    var adUser = _adService.GetByImmutableId(immutableId);

    dbUser.Name = adUser.Name;
    dbUser.LastName = adUser.LastName;
    dbUser.Email = adUser.Email;

    _userService.Update(dbUser);
  }
}