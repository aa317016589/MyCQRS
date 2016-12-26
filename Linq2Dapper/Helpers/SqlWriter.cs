﻿using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dapper.Contrib.Linq2Dapper.Helpers
{
    internal class SqlWriter<TData>
    {
        private StringBuilder _selectStatement;
        private readonly StringBuilder _joinTable;
        private readonly StringBuilder _whereClause;
        private readonly StringBuilder _orderBy;

        private int _nextParameter;

        private string _parameter
        {
            get { return string.Format("ld__{0}", _nextParameter += 1); }
        }

        internal bool NotOperater;
        internal int TopCount;
        internal bool IsDistinct;

        internal DynamicParameters Parameters { get; private set; }

        internal string Sql
        {
            get
            {
                SelectStatement();
                return _selectStatement.ToString();
            }
        }

        internal SqlWriter()
        {
            Parameters = new DynamicParameters();
            _joinTable = new StringBuilder();
            _whereClause = new StringBuilder();
            _orderBy = new StringBuilder();

            GetTypeProperties();
        }

        private void GetTypeProperties()
        {
            Helper.GetTypeProperties(typeof (TData));
        }

        private void SelectStatement()
        {
            var table = CacheHelper.TryGetTable<TData>();

            _selectStatement = new StringBuilder();

            _selectStatement.Append("SELECT ");

            if (TopCount > 0)
                _selectStatement.Append("TOP(" + TopCount + ") ");

            if (IsDistinct)
                _selectStatement.Append("DISTINCT ");

            for (int i = 0; i < table.Columns.Count; i++)
            {
                var x = table.Columns.ElementAt(i);
                _selectStatement.Append(string.Format("{0}.[{1}]", table.Identifier, x.Value));

                if ((i + 1) != table.Columns.Count)
                    _selectStatement.Append(",");

                _selectStatement.Append(" ");
            }

            _selectStatement.Append(string.Format("FROM [{0}] {1}", table.Name, table.Identifier));
            _selectStatement.Append(WriteClause());
        }

        private string WriteClause()
        {
            var clause = string.Empty;

            // JOIN
            if (!string.IsNullOrEmpty(_joinTable.ToString()))
                clause += _joinTable;

            // WHERE
            if (!string.IsNullOrEmpty(_whereClause.ToString()))
                clause += " WHERE " + _whereClause;

            //ORDER BY
            if (!string.IsNullOrEmpty(_orderBy.ToString()))
                clause += " ORDER BY " + _orderBy;

            return clause;
        }

        internal void WriteOrder(string name, bool descending)
        {
            var order = new StringBuilder();
            order.Append(name);
            if (descending) order.Append(" DESC");
            if (!string.IsNullOrEmpty(_orderBy.ToString())) order.Append(", ");
            _orderBy.Insert(0, order);
        }

        internal void WriteJoin(string joinToTableName, string joinToTableIdentifier, string primaryJoinColumn, string secondaryJoinColumn)
        {

            _joinTable.Append(string.Format(" JOIN [{0}] {1} ON {2} = {3}", joinToTableName, joinToTableIdentifier, primaryJoinColumn, secondaryJoinColumn));
        }

        internal void Write(object value)
        {
            _whereClause.Append(value);
        }

        internal void Parameter(object val)
        {
            if (val == null)
            {
                Write("NULL");
                return;
            }

            var param = _parameter;
            Parameters.Add(param, val);

            Write("@" + param);
        }

        internal void AliasName(string aliasName)
        {
            Write(aliasName);
        }

        internal void ColumnName(string columnName)
        {
            Write(columnName);
        }

        internal void IsNull()
        {
            Write(" IS");
            if (!NotOperater)
                Write(" NOT");
            Write(" NULL");
            NotOperater = false;
        }

        internal void IsNullFunction()
        {
            Write("ISNULL");
        }

        internal void Like()
        {
            if (NotOperater)
                Write(" NOT");
            Write(" LIKE ");
            NotOperater = false;
        }

        internal void In()
        {
            if (NotOperater)
                Write(" NOT");
            Write(" IN ");
            NotOperater = false;
        }

        internal void Operator()
        {
            Write(Helper.GetOperator((NotOperater) ? ExpressionType.NotEqual : ExpressionType.Equal));
            NotOperater = false;
        }

        internal void Boolean(bool op)
        {
            Write((op ? " <> " : " = ") + "0");
        }

        internal void OpenBrace()
        {
            Write("(");
        }

        internal void CloseBrace()
        {
            Write(")");
        }

        internal void WhiteSpace()
        {
            Write(" ");
        }

        internal void Delimiter()
        {
            Write(", ");
        }

        internal void LikePrefix()
        {
            Write("'%' + ");
        }

        internal void LikeSuffix()
        {
            Write("+ '%'");
        }

        internal void EmptyString()
        {
            Write("''");
        }
    }
}
