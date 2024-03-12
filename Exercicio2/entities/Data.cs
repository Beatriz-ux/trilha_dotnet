namespace Exercicio2.entities;


public class Data
{
    public int Dia { get; private set; }
    public int Mes { get; private set; }
    public int Ano { get; private set; }

    public int Hora { get; private set; }
    public int Minuto { get; private set; }
    public int Segundo { get; private set; }

    public const int FORMATO_12H = 12;
    public const int FORMATO_24H = 24;



    public Data(int dia, int mes, int ano)
    {
        if (!dataValid(dia, mes, ano))
        {
            return;
        }
        Dia = dia;
        Mes = mes;
        Ano = ano;
    }

    public Data(int dia, int mes, int ano, int hora, int minuto, int segundo) : this(dia, mes, ano)
    {
        Hora = hora;
        Minuto = minuto;
        Segundo = segundo;
    }

    public void Imprimir(int formato = 24)
    {
        Console.Write($"{Dia}/{Mes}/{Ano} ");
        if (this.Hora == 0 && this.Minuto == 0 && this.Segundo == 0)
        {
            Console.WriteLine("");
            return;
        }
        if (formato == 12)
        {
            if (Hora > 12)
            {
                Console.Write($"{Hora - 12}:{Minuto}:{Segundo} PM");
            }
            else
            {
                Console.WriteLine($"{Hora}:{Minuto}:{Segundo} AM");
            }
        }
        else
        {
            Console.WriteLine($"{Hora}:{Minuto}:{Segundo}");
        }
        Console.WriteLine("");

    }

    public bool dataValid(int dia, int mes, int ano)
    {
        try
        {
            DateTime data = new DateTime(ano, mes, dia);
            return true;
        }catch(Exception)
        {
            Console.WriteLine("Data inválida!");
            return false;
        }
    }

}
