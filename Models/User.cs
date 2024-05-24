public class User{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public DateTime DateRegistered { get; set; }
    public string ProfileImage { get; set; }
}

public class RenderedUser : User{
    public bool ShowEdit { get; set; } = false;
    public bool ShowProfileCard { get; set; } = false;

    public void toggleEditMode(){
        ShowEdit = !ShowEdit;
    }

    public void DisplayProfileCard(){
        ShowProfileCard = true;
    }

    public void HideProfileCard(){
        ShowProfileCard = false;
    }
}
