using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{
    private string dbPath;
    private OleDbConnection conn;
    private OleDbCommand command;
    private OleDbDataAdapter adapter;
    private string stQuery;
    private OleDbDataReader reader;

    public DAL(string dbPath)
    {
        this.dbPath = dbPath;
        string ConnectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", this.dbPath);
        conn = new OleDbConnection(ConnectionString);
        command = new OleDbCommand(stQuery, conn);
        adapter = new OleDbDataAdapter(command);
    }

    public DataSet GetDataSet(string strSql)
    {
        DataSet ds = new DataSet();
        command.CommandText = strSql;
        adapter.SelectCommand = command;
        adapter.Fill(ds);
        return ds;
    }


    public bool InsertRow(string sqlInsert)
    {
        int rowsEffected;
        command.CommandText = sqlInsert;
        conn.Open();
        rowsEffected = command.ExecuteNonQuery();
        conn.Close();
        return (rowsEffected > 0);

    }

    public string GetData(string strSql)//שולפת נתונים מהטבלת המשתמשים שנמצאת באקסס
    {
        string st = "";
        DataSet ds = new DataSet();
        command.CommandText = strSql;
        conn.Open();
        st = command.ExecuteScalar().ToString();
        conn.Close();
        return (st);
    }

    public void UpdateRow(string sqlInsert)//הוספת נתונים לטבלת החברים באקסס
    {

        command.CommandText = sqlInsert;
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();

    }
    public void DeleteDataSet(DataSet ds)
    {

        OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
        adapter.DeleteCommand = builder.GetDeleteCommand();
        conn.Open();
        adapter.Update(ds);
        conn.Close();
    }

    public DataTable getDataTable(string sql, DataTable p)
    {
        this.conn.Open();
        this.command = new OleDbCommand(sql, conn);
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = command;
        adapter.Fill(p);

        conn.Close();
        return p;
    }

    public string Select(string sql, string field)
    {
        this.conn.Open();
        this.command = new OleDbCommand(sql, conn);
        this.reader = command.ExecuteReader();
        this.reader.Read();
        string j = this.reader[field].ToString();
        this.conn.Close();
        return j;

    }

    public void Update(string sql)
        {
            this.conn.Open();
            this.command = new OleDbCommand();
            this.command.CommandText = sql;
            this.command.Connection = conn;
            int response = this.command.ExecuteNonQuery();
            this.conn.Close();
        }

        public void Insert(string sql)
        {
            this.conn.Open();
            this.command = new OleDbCommand(sql, conn);
            this.reader = command.ExecuteReader();
            this.reader.Read();
            this.conn.Close();
        }
        public int Delete(string sql)
        {
            this.conn.Open();
            this.command = new OleDbCommand(sql, conn);
            int response = this.command.ExecuteNonQuery();
            this.conn.Close();
            return response;
        }


}

    