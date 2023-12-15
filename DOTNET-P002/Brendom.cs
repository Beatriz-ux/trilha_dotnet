using System.Text;

public static class Brendom
{
    public static string Name => "Brendom Gonçalves";
    public static List<(string, int)> Skills => new List<(string, int)>{
            ("C#", 5),
            ("Git - Controle de Versão", 5),
            ("GitHub", 5),
            ("Fundamentos de banco de dados", 4),
            ("MySQL", 4),
            ("Estrutura de dados e algoritmos", 4),
            ("Stored Procedures - SQL", 3),
            (".NET", 3),
            ("Habilidades gerais de desenvolvimento", 3),
            ("HTTP / HTTPS", 3),
            ("MVC", 2),
            ("ASP.NET", 2)
            ("SQL Server", 2),
            ("MongoDB", 2),
            ("Selenium", 0),
         };
    public static string View()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Nome: {Name}");
        sb.AppendLine();
        sb.AppendLine("Habilidades:");
        foreach (var skill in Skills)
        {
            sb.AppendLine($"\t{skill.Item1} - {skill.Item2} estrelas");
        }
        var sum = Skills.Sum(x => x.Item2);
        sb.AppendLine();
        sb.AppendLine($"Total de estrelas: {sum}");
        return sb.ToString();
    }
}