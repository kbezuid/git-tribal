public class UserRepository {
  public User GetByImmutableId(string immutableId) {
    var cmd = _dataProvider.CreateStoredProcedureCommand("[User].[UserGetByImmutableId]");
    cmd.AddInParameter("@ImmutableId", DbType.String, immutableId);
    return cmd.ReadSingle<User>();
  }
}