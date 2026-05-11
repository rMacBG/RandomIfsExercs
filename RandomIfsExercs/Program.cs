using System.Linq;

namespace RandomIfsExercs
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("This is a simple username and password console app, if you want to know more about how it works type .help");
            Dictionary<string, string> usernamePasswordHolders = new Dictionary<string, string>();
            while (true)
            {
                Console.Write("> ");
                string[] arguments = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (arguments.Length == 0)
                    continue;
               
                try
                {
                    if (arguments[0].ToLower() == "stop")
                        break;
                    if (arguments[0].ToLower() == ".help")
                    {
                        Console.WriteLine("""
                        This command shows what commands could be used
                        stop - exits the program
                        help - shows this little guide
                        add (add arg1 arg2) - adds a new username to the dictionary with the 2 arguments
                        show - shows whether there are usernames or not
                        edit (edit arg1 arg2 arg3) - edits a username's password by checking if the user exists and if the password is correct, 
                        if both arguments are correct the user's password is changed to the arg3 value
                        delete (delete arg1 arg2) - deletes a user from the dictionary, but before deleting its followed by a confirmation menu
                        """);

                    }
                    if (arguments[0].ToLower() == "add" && arguments.Length >=3)
                    {
                        usernamePasswordHolders.Add(arguments[1], arguments[2]);
                        Console.WriteLine($"Added {arguments[1]} to the dictionary!");
                    }

                    if (arguments[0].ToLower() == "show")
                    {


                        if (usernamePasswordHolders.Count == 0)
                        {
                            Console.WriteLine("There are no users who have registered!");
                        }
                        else
                        {
                            Console.WriteLine("All users who have registered");
                            foreach (var item in usernamePasswordHolders)
                            {
                                Console.WriteLine($"Username: {item.Key} | Password: {item.Value}");
                            }
                        }
                    }
                    try
                    {
                        //if (arguments[0] == "edit" && arguments[1] != null && arguments[2] != null && arguments[3] != null)
                        if(arguments[0] == "edit" && arguments.Length >= 4)
                        {
                            if (usernamePasswordHolders.ContainsKey(arguments[1]) && usernamePasswordHolders[arguments[1]] == arguments[2])
                            {
                                {
                                    usernamePasswordHolders[arguments[1]] = arguments[3];
                                }

                            }

                        }
                    }
                    catch (Exception)
                    {

                        throw new Exception("Not enough parameters were entered!");
                    }


                    if (arguments[0].ToLower() == "delete" && arguments.Length >= 3)
                    {

                        if (usernamePasswordHolders.ContainsKey(arguments[1]) && usernamePasswordHolders[arguments[1]] == arguments[2])
                        {
                            Console.WriteLine($"Username: {arguments[1]} | {usernamePasswordHolders[arguments[1]]}");
                            Console.WriteLine("Are you sure that you want to delete this user?");

                            string confrimation = Console.ReadLine().ToLower();
                            if (confrimation == "yes")
                            {

                                usernamePasswordHolders.Remove(arguments[1]);
                                Console.WriteLine("User deleted");
                            }
                            else
                            {
                                Console.WriteLine("User deletion terminated!");

                                Console.WriteLine("Going back to standby mode");
                            }


                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                    
                }
                

            }
        }
    }
}
