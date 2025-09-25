// Palavra.cs
// Esta classe modelo representa a estrutura de uma palavra no banco de dados.
// É um exemplo de Programação Orientada a Objetos (POO), onde um objeto "Palavra"
// tem propriedades e um comportamento simples.

public class Palavra
{
    // Propriedades da classe Palavra
    // 'Id' representa o identificador único da palavra no banco de dados.
    public int Id { get; set; }

    // 'Texto' armazena a palavra em si. O 'set' está private para ser manipulado apenas dentro do construtor
    // garantindo que a palavra sempre seja armazenada em maiúsculas.
    public string Texto { get; set; }

    // Construtor vazio (obrigatório para alguns frameworks e serialização)
    public Palavra() { }

    // Construtor principal da classe
    // Recebe o ID e o texto da palavra e atribui às propriedades.
    public Palavra(int id, string texto)
    {
        Id = id;
        // O texto é convertido para maiúsculas para facilitar a comparação das letras durante o jogo.
        Texto = texto.ToUpper();
    }
}
