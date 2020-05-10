using MarsRover.Models;
using MarsRover.Utility;
using System;

namespace MarsRover
{
    public class Mars
    {
        public Plateau _plateau;

        public bool CheckPlateauSize(string size, out Plateau plateauModel)
        {
            plateauModel = new Plateau();

            string[] plateau = size.Split(' ');

            if (plateau.Length != 2)
            {
                return false;
            }

            int tempSize;
            for (int i = 0; i < plateau.Length; i++)
            {
                if (int.TryParse(plateau[i], out tempSize))
                {
                    if (tempSize > 0)
                    {
                        if (i == 0)
                        {
                            plateauModel.X = tempSize;
                        }
                        else if (i == 1)
                        {
                            plateauModel.Y = tempSize;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRoverInPlateau(Position roverPosition)
        {
            if (roverPosition.X > _plateau.X || roverPosition.Y > _plateau.Y
                || roverPosition.X < 0 || roverPosition.Y < 0)
            {
                return false;
            }

            return true;

        }

        public bool CheckRoverPosition(string position, out Position positionModel)
        {
            positionModel = new Position();

            string[] positionArray = position.Split(' ');

            if (positionArray.Length != 3)
            {
                return false;
            }

            int tempCoordinat;
            for (int i = 0; i < positionArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        //x coordinat
                        if (int.TryParse(positionArray[i], out tempCoordinat))
                        {
                            if (tempCoordinat < 0)
                            {
                                return false;
                            }
                            positionModel.X = tempCoordinat;
                        }
                        else
                        {
                            return false;
                        }

                        break;
                    case 1:
                        //y coordinat
                        if (int.TryParse(positionArray[i], out tempCoordinat))
                        {
                            if (tempCoordinat < 0)
                            {
                                return false;
                            }
                            positionModel.Y = tempCoordinat;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case 2:
                        //direction
                        try
                        {
                            positionModel.Direction = EnumEx.GetValueFromDescription<Direction>(positionArray[i].ToUpper());

                        }
                        catch (Exception ex)
                        {
                            return false;

                        }

                        break;
                    default:
                        break;
                }
            }
            return IsRoverInPlateau(positionModel);
        }


        public Position Navigate(Position roverPosition, string navigationInput)
        {

            Position newPosition;
            foreach (var motion in navigationInput.ToUpper())
            {

                if (motion == 'M')
                {
                    newPosition = new Position(roverPosition.X, roverPosition.Y, roverPosition.Direction);

                    newPosition = Move(newPosition);

                    //Validation position
                    if (IsRoverInPlateau(newPosition))
                    {
                        roverPosition = newPosition;
                    }


                }
                else if (motion == 'R' || motion == 'L')
                {
                    roverPosition.Direction = ChangeDirection(roverPosition.Direction, motion);

                }


            }

            return roverPosition;

        }

        public Direction ChangeDirection(Direction currentDirection, char motion)
        {
            Direction newDirection = currentDirection;
            int direciton = 0;


            if (motion == 'L')
            {
                direciton = (int)currentDirection - 1;
                if (direciton == 0) direciton = 4;

            }
            else if (motion == 'R')
            {
                direciton = (int)currentDirection + 1;
                if (direciton == 5) direciton = 1;
            }
            newDirection = (Direction)direciton;


            return newDirection;
        }

        public Position Move(Position currentPosition)
        {

            switch (currentPosition.Direction)
            {
                case Direction.North:
                    currentPosition.Y++;
                    break;
                case Direction.East:
                    currentPosition.X++;
                    break;
                case Direction.South:
                    currentPosition.Y--;
                    break;
                case Direction.West:
                    currentPosition.X--;
                    break;
                default:
                    break;
            }

            return currentPosition;

        }

    }
}
