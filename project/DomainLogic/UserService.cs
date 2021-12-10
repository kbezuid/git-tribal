public class UserService {
  private readonly UserRepository _repository;

  public UserService(UserRepository repository) {
    _repository = repository;
  }

  public User GetByImmutableId(string immutableId) {
    return _repository.GetByImmutableId(immutableId);
  }
}