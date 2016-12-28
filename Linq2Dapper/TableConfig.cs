using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Dapper.Contrib.Linq2Dapper
{
    public static class TableEx
    {
        /// <summary>
        /// 增加配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <param name="member"></param>
        /// <param name="mapperName"></param>
        /// <returns></returns>
        public static TableConfig<T> Map<T>(this TableConfig<T> config,
            Expression<Func<T, Object>> member, String mapperName)
        {
            var propertyInfo = ReadMemberInfo(member);

            if (config.RecordRowConfigs.Any(s => s.ModelPropertyName == propertyInfo.Name))
            {
                // ReSharper disable once PossibleNullReferenceException
                config.RecordRowConfigs.SingleOrDefault(s => s.ModelPropertyName == propertyInfo.Name)
                    .TargetPropertyName = mapperName;

                return config;
            }

            config.RecordRowConfigs.Add(new RecordRowConfig()
            {
                ModelPropertyName = propertyInfo.Name,
                ModelProperty = propertyInfo,
                TargetPropertyName = mapperName
            });

            return config;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static TableConfig<T> Table<T>(this TableConfig<T> config, String tableName)
        {
            config.TableName = tableName;

            return config;
        }

        /// <summary>
        /// 设置主键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static TableConfig<T> Key<T>(this TableConfig<T> config, Expression<Func<T, Object>> member)
        {
            var propertyInfo = ReadMemberInfo(member);

            var record = config.RecordRowConfigs.SingleOrDefault(s => s.ModelPropertyName == propertyInfo.Name);

            if (record != null)
            {
                record.IsKey = true;
            }

            return config;
        }

        /// <summary>
        /// 设置忽略
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static TableConfig<T> Ignore<T>(this TableConfig<T> config, Expression<Func<T, Object>> member)
        {
            var propertyInfo = ReadMemberInfo(member);

            var record = config.RecordRowConfigs.SingleOrDefault(s => s.ModelPropertyName == propertyInfo.Name);

            if (record != null)
            {
                config.RecordRowConfigs.Remove(record);
            }

            return config;
        }

        /// <summary>
        /// 解析表达式树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static PropertyInfo ReadMemberInfo<T>(Expression<Func<T, Object>> expression)
        {
            var body = expression.Body;
            if (body.NodeType == ExpressionType.Convert)
                body = ((UnaryExpression)body).Operand;
            var accessMember = (MemberExpression)body;
            return (PropertyInfo)accessMember.Member;
        }
    }

    public class TableConfig
    {
        public String TableName { get; set; }

        public TableConfig()
        {
            RecordRowConfigs = new List<RecordRowConfig>();
        }

        /// <summary>
        /// 映射的模型信息
        /// </summary>
        public Type MapModelType { get; set; }

        /// <summary>
        /// 所有的列配置
        /// </summary>
        public List<RecordRowConfig> RecordRowConfigs { get; set; }

        public static TableConfig CreateTableConfig(Type type)
        {
            TableConfig tableConfig = new TableConfig();

            tableConfig.MapModelType = type;

            return tableConfig;
        }

        /// <summary>
        /// 添加一个列配置 或许可以考虑直接覆盖
        /// </summary>
        /// <param name="recordRowConfig"></param>
        public void AddRecordRowConfig(RecordRowConfig recordRowConfig)
        {
            var recordRow =
                RecordRowConfigs.SingleOrDefault(s => s.ModelPropertyName == recordRowConfig.ModelPropertyName);

            if (recordRow != null)
            {
                throw new InvalidOperationException($"为{recordRowConfig.ModelPropertyName}重复指定了映射配置");
            }

            RecordRowConfigs.Add(recordRowConfig);
        }

        internal TableConfig InitMap()
        {
            PropertyInfo[] propertyInfos = MapModelType.GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                RecordRowConfigs.Add(new RecordRowConfig()
                {
                    IsKey = false,
                    ModelPropertyName = propertyInfo.Name,
                    ModelProperty = propertyInfo,
                    TargetPropertyName = propertyInfo.Name
                });
            }

            this.TableName = MapModelType.Name;

            return this;
        }
    }

    public class TableConfig<T> : TableConfig
    {
        public TableConfig()
        {
            MapModelType = typeof(T);

            TableName = MapModelType.Name;

            InitMap();
        }
    }

    public class RecordRowConfig
    {
        /// <summary>
        /// 原映射的目标名称
        /// </summary>
        public String ModelPropertyName { get; set; }

        public PropertyInfo ModelProperty { get; set; }

        /// <summary>
        /// 最终映射的名称
        /// </summary>
        public String TargetPropertyName { get; set; }

        public Boolean IsKey { get; set; }

        ///// <summary>
        ///// 读取cell的时候的映射配置
        ///// </summary>
        //public Func<String, String> ReadConvertion { get; set; }

        ///// <summary>
        ///// 写入cell的映射配置
        ///// </summary>
        //public Func<object, object> WriteConversion { get; set; }
    }

    /// <summary>
    /// 保存 TableConfig
    /// </summary>
    public static class TableMap
    {
        internal static readonly Dictionary<Type, TableConfig> Configs
            = new Dictionary<Type, TableConfig>();

        public static TableConfig<T> Config<T>(String tableName = "")
        {
            TableConfig<T> config;
            var configKey = typeof(T);
            if (Configs.Keys.Contains(configKey))
                config = (TableConfig<T>)Configs[configKey];
            else
            {
                config = new TableConfig<T>
                {
                    TableName = String.IsNullOrEmpty(tableName) ? configKey.Name : tableName
                };
                Configs.Add(configKey, config);
            }
            return config;
        }
    }
}