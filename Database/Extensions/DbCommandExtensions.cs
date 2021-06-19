using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace TerrariaLauncher.Commons.Database.Extensions
{
    public static class DbCommandExtensions
    {
        public static DbParameter AddParameterWithValue(this DbCommand dbCommand, string name, object value)
        {
            var parameter = dbCommand.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            dbCommand.Parameters.Add(parameter);
            return parameter;
        }

        public static DbParameter AddParameter(this DbCommand dbCommand, string name, DbType dbType)
        {
            var parameter = dbCommand.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = dbType;
            dbCommand.Parameters.Add(parameter);
            return parameter;
        }
    }
}
