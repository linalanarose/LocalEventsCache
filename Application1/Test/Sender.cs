﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Database;

namespace Sender
{
    /// <summary>
    /// This class promotes a console for user to send messages
    /// </summary>
    class Sender
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter message to send or type 'exit' to quit\n");
            //creates a new sqlitedatabase
            SQLiteDatabase database = new SQLiteDatabase(3);
            //while the user is in the system entering messages
            while (true)
            {
                //make sure the message isn't null or exitg
                var messageText = Console.ReadLine();
                if (string.IsNullOrEmpty(messageText) || messageText == "exit")
                {
                    break;
                }
                //create message from console input and add to table
                database.createMessage(messageText);
                //TEMPORARY open the database and list all current messages
                database.listMessage();
                
            }
        }
    }
}
