using Template.Api.Core.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace Template.Api.Core.Util
{
    [ExcludeFromCodeCoverage]
    public static class Util
    {
        public static Dictionary<string, object> AsDictionary(object source)
        {
            return source.GetType().GetProperties().ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );
        }

        public static string ToFormatedLongDateTimeString(DateTime dateTime)
        {
            return dateTime.ToString(Constant.FORMAT_LONG_DATE_TIME);
        }

        public static string ToFormatedDateTimeString(DateTime dateTime)
        {
            return dateTime.ToString(Constant.FORMAT_DATE_TIME);
        }

        public static string ToFormatedCnpj(long cnpj)
        {
            return string.Format(Constant.FORMAT_CNPJ, cnpj);
        }

        public static string ToFormatedCpf(long cpf)
        {
            return string.Format(Constant.FORMAT_CPF, cpf);
        }

        public static string ToFormatedTelephone(long telephone)
        {
            string numberFormated;

            if (telephone.ToString().Length < 11)
                numberFormated = telephone.ToString(@"(##) ####-####");
            else
                numberFormated = telephone.ToString(@"(##) #####-####");

            return numberFormated;
        }

        public static string ClearSpacesInWhite(string str)
        {
            if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
            {
                str = Regex.Replace(str, @"\s+", " ");
                str = str.Trim();
            }
            return str;
        }

    }
}
