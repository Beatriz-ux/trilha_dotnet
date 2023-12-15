using System.Text;

namespace Domain
{
    public static class App
    {
        public static string View(){
            var sb = new StringBuilder();
            var membros = new List<(string,int)>(){
                (Beatriz.Name, Beatriz.Skills.Sum(x => x.Item2)),
                (Brendom.Name, Brendom.Skills.Sum(x => x.Item2)),
                (Alberto.Name, Alberto.Skills.Sum(x => x.Item2)),
                (Alessandro.Name, Alessandro.Skills.Sum(x => x.Item2)),
                (Lucas.Name, Lucas.Skills.Sum(x => x.Item2)),
            };
            // Ordenar os membros da equipe em ordem decrescente de estrelas totais
            var membrosOrdenados = membros.OrderByDescending(member => member.Item2);

            sb.AppendLine($"########## RESUMO DA EQUIPE ##########");
            sb.AppendLine();
            foreach (var membro in membrosOrdenados)
            {
                sb.AppendLine($"Nome: {membro.Item1.PadRight(30)} \t Total de estrelas: {membro.Item2.ToString()}");
                sb.AppendLine();
            }

            sb.AppendLine($"Total de estrelas da equipe: {membrosOrdenados.Sum(x => x.Item2)}");
            return sb.ToString();
        }

    }
}
