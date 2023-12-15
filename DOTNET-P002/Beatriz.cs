using System.Text;
namespace DOTNET_P002;


public static class Beatriz
{
    public static string Name => "Beatriz Pereira";
    public static List<(string,int)> Skills => new List<(string, int)>
    {
        ("Learn the basics of c#", 4),
        ("General development skills", 4),
        ("Database design basics", 3),
        ("ASP.NET Core Basics", 2)

    };
    public static string View(){
        /* StringBuilder é que ele permite que você concatene strings sem a necessidade de criar uma nova 
        string a cada vez que uma concatenação é feita. Em vez disso, ele modifica o conteúdo da string interna, 
        tornando-o mais eficiente em termos 
        de uso de memória e desempenho em comparação com a concatenação tradicional usando o operador +.*/
        var sb = new StringBuilder();
        sb.AppendLine($"Nome: {Name}");
        sb.AppendLine();
        sb.AppendLine($"Habilidades:");
        foreach (var (skill, level) in Skills)
        {
            sb.AppendLine($"- {skill} ({level})");
        }
        var sum = Skills.Sum(x => x.Item2);
        sb.AppendLine();
        sb.AppendLine($"Total de estrelas: {sum}");
        return sb.ToString();

    }



}
