using System.Collections.Generic;

namespace QuickBuy.Domain.Entidades
{
    public class Usuario : Entidade
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }

        /// <summary>
        /// Um Usuario pode ter nenhum ou muitos Pedidos
        /// </summary>
        public ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrEmpty(Email))
                AdicionarCritica("E-mail não informado.");

            if (string.IsNullOrEmpty(Senha))
                AdicionarCritica("Senha não informada.");

            if (string.IsNullOrEmpty(Nome))
                AdicionarCritica("Nome não informado.");

            if (string.IsNullOrEmpty(SobreNome))
                AdicionarCritica("Sobrenome não informado");
        }
    }
}
