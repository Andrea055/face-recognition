namespace DBContext;

public class Image
{
    public int ImageId { get; set; }

    public string? ImagePath { get; set; }

    public Utenti FkUser {get; set;} = new();
}
