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

  public void Update(User user) {
    var cmd = _dataProvider.CreateStoredProcedureCommand("[User].[UserUpdate]");
    cmd.AddInParameter("@Id", DbType.Int32, user.Id);
    cmd.AddInParameter("@Name", DbType.String, user.Name);
    cmd.AddInParameter("@LastName", DbType.String, user.LastName);
    cmd.AddInParameter("@Email", DbType.String, user.Email);
    cmd.ExecuteNonQuery();
  }
}