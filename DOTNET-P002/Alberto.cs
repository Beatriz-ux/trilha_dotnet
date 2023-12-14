using System.Text;

namespace DOTNET_P002
{
    public static class Alberto{
        public static string Name => "Alberto Henrique";
        public static List<(string, int)> Skills => new List<(string, int)>{
            ("Learn the basics of c#", 5),
            ("General development Skills", 4),
            ("Database fundamentals", 4)
        }

        public static string View(){
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine();
            sb.AppendLine("Habilidades:");
            foreach(var skill in Skills){
                sb.AppendLine($"- {skill.Item1} ({skill.Item2}%)");
            }
            var sum = Skills.Sum(x => x.Item2);
            sb.AppendLine();
            sb.AppendLine($"Total de estrelas: {sum}");
            return sb.ToString();
        }
    }
}