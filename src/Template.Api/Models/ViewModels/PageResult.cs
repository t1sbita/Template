using Template.Api.Core.Util;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Template.Api.Models.ViewModels
{
    /// <summary>
    /// PageResult
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PageResult<TEntity>
    {
        /// <summary>
        /// Total Itens
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// Total Pages
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Number Page
        /// </summary>
        public int NumberPage { get; set; }
        /// <summary>
        /// Quantity per page
        /// </summary>
        public int SizePage { get; set; }
        /// <summary>
        /// Lista de Itens
        /// </summary>
        public List<TEntity> List { get;}

        /// <summary>
        /// Ctor init List
        /// </summary>
        public PageResult()
        {
            List = new List<TEntity>();
        }
    }
}
