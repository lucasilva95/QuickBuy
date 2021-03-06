﻿using QuickBuy.Domain.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Domain.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        public virtual Usuario Usuario { get; set; }

        /// <summary>
        /// Pedido deve ter pelo menos um item de pedido
        /// ou muitos itens de pedidos
        /// </summary>
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (!ItensPedido.Any())
                AdicionarCritica("Pedido não pode ficar sem item de pedido.");

            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("CEP deve estar preenchido.");

            if (string.IsNullOrEmpty(Cidade))
                AdicionarCritica("Cidade deve estar preenchida.");

            if (string.IsNullOrEmpty(EnderecoCompleto))
                AdicionarCritica("Endereço deve estar preenchida.");

            if (FormaPagamentoId == 0)
                AdicionarCritica("Não foi informado a forma de pagamento.");
        }
    }
}
