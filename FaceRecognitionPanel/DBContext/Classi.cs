namespace DBContext;

public class Classi
{
    public int Id { get; set; }
    public string Sezione { get; set; }
    public virtual List<Utenti> utentis { get; set; }
}