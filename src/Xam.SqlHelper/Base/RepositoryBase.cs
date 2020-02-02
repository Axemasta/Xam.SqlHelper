using System;
using System.IO;
using System.Reflection;

namespace Xam.SqlHelper
{
    public abstract class RepositoryBase
    {
        #region Properties

        private string _assemblyName { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Repository Base
        /// </summary>
        /// <param name="assemblyName">The fully qualified assembly name down to where your SQL scripts are located. ie: Xam.SqlHelper.Sample.Database.SQL</param>
        public RepositoryBase(string assemblyName)
        {
            _assemblyName = assemblyName;
        }

        #endregion Constructors

        #region Methods

        #region - Public Methods

        /// <summary>
        /// Load SQL Script, Optionially optimise * with object fields
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scriptName"></param>
        /// <param name="optimise"></param>
        /// <param name="tableAbbreviation"></param>
        /// <returns></returns>
        public string LoadSql<T>(string scriptName, bool optimise = true, string tableAbbreviation = null, bool markedFieldsOnly = false)
        {
            var sqlPath = $"{_assemblyName}.{scriptName}";

            string sqlScript = sqlPath;

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(sqlPath))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException($"Could not find assembly resource: \"{sqlPath}\". Please ensure the file exists and its Build Action is set to \"Embedded Resource\"");
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    sqlScript = reader.ReadToEnd();
                }
            }

            if (optimise)
            {
                return SqlHelper.ReplaceStar<T>(sqlScript, tableAbbreviation, markedFieldsOnly);
            }
            else
            {
                return sqlScript;
            }
        }

        #endregion - Public Methods

        #endregion Methods
    }
}
