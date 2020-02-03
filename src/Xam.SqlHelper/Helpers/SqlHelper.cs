using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Xam.SqlHelper.Attributes;
using Xam.SqlHelper.Exceptions;

namespace Xam.SqlHelper
{
    /// <summary>
    /// SqlHelper
    /// </summary>
    public static class SqlHelper
    {
        #region Methods

        #region - Public Methods

        /// <summary>
        /// Replace * In SQL Statement With Object Properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The sql you wish to replace * with schema</param>
        /// <param name="tableAbbreviation">The table abbreviation to prefix each field. ie 'ei' -> 'ei.[Field]'</param>
        /// <returns></returns>
        public static string ReplaceStar<T>(string sql, string tableAbbreviation = null, bool includedFieldsOnly = true)
        {
            try
            {
                List<string> propertyNames = new List<string>();

                Type type = typeof(T);

                PropertyInfo[] properties;

                if (includedFieldsOnly)
                {
                    properties = type.GetProperties().Where(p => !Attribute.IsDefined(p, typeof(ExcludeFieldAttribute))).ToArray();
                }
                else
                {
                    properties = type.GetProperties();
                }

                string wrapper = string.Empty;

                if (tableAbbreviation != null)
                {
                    wrapper = tableAbbreviation + ".";
                }

                foreach (var property in properties)
                {
                    propertyNames.Add(wrapper + "[" + property.Name + "]");
                }

                string fields = string.Join(", ", propertyNames);

                return sql.Replace("*", fields);
            }
            catch (Exception ex)
            {
                throw new OptimisationException(ex);
            }
        }

        #endregion - Public Methods

        #endregion Methods
    }
}
