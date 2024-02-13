using System;
using System.Drawing;

namespace CleanArch.Domain.Models
{
    public sealed class Servico : Entidade
    {
        public Servico()
        {
            
        }

        public Servico(string nome, string descricao, string duracao, decimal valor, string listaHorarioDisponivel, string listaHorarioAgendado, string listaHorarioAtendimento)
        {
            Nome = nome;
            Descricao = descricao;
            Duracao = duracao;
            Valor = valor;
            ListaHorarioDisponivel = listaHorarioDisponivel;
            ListaHorarioAgendado = listaHorarioAgendado;
            ListaHorarioAtendimento = listaHorarioAtendimento;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Duracao { get; private set; }
        public decimal Valor { get; private set; }
        public byte[] Imagen { get; private set; }
        public string ListaHorarioDisponivel { get; private set; }
        public string ListaHorarioAgendado { get; private set; }
        public string ListaHorarioAtendimento { get; private set; }
        public bool Ativo { get; private set; }
        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;
    }
}
