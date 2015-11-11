using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    class Program
    {
        public static int frames = 1;
        static void Main(string[] args)
        {
            Game obj = new Game();
            int k;
            while (frames < 10)
            {
                Console.WriteLine("Enter the Score:");
                k = Convert.ToInt32(Console.ReadLine());
                obj.Roll(k);
            }


            Console.WriteLine("The Total Score of the Game: " + obj.Score());
            Console.ReadKey();

        }
    }
    abstract class Iframe
    {
        public int firstRoll;
        public int secondRoll;
        public int strike;
        public int spares;
        public int thirdRoll;


        public abstract int score();

        public abstract void setSpare(int set);


        public abstract void setStrike(int set);


        public abstract bool CheckStrike();

        public abstract bool CheckSpare();


    }

    class frame : Iframe
    {
        public frame()
        {
            firstRoll = 0;
            secondRoll = 0;
            strike = 0;
            spares = 0;
        }

        public override int score()   // calculate the total score.
        {
            return firstRoll + secondRoll + strike + spares;
        }
        public override void setSpare(int set)  //used to set the spare
        {
            spares = set;
        }

        public override void setStrike(int set)  //used to set the strike
        {
            strike = set;
        }

        public override bool CheckStrike()   // check for strike
        {
            if (firstRoll == 10)
                return true;
            else
                return false;
        }

        public override bool CheckSpare()   //checks for the Spare
        {
            if (firstRoll == 10)
                return false;

            if (firstRoll + secondRoll == 10)
            {
                return true;

            }
            return false;
        }

    }

    class tenframe : Iframe
    {
        public tenframe()
        {
            firstRoll = 0;
            secondRoll = 0;
            strike = 0;
            spares = 0;
            thirdRoll = 0;
        }

        public override void setSpare(int set)
        {
            spares = set;
        }

        public override void setStrike(int set)
        {
            strike = set;
        }

        public override bool CheckStrike()
        {
            if (firstRoll == 10)
                return true;
            else
                return false;
        }

        public override bool CheckSpare()
        {
            if (firstRoll == 10)
                return false;

            if (firstRoll + secondRoll == 10)
            {
                return true;

            }
            return false;
        }

        public override int score()
        {
            return firstRoll + secondRoll + strike + spares + thirdRoll;
        }
    }

     public class Game
    {
        public int _roll;

        List<Iframe> tenFrames;
        Iframe _currentFrame;
        Iframe _previousFrame;

        int _totalScore;
        public Game()
        {
            tenFrames = new List<Iframe>();
            _roll = 0;
            _totalScore = 0;
        }
         //function works when the frame is in 10
        void TenRoll(int Pins)
        {
            _roll++;

            if (_roll % 3 == 1)
            {
                _currentFrame = new tenframe();
                _currentFrame.firstRoll = Pins;
                if (_previousFrame != null)
                {
                    if (_previousFrame.CheckSpare())
                    {
                        _previousFrame.setSpare(_currentFrame.firstRoll);
                    }
                }

                if (_currentFrame.CheckStrike())
                {
                    _roll += 1;
                }

            }
            if (_roll % 3 == 2)
            {

                _currentFrame.secondRoll = Pins;
                if (_previousFrame != null)
                {
                    if (_previousFrame.CheckStrike())
                    {
                        _previousFrame.setStrike(_currentFrame.firstRoll + _currentFrame.secondRoll);
                    }
                }
                if (!(_currentFrame.CheckSpare() || _currentFrame.CheckStrike()))
                {
                    tenFrames.Add(_currentFrame);
                    Program.frames = tenFrames.Count;
                }

            }
            if (_roll % 3 == 0)
            {
                if (_currentFrame.CheckSpare() || _currentFrame.CheckStrike())
                {
                    _currentFrame.thirdRoll = Pins;
                    _previousFrame = _currentFrame;
                    tenFrames.Add(_currentFrame);
                    Program.frames = tenFrames.Count;
                }

            }
        }


         // all the pins are processed in the functions. Roll(int pins)
        public int Roll(int Pins)
        {
            if (Pins > 10)
            {
                return -1;
            }
            if (Pins < 0)
            {
                return -1;
            }

            if (tenFrames.Count == 9)
            {
                TenRoll(Pins);
                return 0;
            }
            if (tenFrames.Count == 10)
            {
                Program.frames++;
                return 0;
            }
            _roll++;
            if (_roll % 2 != 0)
            {
                _currentFrame = new frame();
                _currentFrame.firstRoll = Pins;
                if (_previousFrame != null)
                {
                    if (_previousFrame.CheckSpare())
                    {
                        _previousFrame.setSpare(_currentFrame.firstRoll);
                    }
                }
                if (_currentFrame.CheckStrike())
                {
                    _roll += 1;
                    _previousFrame = _currentFrame;
                    tenFrames.Add(_currentFrame);

                }

            }
            else
            {
                _currentFrame.secondRoll = Pins;
                if (_previousFrame != null)
                {
                    if (_previousFrame.CheckStrike())
                    {
                        _previousFrame.setStrike(_currentFrame.firstRoll + _currentFrame.secondRoll);
                    }
                }
                _previousFrame = _currentFrame;
                tenFrames.Add(_currentFrame);

            }
            Program.frames = tenFrames.Count;
           

            return 0;

        }

        public int SpareValue(int index)
        {
            Iframe thisFrame = tenFrames[index];
            return thisFrame.spares;

        }

        public int strikeValue(int index)
        {
            Iframe thisFrame = tenFrames[index];
            return thisFrame.strike;

        }


        public int Score()
        {
            _totalScore = 0;
            foreach (Iframe fr in tenFrames)
            {
                _totalScore += fr.score();
            }
            return _totalScore;
        }

    }
}
