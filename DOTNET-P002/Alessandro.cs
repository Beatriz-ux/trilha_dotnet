using System.Text;

public static class Alessandro
{
    public static string Name => "Alessandro C. Santos";
    public static List<(string, int)> Skills => new List<(string, int)>{
            ("C#", 3),
            ("Git - Controle de Versão", 5),
            ("GitHub", 5),
            ("Fundamentos de banco de dados", 5),
            ("MySQL", 5),
            ("Postgres", 5),
            ("MongoDB", 3),
            ("Estrutura de dados e algoritmos", 5),
            ("Stored Procedures - SQL", 4),
            (".NET", 3),
            ("Habilidades gerais de desenvolvimento", 5),
            ("HTTP / HTTPS", 5),
            ("MVC", 4),
            ("ASP.NET", 1),
            ("SQL Server", 4),
            ("MongoDB", 1),
            ("PHP", 4),
            ("JAVA", 5),
            ("NODEJS", 5),
            ("Blockchain", 3),
            ("Redes", 3)
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