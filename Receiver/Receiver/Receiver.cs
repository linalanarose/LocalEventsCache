﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Receiver
{
    class Receiver
    {
        static void Main(string[] args)
        {
           Console.Write("Receiving Messages\n");
           SQLiteDatabase database = new SQLiteDatabase("C:/SQLiteDataBase/receivedMsg.txt", 1000);
           String[] result = database.receiveAllMsgs();
           for (int i = 0; i < result.Length; i++)
           {
               Console.Write(result[i]+"\n");
           }
            Console.ReadKey();
        }
    }
}
