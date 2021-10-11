using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Madness
{
    public class Board
    {
        public List<Hole> Holes { get; }

        public Board(int size)
        {
            if(size % 2 != 0)
            {
                throw new ArgumentException("size", "size of board must be an even number");
            }

            if (size < 4)
            {
                throw new ArgumentOutOfRangeException("size", "size of board must be 4 or greater");
            }

            Holes = new List<Hole>();
            for (int i = 0; i < size; i++)
            {
                Holes.Add(new Hole());
            }

            Init();
        }
        
        private void Init()
        {
            for (int i = 0; i < Holes.Count; i++)
            {
                //first half of board - pegs that move from left to right
                if (i < (Holes.Count / 2) - 1)
                {
                    var peg = new Peg(Colour.Red, Direction.Right);
                    Holes[i].AddPeg(peg);
                }

                //second half of the board - pegs that move from right to left
                if (i > (Holes.Count / 2))
                {
                    var peg = new Peg(Colour.Blue, Direction.Left);
                    Holes[i].AddPeg(peg);
                }
            }
        }

        internal MoveResult TryMove(int index)
        {
            if (index < 0 || index > Holes.Count - 1)
            {
                return new MoveResult(false);
            }

            if (Holes[index].HasPeg == false)
            {
                return new MoveResult(false);
            }

            if (index == 0 && Holes[index].Peg.Direction == Direction.Left)
            {
                return new MoveResult(false);
            }

            if (index == Holes.Count - 1 && Holes[index].Peg.Direction == Direction.Right)
            {
                return new MoveResult(false);
            }

            if (Holes[index].Peg.Direction == Direction.Left)
            {
                if(index == 0)
                {
                    return new MoveResult(false);
                }


                if (Holes[index - 1].HasPeg == false)
                {
                    Holes[index - 1].AddPeg(Holes[index].Peg);
                    Holes[index].RemovePeg();
                    return new MoveResult(true);
                }

                if (index - 2 < 0)
                {
                    return new MoveResult(false);
                }

                if (Holes[index - 2].HasPeg == false)
                {
                    Holes[index - 2].AddPeg(Holes[index].Peg);
                    Holes[index].RemovePeg();
                    return new MoveResult(true, true);
                }
            }
            else
            {
                if (Holes.Count - 1 == index)
                {
                    return new MoveResult(false);
                }


                if (Holes[index + 1].HasPeg == false)
                {
                    Holes[index + 1].AddPeg(Holes[index].Peg);
                    Holes[index].RemovePeg();
                    return new MoveResult(true);
                }

                if (index + 2 > Holes.Count - 1)
                {
                    return new MoveResult(false);
                }

                if (Holes[index + 2].HasPeg == false)
                {
                    Holes[index + 2].AddPeg(Holes[index].Peg);
                    Holes[index].RemovePeg();
                    return new MoveResult(true, true);
                }
            }

            return new MoveResult(false);
        }

        internal bool CanMove(int index)
        {
            if(Holes[index].HasPeg == false)
            {
                return false;
            }

            if (Holes[index].Peg.Direction == Direction.Left)
            {
                if (index == 0)
                {
                    return false;
                }


                if (Holes[index - 1].HasPeg == false)
                {
                    return true;
                }

                if (index - 2 < 0)
                {
                    return false;
                }

                if (Holes[index - 2].HasPeg == false)
                {
                    return true;
                }
            }
            else
            {
                if(Holes.Count - 1 == index)
                {
                    return false;
                }

                if (Holes[index + 1].HasPeg == false)
                {
                    return true;
                }

                if (index + 2 > Holes.Count - 1)
                {
                    return false;
                }

                if (Holes[index + 2].HasPeg == false)
                {
                    return true;
                }
            }

            return false;
        }
    }
}