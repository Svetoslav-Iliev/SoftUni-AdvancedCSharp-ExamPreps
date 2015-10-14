using System;
using System.Collections.Generic;
using System.Linq;

class CommandIterpreter
{
    static void Main()
    {
        List<string> collection =
            Console.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).ToList();

        string command = Console.ReadLine();

        while (command!="end")
        {
            string[] commandArguments = command.Split();

            switch (commandArguments[0])
            {
                case "sort":
                    ExecuteSortCommand(commandArguments, collection);
                    break;
                case "reverse":
                    ExecuteReverseCommand(commandArguments, collection);
                    break;
                case "rollLeft":
                    ExecuteRollLeftCommand(commandArguments, collection);
                    break;
                case "rollRight":
                    ExecuteRollRightCommand(commandArguments, collection);

                    break;
            }
            command = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ",collection));
    }

    private static void ExecuteReverseCommand(string[] commandArguments, List<string> collection)
    {
        int startIndex = int.Parse(commandArguments[2]);
        int count = int.Parse(commandArguments[4]);

        if (startIndex < 0 && startIndex >= collection.Count || count < 0 || startIndex + count > collection.Count)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }
        collection.Reverse(startIndex, count);
    }

    private static void ExecuteSortCommand(string[] commandArguments, List<string> collection)
    {
        int startIndex = int.Parse(commandArguments[2]);
        int count = int.Parse(commandArguments[4]);

        if (startIndex<0&&startIndex>=collection.Count || count<0||startIndex+count>collection.Count)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }
        collection.Sort(startIndex,count,StringComparer.InvariantCulture);
    }

    private static void ExecuteRollRightCommand(string[] commandArguments, List<string>collection)
    {
        int count = int.Parse(commandArguments[1]) % collection.Count;
        if (count<0)
        {
            Console.WriteLine("Invalid input parameters.");  
            return;
        }

        for (int i = 0; i < count; i++)
        {
            string lastElement = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            collection.Insert(0, lastElement);
        }
        
    }

    private static void ExecuteRollLeftCommand(string[] commandArguments, List<string> collection)
    {
        int count = int.Parse(commandArguments[1]) % collection.Count;
        if (count < 0)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            string firstElement = collection[0];
            collection.RemoveAt(0);
            collection.Add(firstElement);
        }
        

        
    }
}

