using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class BowlingGame
    {
        private const int FirstFrame = 1;
        private const int LastFrame = 10;
        private const int InitialScore = 0;
        private const int InitialRollPointer = 0;
        private const int RollsInFrameForStrike = 1;
        private const int RollsInFrameForSpare = 2;
        private const int RollsInFrameForStandardFrame = 2;
        private const int TotalPins = 10;
        private const int NextRollPointerOffset = 1;
        private const int RollAfterNextPointerOffset = 2;
        private readonly List<int> _rolls = new List<int>();

        public void Roll(int pins)
        {
            _rolls.Add(pins);
        }

        public int Score()
        {
            var totalScore = InitialScore;
            var rollPointer = InitialRollPointer;

            foreach (var unused in Enumerable.Range(FirstFrame, LastFrame))
            {
                int frameScore;

                if (IsStrike(rollPointer))
                {
                    frameScore = CalculateStrikeBonus(rollPointer);

                    rollPointer += RollsInFrameForStrike;
                }
                else if (IsSpare(rollPointer))
                {
                    frameScore = CalculateSpareBonus(rollPointer);

                    rollPointer += RollsInFrameForSpare;
                }
                else
                {
                    frameScore = CalculateNormalScore(rollPointer);

                    rollPointer += RollsInFrameForStandardFrame;
                }

                totalScore += frameScore;
            }

            return totalScore;
        }

        private bool IsStrike(int rollPointer)
        {
            return _rolls[rollPointer] == TotalPins;
        }

        private int CalculateStrikeBonus(int rollPointer)
        {
            var frameScore = _rolls[rollPointer];
            frameScore += _rolls[rollPointer + NextRollPointerOffset];
            frameScore += _rolls[rollPointer + RollAfterNextPointerOffset];
            return frameScore;
        }

        private int CalculateSpareBonus(int rollPointer)
        {
            var frameScore = _rolls[rollPointer];
            frameScore += _rolls[rollPointer + NextRollPointerOffset];
            frameScore += _rolls[rollPointer + RollAfterNextPointerOffset];
            return frameScore;
        }

        private bool IsSpare(int rollPointer)
        {
            return _rolls[rollPointer] + _rolls[rollPointer + NextRollPointerOffset] == TotalPins;
        }

        private int CalculateNormalScore(int rollPointer)
        {
            var frameScore = _rolls[rollPointer];
            frameScore += _rolls[rollPointer + NextRollPointerOffset];
            return frameScore;
        }
    }
}