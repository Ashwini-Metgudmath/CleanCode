using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FooFoo
{
    public class DataTableToCsvMapper
    {
        public System.IO.MemoryStream Map(DataTable dataTable)
        {
            MemoryStream ReturnStream = new MemoryStream();

            StreamWriter streamWriter = new StreamWriter(ReturnStream);
                WriteColumns(dataTable.Columns.Count, streamWriter, dataTable);
                WriteRows(dataTable, streamWriter);

                streamWriter.Flush();
                streamWriter.Close();

                return ReturnStream;
        }

        private static void WriteRows(DataTable dataTable, StreamWriter sw)
        {
            WriteRow(dataTable, sw);
        }

        private static void WriteRow(DataTable dataTable, StreamWriter sw)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    WriteCell(dr, i, sw);

                    WriteSeperatorIfRequired(dataTable, i, sw);
                }

                sw.WriteLine();
            }
        }

        private static void WriteSeperatorIfRequired(DataTable dataTable, int i, StreamWriter sw)
        {
            if (i < dataTable.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }

        private static void WriteCell(DataRow dr, int i, StreamWriter sw)
        {
            if (!Convert.IsDBNull(dr[i]))
            {
                string str = String.Format("\"{0:c}\"", dr[i].ToString()).Replace("\r\n", " ");
                sw.Write(str);
            }
            else
            {
                sw.Write("");
            }
        }

        private static void WriteColumns(int iColCount, StreamWriter sw, DataTable dt)
        {
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }

            sw.WriteLine();
        }
    }
}