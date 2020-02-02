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
        /// <param name="sql"></param>
        /// <param name="tableAbbreviation"></param>
        /// <returns></returns>
        public static string ReplaceStar<T>(string sql, string tableAbbreviation = null, bool markedFieldsOnly = false)
        {
            try
            {
                List<string> propertyNames = new List<string>();

                Type type = typeof(T);

                PropertyInfo[] properties;

                if (markedFieldsOnly)
                {
                    properties = type.GetProperties().Where(p => Attribute.IsDefined(p, typeof(IncludeFieldAttribute))).ToArray();
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
