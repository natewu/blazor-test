namespace blazor.Services;

public class UserService : IUserService{
    private readonly IDbService _db;
    
    public UserService(IDbService db){
        _db = db;
    }

    public async Task<bool> CreateUser(User user){
        var result = await _db.Insert<int>("INSERT INTO public.users(username, email, password) VALUES (@Username, @Email, @Password)", user);
        return true;
    }

    public async Task<List<User>> GetUsers(){
        var users = await _db.GetAll<User>("SELECT * FROM public.users", new {});
        return users;
    }

    public async Task<User> UpdateUser(User user){
        var update = await _db.Update<int>("UPDATE public.users SET username=@Username, email=@Email, password=@Password", user);
        return user;
    }

    public async Task<bool> DeleteUser(int key){
        var delete = await _db.Delete<int>("DELETE FROM public.users WHERE id=@Id", new {Id = key});
        return true;
    }
}