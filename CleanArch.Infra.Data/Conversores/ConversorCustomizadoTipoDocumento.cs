using CleanArch.Domain.Models.Enumeradores;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace CleanArch.Infra.Data.Conversores
{
    public class ConversorCustomizadoTipoDocumento : ValueConverter<TipoDocumento, string>
    {
        public ConversorCustomizadoTipoDocumento() : base(
            p => ConverterParaOhBancoDeDados(p),
            value => ConverterParaAplicacao(value))
        {

        }

        static string ConverterParaOhBancoDeDados(TipoDocumento enumerador)
        {
            return enumerador.ToString();
        }

        static TipoDocumento ConverterParaAplicacao(string value)
        {
            var tipo = Enum.GetValues<TipoDocumento>().FirstOrDefault(p => p.ToString() == value);

            return tipo;
        }

    }
}