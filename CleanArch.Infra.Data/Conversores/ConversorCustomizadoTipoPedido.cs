using CleanArch.Domain.Models.Enumeradores;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace CleanArch.Infra.Data.Conversores
{
    public class ConversorCustomizadoTipoPedido : ValueConverter<TipoPedido, string>
    {
        public ConversorCustomizadoTipoPedido() : base(
            p => ConverterParaOhBancoDeDados(p),
            value => ConverterParaAplicacao(value),
            new ConverterMappingHints(1))
        {

        }

        static string ConverterParaOhBancoDeDados(TipoPedido enumerador)
        {
            return enumerador.ToString()[0..1];
        }

        static TipoPedido ConverterParaAplicacao(string value)
        {
            var status = Enum.GetValues<TipoPedido>().FirstOrDefault(p => p.ToString()[0..1] == value);

            return status;
        }

    }
}