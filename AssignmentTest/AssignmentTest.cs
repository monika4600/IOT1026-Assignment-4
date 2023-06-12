using Assignment;
using Assignment.InterfaceCommand;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void PropertiesTest()
        {
            Robot robot1 = new();
            Assert.AreEqual(robot1.NumCommands, 6);
            const int expectedCommands = 10;
            Robot robot2 = new(expectedCommands);
            Assert.AreEqual(robot2.NumCommands, expectedCommands);

            Assert.AreEqual(robot1.IsPowered, false);
            robot1.IsPowered = true;
            Assert.AreEqual(robot1.IsPowered, true);


            Assert.AreEqual(robot1.X, 0);
            //moves the robot even though it is off!!
            //this is very bad! not good encapsulation
            robot1.X = -5;
            Assert.AreEqual(robot1.X, -5);

            Assert.AreEqual(robot1.Y, 0);
            robot1.Y = -5;
            Assert.AreEqual(robot1.Y, -5);
        }

            [TestMethod]

            public void OnCommandTest()
            {
                Robot testRobot = new Robot();

                Assert.AreEqual(testRobot.IsPowered, false);
                testRobot.LoadCommand(new OnCommand());
                testRobot.Run();
                Assert.AreEqual(testRobot.IsPowered, true);
            }

            [TestMethod]

            public void OffCommandTest()
            {
                Robot testRobot = new();
                Assert.AreEqual(testRobot.IsPowered, false);
                testRobot.IsPowered = true;
                testRobot.LoadCommand(new OffCommand());
                testRobot.Run();
                Assert.AreEqual(testRobot.IsPowered, false);
                testRobot.Run();
                Assert.AreEqual(testRobot.IsPowered, false);
            }

            [TestMethod]

            public void MoveWestCommandTest()
            {
                Robot testRobot = new Robot();
                Assert.AreEqual(testRobot.X, 0);
                testRobot.LoadCommand(new WestCommand());
                testRobot.Run();
                //robot is powered off by default
                Assert.AreEqual(testRobot.X, 0); //robot should not move if it isn't turned on
                testRobot.IsPowered = true;
                testRobot.Run();
                Assert.AreEqual(testRobot.X, -1);
                testRobot.Run();
                Assert.AreEqual(testRobot.X, -2);
            }

             [TestMethod]

            public void MoveNorthCommandTest()
            {
                Robot testRobot = new Robot();
                Assert.AreEqual(testRobot.Y, 0);
                testRobot.LoadCommand(new NorthCommand());
                testRobot.Run();
                //robot is powered off by default
                Assert.AreEqual(testRobot.Y, 0); //robot should not move if it isn't turned on
                testRobot.IsPowered = true;
                testRobot.Run();
                Assert.AreEqual(testRobot.Y, 1);
                testRobot.Run();
                Assert.AreEqual(testRobot.Y, 2);
            }

            [TestMethod]

            public void MoveSouthCommandTest()
            {
                Robot testRobot = new Robot();
                Assert.AreEqual(testRobot.Y, 0);
                testRobot.LoadCommand(new SouthCommand());
                testRobot.Run();
                //robot is powered off by default
                Assert.AreEqual(testRobot.Y, 0); //robot should not move if it isn't turned on
                testRobot.IsPowered = true;
                testRobot.Run();
                Assert.AreEqual(testRobot.Y, -1);
                testRobot.Run();
                Assert.AreEqual(testRobot.Y, -2);
            }

             [TestMethod]

            public void MoveEastCommandTest()
            {
                Robot testRobot = new Robot();
                Assert.AreEqual(testRobot.X, 0);
                testRobot.LoadCommand(new EastCommand());
                testRobot.Run();
                //robot is powered off by default
                Assert.AreEqual(testRobot.X, 0); //robot should not move if it isn't turned on
                testRobot.IsPowered = true;
                testRobot.Run();
                Assert.AreEqual(testRobot.X, 1);
                testRobot.Run();
                Assert.AreEqual(testRobot.X, 2);
            }
    }

}
