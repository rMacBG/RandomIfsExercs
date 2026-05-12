using System.Linq;

namespace RandomIfsExercs
{
    public class Program
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

                string command = arguments[0].ToLower();
                switch (command)
                {
                    case ".help":
                        UserHelp();
                        break;
                    case "add":
                        if (arguments.Length >= 3)
                        {
                            AddUser(arguments, usernamePasswordHolders);
                        }
                        break;
                    case "show":
                        ShowUsers(usernamePasswordHolders);
                        break;
                    case "edit":
                        if (arguments.Length >= 4)
                        {
                            EditUser(arguments, usernamePasswordHolders);
                        }
                        break;
                    case "delete":
                        if (arguments.Length >= 3)
                        {
                            DeleteUser(arguments, usernamePasswordHolders);
                        }
                        break;
                    case "stop":
                        return;
                    default:
                        Console.WriteLine("Uknown command");
                        break;
                }

            }
        }

        public static void AddUser(string[] arguments, Dictionary<string, string> users)
        {
            if (users.ContainsKey(arguments[1]))
            {
                Console.WriteLine("User already exists!");
                return;
            }
                users.Add(arguments[1], arguments[2]);
            Console.WriteLine($"Added {arguments[1]} to the dictionary!");

        }

        public static void EditUser(string[] arguments, Dictionary<string, string> users)
        {
                if (users.ContainsKey(arguments[1]) && users[arguments[1]] == arguments[2])
                {
                    {
                        users[arguments[1]] = arguments[3];
                        Console.WriteLine($"User {arguments[1]}'s password has been edited successfully!");
                    }

                }
        }

        public static void DeleteUser(string[] arguments, Dictionary<string, string> users)
        {
            if (users.ContainsKey(arguments[1]) && users[arguments[1]] == arguments[2])
            {
                Console.WriteLine($"Username: {arguments[1]} | {users[arguments[1]]}");
                Console.WriteLine("Are you sure that you want to delete this user?");

                string confrimation = Console.ReadLine().ToLower();
                if (confrimation == "yes")
                {

                    users.Remove(arguments[1]);
                    Console.WriteLine("User deleted");
                }
                else
                {
                    Console.WriteLine("User deletion terminated!");

                    Console.WriteLine("Going back to standby mode");
                }


            }
        }

        public static void ShowUsers(Dictionary<string, string> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("There are no users who have registered!");
            }
            else
            {
                Console.WriteLine("All users who have registered");
                foreach (var item in users)
                {
                    Console.WriteLine($"Username: {item.Key} | Password: {item.Value}");
                }
            }
        }

        public static void UserHelp()
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

    }
}
