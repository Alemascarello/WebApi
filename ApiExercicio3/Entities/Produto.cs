namespace ApiExercicio3.Entities
{
    public class Produto
    {
        public Produto(string pNome, string pDescricao, decimal pValor)
        {
            Descricao = pDescricao;
            Nome = pNome;
            Valor = pValor;
        }

        public string Descricao { get; set; }
        public int Id { get; init; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}