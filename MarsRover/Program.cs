using MarsRover.Models;
using MarsRover.Utility;
using System;

namespace MarsRover
{
    class Program
    {
        static void WriteToConsole(string message)
        {
            string logMessage = "Output:" + message;
            Logger.WriteToFile(logMessage);

            Console.WriteLine(message);
        }

        static string ReadConsoleLine()
        {
            var input = Console.ReadLine();

            string logMessage = "Input:" + input;
            Logger.WriteToFile(logMessage);

            return input;
        }

        static void Main(string[] args)
        {
            WriteToConsole("Hello Mars!");
            var mars = new Mars();

            WriteToConsole("You can start write 'ok' ");
            WriteToConsole("You can exit write 'exit' ");

            bool isProgramLiving = true;
            //while (isProgramLiving)
            //{

            string inputLine = ReadConsoleLine();
            switch (inputLine)
            {
                case "exit":
                    isProgramLiving = false;
                    return;
                //break;
                case "ok":
                    isProgramLiving = true;
                    break;
                default:
                    break;
            }

            WriteToConsole("We can start :) ");

            #region Plateau Size

            while (true)
            {
                WriteToConsole("Please write Plateau Size . Pattern '5 5'");

                string inputSize = ReadConsoleLine();
                Plateau plateau;


                if (mars.CheckPlateauSize(inputSize, out plateau))
                {
                    mars._plateau = plateau;
                    WriteToConsole("You are good :) ");
                    break;

                }
                else
                {
                    WriteToConsole("Plateau Size not correct patern! ");
                }
            }



            #endregion

            #region Rover Position



            Position roverPosition=new Position();

            while (true)
            {
                WriteToConsole("Please write Rover Position. Pattern '1 2 N'");

                while (true) {

                    string positionInput = ReadConsoleLine();

                    if (positionInput == "exit")
                    {
                        break;
                    }

                    if (mars.CheckRoverPosition(positionInput, out roverPosition))
                    {
                        WriteToConsole("You are good :) ");
                        WriteToConsole($"X:{roverPosition.X} Y:{roverPosition.Y} Direction:{roverPosition.Direction} ");

                      //  mars._roverPosition = roverPosition;

                        break;
                    }
                    else
                    {
                        WriteToConsole("Rover position not correct patern! Write Again ");
                    }
                }

                 


                #region navigate Rover

                WriteToConsole("Please write Rover Navigation. Pattern 'LMLRMMMRML'");


                string navigationInput = ReadConsoleLine();



                var newPosition = mars.Navigate(roverPosition,navigationInput);
 

                WriteToConsole("Rover moved ");
                WriteToConsole($"X:{newPosition.X} Y:{newPosition.Y} Direction:{newPosition.Direction} ");

                //mars._roverPosition = newPosition;
                #endregion
            }

            #endregion

            
        }
    }
}
