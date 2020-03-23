namespace QuickBuy.Domain.Entidades
{
    public class Produto : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrEmpty(Nome))
                AdicionarCritica("Nome do produto não informado.");

            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Descrição do produto não informada.");

            if (Preco <= 0)
                AdicionarCritica("Preço inválido.");
        }
    }
}
