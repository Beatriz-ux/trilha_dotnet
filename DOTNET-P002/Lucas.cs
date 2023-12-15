using System.Text;

public static class Lucas
{
    public static string Name => "Lucas Silva";
    public static List<(string, int)> Skills => new List<(string, int)>{
            ("C#", 3),
            ("Git - Controle de Versão", 5),
            ("GitHub", 5),
            ("Github Actions", 2),
            ("Fundamentos de banco de dados", 4),
            ("MySQL", 4),
            ("Estrutura de dados e algoritmos", 4),
            ("Stored Procedures - SQL", 3),
            (".NET", 3),
            ("Habilidades gerais de desenvolvimento", 4),
            ("HTTP / HTTPS", 3),
            ("MVC", 3),
            ("ASP.NET", 1),
            ("SQL Server", 2),
            ("MongoDB", 1),
            ("Selenium", 4),
            ("Selenium", 4),
            ("Cypress", 4),
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