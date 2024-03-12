namespace Exercicio1.models;

public class Lampada
{
    public bool Ligada { get; private set; }

    public Lampada(bool estadoInicial)
    {
        Ligada = estadoInicial;
    }
    public void Ligar()
    {
        Ligada = true;
    }

    public void Desligar()
    {
        Ligada = false;
    }

    public void Imprimir()
    {
        Console.WriteLine(Ligada ? "LâmpadaLigada" : "Lâmpada Desligada");
    }

}
