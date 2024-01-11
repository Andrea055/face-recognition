namespace face_recognition.Shared;

public class Variables{
    public static string Token { get; set; } = "mytoken";   

}


public class immagine{
    public byte[]? content { get; set; }
    public string? name { get; set; }
    public string? user { get; set; }
}

public class request{
    public string? token { get; set; }
    public List<immagine> dataimages { get; set; }
}

public class requestimages{
    public string? token { get; set; }
    public string? user { get; set; }
}



public class file{
    public string? nome_file {get;set;}
}