using System.Text;

namespace Domain
{
    public static class Beatriz
    {
        public static string Name => "Beatriz Pereira";
        public static List<(string,int)> Skills => new List<(string, int)>
        {
            ("C#", 3),
            ("Git - Controle de Versão", 5),
            ("GitHub", 5),
            ("Fundamentos de banco de dados", 4),
            ("MySQL", 4),
            ("Postgres", 3),
            ("MongoDB", 0),
            ("Estrutura de dados e algoritmos", 2),
            ("Stored Procedures - SQL", 4),
            (".NET", 3),
            ("Habilidades gerais de desenvolvimento", 5),
            ("HTTP / HTTPS", 3),
            ("MVC", 3),
            ("ASP.NET", 1),
            ("SQL Server", 4),
            ("MongoDB", 0),
            ("MariaDB", 1),
            ("PHP", 3),
            ("JAVA", 3),
            ("NODEJS", 5),
            ("Blockchain", 1),
            ("Redes", 3)

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
}
