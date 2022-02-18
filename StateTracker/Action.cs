using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTracker
{        
    public class Action
    {
        List<Square> Board = new List<Square>();
        List<BattleShip> BattleShipList = new List<BattleShip>();

        public void CreateBoard()
        {
            for(int i = 1; i<=10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Board.Add(new Square(i, j));
                }
            }               
        }

        public string AddBattleShip(Square start, Square end)
        {
            if(start.X <1  || start.X > 10 || start.Y < 1 || start.Y > 10 || end.X < 1 || end.X > 10 || end.Y < 1 || end.Y > 10)
            {
                return "The ship must be placed within the board range";
            }
            
            //The ship does not align vertically or horizonally
            if((start.X != end.X) && (start.Y != end.Y))
            {
                return "The ship must be aligned horizonally or vertically";
            }
            //Vertical aligned ship
            else if(start.X == end.X)
            {
                //Check the coordinates of the battleShip
                if(start.Y <= end.Y)
                {
                    //Check overlap for the square
                    for(int i = start.Y; i<=end.Y; i++)
                    {
                        var square = Board.Where(s => s.X == start.X && s.Y == i).FirstOrDefault();
                        if(square.IsOccupied)
                        {
                            return $"The Square ({start.X}, {i}) is already occupied, please find another vacant square";
                        }
                    }
                    BattleShip battleShip = new BattleShip()
                    {
                        Squares = new List<Square>()
                    };
                    for (int i = start.Y; i <= end.Y; i++)
                    {
                        var square = Board.Where(s => s.X == start.X && s.Y == i).FirstOrDefault();
                        square.IsOccupied = true;
                        battleShip.Squares.Add(square);
                    }
                    BattleShipList.Add(battleShip);
                }
                else
                {
                    //Check overlap for the square
                    for (int i = start.Y; i >= end.Y; i--)
                    {
                        var square = Board.Where(s => s.X == start.X && s.Y == i).FirstOrDefault();
                        if (square.IsOccupied)
                        {
                            return $"The Square ({start.X}, {i}) is already occupied, please find another vacant square";
                        }
                    }
                    BattleShip battleShip = new BattleShip()
                    {
                        Squares = new List<Square>()
                    };
                    for (int i = start.Y; i >= end.Y; i--)
                    {
                        var square = Board.Where(s => s.X == start.X && s.Y == i).FirstOrDefault();
                        square.IsOccupied = true;
                        battleShip.Squares.Add(square);
                    }
                    BattleShipList.Add(battleShip);
                }
            }
            //Horizonal aligned Ship
            else
            {
                //Check the coordinates of the battleShip
                if (start.X <= end.X)
                {
                    //Check overlap for the square
                    for (int i = start.X; i<=end.X; i++)
                    {
                        var square = Board.Where(s => s.X == i && s.Y == start.Y).FirstOrDefault();
                        if (square.IsOccupied)
                        {
                            return $"The Square ({i}, {start.Y}) is already occupied, please find another vacant square";
                        }
                    }
                    BattleShip battleShip = new BattleShip()
                    {
                        Squares = new List<Square>()
                    };
                    for (int i = start.X; i <= end.X; i++)
                    {
                        var square = Board.Where(s => s.X == i && s.Y == start.Y).FirstOrDefault();
                        square.IsOccupied = true;
                        battleShip.Squares.Add(square);
                    }
                    BattleShipList.Add(battleShip);
                }
                else
                {
                    //Check overlap for the square
                    for (int i = start.X; i >= end.X; i--)
                    {
                        var square = Board.Where(s => s.X == i && s.Y == start.Y).FirstOrDefault();
                        if (square.IsOccupied)
                        {
                            return $"The Square ({i}, {start.Y}) is already occupied, please find another vacant square";
                        }
                    }
                    BattleShip battleShip = new BattleShip()
                    {
                        Squares = new List<Square>()
                    };
                    for (int i = start.X; i >= end.X; i--)
                    {
                        var square = Board.Where(s => s.X == i && s.Y == start.Y).FirstOrDefault();
                        square.IsOccupied = true;
                        battleShip.Squares.Add(square);
                    }
                    BattleShipList.Add(battleShip);
                }
            }
            return "BattleShip Created Successfully";
        }

        public string Attack(Action action, Square square)
        {
            var squareInBoard = action.Board.Where(s => (s.X == square.X && s.Y == square.Y)).FirstOrDefault();
            if (squareInBoard.IsOccupied)
            {               
                squareInBoard.IsHit = true;
                var battleShip = action.BattleShipList.Where(x => x.Squares.Any(s => (s.X == square.X && s.Y == square.Y))).FirstOrDefault();
                if(battleShip.Squares.All(x =>x.IsHit == true))
                {
                    battleShip.IsSunk = true;
                }
                return "Hit";
            }
            else
            {
                return "Miss";
            }
        }

        public bool IsGameLost()
        {
            if (BattleShipList.All(x => x.IsSunk == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
