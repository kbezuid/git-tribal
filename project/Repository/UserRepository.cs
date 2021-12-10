public class UserRepository {
  private readonly IDataProvider _dataProvider;

  public UserRepository(IDataProvider dataProvider) {
    _dataProvider = dataProvider;
  }

  public User GetByImmutableId(string immutableId) {
    var cmd = _dataProvider.CreateStoredProcedureCommand("[User].[UserGetByImmutableId]");
    cmd.AddInParameter("@ImmutableId", DbType.String, immutableId);
    return cmd.ReadSingle<User>();
  }
}