namespace DBContext;

public class Utenti
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int ClassiId { get; set; }
    public virtual Classi Classe { get; set; }
}