using CleanArch.Domain.Models.Enumeradores;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace CleanArch.Infra.Data.Conversores
{
    public class ConversorCustomizadoTipoPessoa : ValueConverter<TipoPessoa, string>
    {
        public ConversorCustomizadoTipoPessoa() : base(
            p => ConverterParaOhBancoDeDados(p),
            value => ConverterParaAplicacao(value),
            new ConverterMappingHints(1))
        {

        }

        static string ConverterParaOhBancoDeDados(TipoPessoa enumerador)
        {
            return enumerador.ToString()[0..1];
        }

        static TipoPessoa ConverterParaAplicacao(string value)
        {
            var tipo = Enum.GetValues<TipoPessoa>().FirstOrDefault(p => p.ToString()[0..1] == value);

            return tipo;
        }

    }
}