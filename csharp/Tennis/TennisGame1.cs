using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tennis
{
    internal class TennisGame1 : ITennisGame
    {
        private int _player1Score;
        private int _player2Score;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (_player1Name == playerName)
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        public string GetScore()
        {
            if (IsEvenSore())
            {
                return GetEvenSoring();
            }

            if (IsAdvantageSore())
            {
                return GetAdvantageSoring();
            }

            return $"{GetPlayerSoring(_player1Score)}-{GetPlayerSoring(_player2Score)}";
        }

        private string GetAdvantageSoring()
        {
            string score = "";
            var minusResult = _player1Score - _player2Score;
            if (minusResult == 1) score = $"Advantage {_player1Name}";
            else if (minusResult == -1) score = $"Advantage {_player2Name}";
            else if (minusResult >= 2) score = $"Win for {_player1Name}";
            else score = $"Win for {_player2Name}";
            return score;
        }

        private bool IsAdvantageSore()
        {
            return _player1Score >= 4 || _player2Score >= 4;
        }

        private bool IsEvenSore()
        {
            return _player1Score == _player2Score;
        }

        private string GetEvenSoring()
        {
            return _player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }


        private string GetPlayerSoring(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => throw new ArgumentException($"Should never reach is point. Give score is more then 3. Given score was: {score}")
            };
        }
    }
}