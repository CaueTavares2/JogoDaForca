// Palavra.cs
// Representa uma palavra do banco de dados
public class Palavra
{
    // Propriedades da classe
    public int Id { get; set; }
    public string Texto { get; set; }
    // Construtor padrão
    public Palavra() { }
    // Construtor com parâmetros
    public Palavra(int id, string texto)
    {
        Id = id;
        Texto = texto.ToUpper(); // Garantir que a palavra esteja em maiúsculas
    }
}