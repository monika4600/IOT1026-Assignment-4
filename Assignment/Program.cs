using Assignment.InterfaceCommand;

namespace Assignment
{
    static class Program
    {
        static void Main()
        {
            RobotTester.TestRobot(); // Run your RobotTester class here -> RobotTester.TestRobot()
        }
    }

    static class RobotTester
    {
        public static void TestRobot()
        {
            Robot robot = new Robot();

            Console.WriteLine("Give 6 commands to the robot. Possible commands are:");
            Console.WriteLine("on");
            Console.WriteLine("off");
            Console.WriteLine("north");
            Console.WriteLine("south");
            Console.WriteLine("east");
            Console.WriteLine("west");

            string[] commands = new string[6];
            string[] possibleCommands = { "on", "off", "north", "south", "east", "west" };

            for (int i = 0; i < 6; i++)
            {
                Console.Write($"\nAssign command #{i + 1}: ");
                commands[i] = Console.ReadLine().ToLower();

                while (Array.IndexOf(possibleCommands, commands[i]) == -1)
                {
                    Console.WriteLine("Invalid Command - try again");
                    Console.Write($"Assign command #{i + 1}: ");
                    commands[i] = Console.ReadLine().ToLower();
                }
            }

            Console.WriteLine($"\n[{robot.X} {robot.Y} {robot.IsPowered}]");

            foreach (string command in commands)
            {

                switch (command)
                {
                    case "on":
                        robot.LoadCommand(new OnCommand());
                        break;

                    case "off":
                        robot.LoadCommand(new OffCommand());
                        break;

                    case "north":
                        robot.LoadCommand(new NorthCommand());
                        break;

                    case "south":
                        robot.LoadCommand(new SouthCommand());
                        break;

                    case "east":
                        robot.LoadCommand(new EastCommand());
                        break;

                    case "west":
                        robot.LoadCommand(new WestCommand());
                        break;

                }

                robot.Run();
                Console.WriteLine($"[{robot.X} {robot.Y} {robot.IsPowered}]");
            }
        }
    }
}
