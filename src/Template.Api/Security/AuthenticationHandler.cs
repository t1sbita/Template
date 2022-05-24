using Template.Api.Core.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using Template.Api.Core.Domain.Constants;

namespace Template.Api.Security
{
    /// <summary>
    /// Authentication Handler
    /// </summary>
    public static class AuthenticationHandler
    {
        /// <summary>
        /// Documento do representado
        /// </summary>
        public const string CPFCNPJ = "cpf_cnpj";

        /// <summary>
        /// Permissoes
        /// </summary>
        public const string PERMISSAO = "permission";

        /// <summary>
        /// Tipo do Documento:
        ///   F - Pessoa Física (CPF)
        ///   J - Pessoa Jurídica (CNPJ)
        /// </summary>
        public const string TIPODOCUMENTO = "document_type";

        /// <summary>
        /// Nome do representado
        /// </summary>
        public const string NOMEREPRESENTADO = "name_represented";

        /// <summary>
        /// Perfil do usuário representante
        /// </summary>
        public const string PERFIL = "profile";

        /// <summary>
        /// Documento do representante
        /// </summary>
        public const string CPFCNPFREPRESENTANTE = "cpf_cnpj_representative";

        /// <summary>
        /// Nome do usuário representante
        /// </summary>
        public const string NOMEREPRESENTANTE = "name_representative";
        
    }
}
