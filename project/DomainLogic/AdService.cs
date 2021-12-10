public class AdService {
  public User GetByImmutableId(string immutableId) {
    var filter = LdapFiler.ImmutableId(immutableId);
    return Search<User>(filter);
  }
}