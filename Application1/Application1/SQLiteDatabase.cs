﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

public class SQLiteDatabase
{
    //set this to control size of queue
    static int max_mCount;

    static int mCount;
    SQLiteConnection m_dbConnection;
    public SQLiteDatabase()
    {
        SQLiteConnection.CreateFile("MessageDatabase.sqlite");
        //make a database
        m_dbConnection = new SQLiteConnection("Data Source=MessageDatabase.sqlite;Version=3;");
        mCount = 0;
        m_dbConnection.Open();
        string sql = "create table messages (order int, message varchar())";
        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        command.ExecuteNonQuery();
        m_dbConnection.Close();
    }
        
    static void Main()
    {
    }

    void createMessage(String message)
    {
        //if the queue isn't "full"
        if (mCount < max_mCount)
        {
            m_dbConnection.Open();
            string sql = "insert into messages (order, message) values (" + mCount + ", '" + message + "')";
            executeSQL(sql);
            mCount++;
            m_dbConnection.Close();
        }
        else
        {
            //call delete function
            deleteOldestMessage();
        }
    }
    void decrementOrder()
    {
        m_dbConnection.Open();
        executeSQL("UPDATE messages");
        executeSQL("SET order = order - 1");
        m_dbConnection.Close();
    }
    public void executeSQL(String sql)
    {
        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        command.ExecuteNonQuery();
    }

}
