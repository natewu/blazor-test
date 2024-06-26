namespace blazor.Services;

public class UserService : IUserService{
    private readonly IDbService _db;
    
    public UserService(IDbService db){
        _db = db;
    }

    public async Task<bool> CreateUser(User user){
        var result = await _db.Insert<int>("INSERT INTO public.users(username, email, password, profile_image) VALUES (@Username, @Email, @Password, @ProfileImage)", user);
        return true;
    }

    public async Task<List<User>> GetUsers(){
        var users = await _db.GetAll<User>("SELECT id, username, email, profile_image FROM public.users", new {});
   
        return users;
    }

    public async Task<User> GetUserProfile(int key){
        var user = await _db.GetAsync<User>("SELECT id, username, email, date_registered, profile_image FROM public.users WHERE id=@Id", new {Id = key});
        Console.WriteLine(user.ProfileImage);
        return user;
    }

    public async Task<User> UpdateUser(User user){
        var update = await _db.Update<int>(
                "UPDATE public.users SET username=@Username, email=@Email WHERE id=@Id", 
                new { user.Username, user.Email, user.Id }
            );
            return user;
    }

    public async Task<bool> DeleteUser(int key){
        var delete = await _db.Delete<int>("DELETE FROM public.users WHERE id=@Id", new {Id = key});
        return true;
    }
}   