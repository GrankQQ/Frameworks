using Framework.Files;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ExcelToSQLUtility
    {
        /// <summary>
        /// 将Excel中的数据库设计文件生成SQL脚本并保存到文件中
        /// Excel中的第一个Sheet存放数据表的设计
        /// 数据表的各字段说明如下：
        /// 表名      字段      类型      是否可为空       默认值     描述
        /// </summary>
        /// <param name="filePath">Excel存放的路径</param>
        /// <param name="outFilePath">最后导出的脚本的路径</param>
        public static void CreateTableAccordingExcel(string filePath, string outFilePath)
        {
            DataTable dt = ExcelUtility.ExcelToDataTable(filePath, true);
            StringBuilder sb = new StringBuilder();
            List<string> tablNameList = new List<string>();

            Dictionary<string, string> pkDic = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, string>> descriptionDic = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, Dictionary<string, string>> defaultPikDic = new Dictionary<string, Dictionary<string, string>>();

            int tableCreate = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string tableName = dr[0].ToString();

                    if (!tablNameList.Contains(tableName))
                    {
                        if (tableCreate > 0)
                        {
                            sb.Append(")");
                            sb.Append(System.Environment.NewLine);
                        }
                        sb.Append("CREATE TABLE [" + tableName + "] (");
                        tablNameList.Add(tableName);
                    }

                    string fieldName = "";
                    string typeName = "";
                    string notNullName = " NOT NULL ";
                    string defaultName = "";
                    string descriptionName = "";
                    string identityName = "";
                    string pkName = "";

                    fieldName = dr[1].ToString();
                    typeName = dr[2].ToString();
                    if (dr[3].ToString() == "PK")
                    {
                        notNullName = " NOT NULL ";
                        identityName = "  IDENTITY(1,1) ";
                        pkName = " PRIMARY KEY ";
                    }
                    else
                    {
                        notNullName = dr[3].ToString();
                    }

                    descriptionName = dr[5].ToString();

                    if (dr[4] != DBNull.Value && !string.IsNullOrWhiteSpace(dr[4].ToString()))
                    {
                        defaultName = dr[4].ToString();
                    }

                    sb.Append("\t[" + fieldName + "]  " + typeName + "  " + notNullName + " " + identityName + "  " + pkName + (",") + System.Environment.NewLine);

                    if (!pkDic.ContainsKey(tableName) && dr[3].ToString() == "PK")
                    {
                        pkDic.Add(tableName, dr[1].ToString());
                    }

                    #region 描述

                    if (!descriptionDic.ContainsKey(tableName))
                    {
                        Dictionary<string, string> firstDescriptionDic = new Dictionary<string, string>();
                        firstDescriptionDic.Add(fieldName, $@"EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{descriptionName}', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{tableName}', @level2type=N'COLUMN',@level2name=N'{fieldName}'");

                        descriptionDic.Add(tableName, firstDescriptionDic);

                    }
                    else
                    {
                        Dictionary<string, string> existDescriptionDic = descriptionDic[tableName];
                        if (!existDescriptionDic.ContainsKey(fieldName))
                        {
                            existDescriptionDic.Add(fieldName, $@"EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{descriptionName}', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{tableName}', @level2type=N'COLUMN',@level2name=N'{fieldName}'");
                        }
                        descriptionDic[tableName] = existDescriptionDic;
                    }

                    #endregion

                    #region 默认值


                    if (!defaultPikDic.ContainsKey(tableName))
                    {
                        if (!string.IsNullOrWhiteSpace(defaultName))
                        {
                            Dictionary<string, string> firstDefaultDic = new Dictionary<string, string>();
                            firstDefaultDic.Add(fieldName, $@"ALTER TABLE {tableName} ADD  CONSTRAINT [DF__{tableName}__{fieldName}]  DEFAULT ({defaultName}) FOR [{fieldName}]");

                            defaultPikDic.Add(tableName, firstDefaultDic);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(defaultName))
                        {
                            Dictionary<string, string> existFirstDefaultDic = defaultPikDic[tableName];
                            if (!existFirstDefaultDic.ContainsKey(fieldName))
                            {
                                existFirstDefaultDic.Add(fieldName, $@"ALTER TABLE {tableName} ADD  CONSTRAINT [DF__{tableName}__{fieldName}]  DEFAULT ({defaultName}) FOR [{fieldName}]");
                            }
                            defaultPikDic[tableName] = existFirstDefaultDic;
                        }
                    }

                    #endregion

                    tableCreate++;

                }

                #region 添加默认值和描述

                if (defaultPikDic.Count > 0)
                {
                    foreach (string key in defaultPikDic.Keys)
                    {
                        Dictionary<string, string> outDic = defaultPikDic[key];
                        foreach (string fieldKey in outDic.Keys)
                        {
                            sb.Append(System.Environment.NewLine);
                            sb.Append(outDic[fieldKey]);
                        }
                    }
                }

                //描述
                if (descriptionDic.Count > 0)
                {
                    foreach (string key in descriptionDic.Keys)
                    {
                        Dictionary<string, string> outDic = descriptionDic[key];
                        foreach (string fieldKey in outDic.Keys)
                        {
                            sb.Append(System.Environment.NewLine);
                            sb.Append(outDic[fieldKey]);
                        }
                    }
                }

                #endregion
            }

            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                FileStream fs = new FileStream(outFilePath, FileMode.Create);
                byte[] data = System.Text.Encoding.Default.GetBytes(sb.ToString());

                fs.Write(data, 0, data.Length);

                fs.Flush();

                fs.Close();
            }
        }
    }
}
