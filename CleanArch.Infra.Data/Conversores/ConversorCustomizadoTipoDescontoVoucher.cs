using CleanArch.Domain.Models.Enumeradores;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace CleanArch.Infra.Data.Conversores
{
    public class ConversorCustomizadoTipoDescontoVoucher : ValueConverter<TipoDescontoVoucher, string>
    {
        public ConversorCustomizadoTipoDescontoVoucher() : base(
            p => ConverterParaOhBancoDeDados(p),
            value => ConverterParaAplicacao(value),
            new ConverterMappingHints(1))
        {

        }

        static string ConverterParaOhBancoDeDados(TipoDescontoVoucher enumerador)
        {
            return enumerador.ToString()[0..1];
        }

        static TipoDescontoVoucher ConverterParaAplicacao(string value)
        {
            var tipo = Enum.GetValues<TipoDescontoVoucher>().FirstOrDefault(p => p.ToString()[0..1] == value);

            return tipo;
        }

    }
}