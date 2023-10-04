using CleanArch.Domain.Models.Enumeradores;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace CleanArch.Infra.Data.Conversores
{
    public class ConversorCustomizadoPedidoStatus : ValueConverter<PedidoStatus, string>
    {
        public ConversorCustomizadoPedidoStatus() : base(
            p => ConverterParaOhBancoDeDados(p),
            value => ConverterParaAplicacao(value),
            new ConverterMappingHints(1))
        {

        }

        static string ConverterParaOhBancoDeDados(PedidoStatus enumerador)
        {
            return enumerador.ToString()[0..1];
        }

        static PedidoStatus ConverterParaAplicacao(string value)
        {
            var status = Enum.GetValues<PedidoStatus>().FirstOrDefault(p => p.ToString()[0..1] == value);

            return status;
        }

    }
}