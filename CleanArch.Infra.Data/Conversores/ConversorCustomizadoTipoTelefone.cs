using CleanArch.Domain.Models.Enumeradores;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace CleanArch.Infra.Data.Conversores
{
    public class ConversorCustomizadoTipoTelefone : ValueConverter<TipoTelefone, string>
    {
        public ConversorCustomizadoTipoTelefone() : base(
            p => ConverterParaOhBancoDeDados(p),
            value => ConverterParaAplicacao(value),
            new ConverterMappingHints(1))
        {

        }

        static string ConverterParaOhBancoDeDados(TipoTelefone enumerador)
        {
            return enumerador.ToString()[0..1];
        }

        static TipoTelefone ConverterParaAplicacao(string value)
        {
            var tipo = Enum.GetValues<TipoTelefone>().FirstOrDefault(p => p.ToString()[0..1] == value);

            return tipo;
        }

    }
}