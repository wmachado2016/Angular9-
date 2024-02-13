using CleanArch.Domain.Models.Enumeradores;
using CleanArch.Domain.Models.Validations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArch.Domain.Models;

public sealed class Agenda : Entidade
{
    public Agenda(){}

    public Agenda(DateTime dataAgenda, Guid servicoId, Guid clienteId)
    {
        DataAgenda = dataAgenda;
        ServicoId = servicoId;
        ClienteId = clienteId;
    }

    public DateTime DataAgenda { get; private set; }
    public Guid ServicoId { get; private set; }
    public TipoPessoa TipoPessoa { get; private set; }
    public Guid ClienteId { get; private set; }
    public bool Ativo { get; private set; }

    public void Ativar() => Ativo = true;

    public void Desativar() => Ativo = false;


    public override bool EhValido()
    {
        ValidationResult = new AgendaValidacao().Validate(this);
        return ValidationResult.IsValid;
    }
}
