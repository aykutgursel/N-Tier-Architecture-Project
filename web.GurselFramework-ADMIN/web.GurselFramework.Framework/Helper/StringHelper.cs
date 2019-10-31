using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace web.GurselFramework.Framework.Helper
{
    public static class StringHelper
    {
        public static readonly char[] TrChars = { 'ç', 'ı', 'ö', 'ş', 'ü', 'ğ', 'Ç', 'İ', 'Ö', 'Ş', 'Ü', 'Ğ' };

        public static readonly char[] EnChars = { 'c', 'i', 'o', 's', 'u', 'g', 'C', 'I', 'O', 'S', 'U', 'G' };

        public static bool IsNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNull(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNumeric(this string value)
        {
            if (value.IsNull())
                return false;


            foreach (char character in value)
            {
                if (!char.IsNumber(character))
                {
                    return false;
                }
            }

            return true;
        }

        public static string ReplaceTurkishCharacter(this string value)
        {
            if (value.IsNotNull())
            {
                for (int i = 0; i < TrChars.Length; i++)
                {
                    value = value.Replace(TrChars[i], EnChars[i]);
                }
            }

            return value;
        }

        public static string ToHtmlString<T>(this List<T> list, DataColumn[] parameters)
        {
            var returnValue = string.Empty;

            try
            {
                if (list != null && list.Count > 0)
                {
                    var parameterList = parameters.ToList();

                    StringBuilder html = new StringBuilder();
                    html.Append(@"<style> table>tbody>tr>.stringFormat { mso-number-format:\@; } ");
                    html.Append("</style>");
                    html.Append("<table border='1'><thead><tr>");

                    parameterList.ForEach(c =>
                    {
                        html.AppendFormat("<th> {0} </th>", c.ColumnName);
                    });

                    html.Append("</tr></thead><tbody>");

                    list.ForEach(item =>
                    {
                        html.Append("<tr>");
                        var fieldNames = item.GetType().GetProperties().ToList();
                        parameterList.ForEach(parameter =>
                        {
                            foreach (PropertyInfo field in fieldNames)
                            {
                                if (parameter.Caption == field.Name)
                                {
                                    var className = parameter.DefaultValue.ToInt() > decimal.Zero ? parameter.DefaultValue.ToInt().ToEnum<ExcellDataTypeEnum>().Description() : string.Empty;
                                    html.Append("<td class='" + className + "'>" + item.GetType().GetProperty(field.Name).GetValue(item, null) + "</td>");
                                    break;
                                }
                            }
                        });

                        html.Append("</tr>");
                    });

                    html.Append("</tbody></table>");
                    returnValue = html.ToString();
                }
            }
            catch
            {
                returnValue = string.Empty;
            }

            return returnValue;
        }

        public static string CreateExcel(this DataTable datatable, string excelFile)
        {
            try
            {
                using (ExcellWriter writer = new ExcellWriter(excelFile))
                {
                    writer.WriteStartDocument();

                    writer.WriteStartWorksheet(string.Format("{0}", datatable.TableName)); // Write the worksheet contents
                    writer.WriteStartRow(); //Write header row
                    foreach (DataColumn col in datatable.Columns)
                    {
                        writer.WriteExcelUnstyledCell(col.Caption);
                    }
                    writer.WriteEndRow();
                    foreach (DataRow row in datatable.Rows)
                    { //write data
                        writer.WriteStartRow();
                        foreach (object o in row.ItemArray)
                        {
                            writer.WriteExcelAutoStyledCell(o);
                        }
                        writer.WriteEndRow();
                    }
                    writer.WriteEndWorksheet(); // Close up the document

                    writer.WriteEndDocument();
                    writer.Close();
                }

                return excelFile;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}