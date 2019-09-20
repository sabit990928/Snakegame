using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class MySnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 3;
        private Point _myHeadPosition;
        private Point _myFoodPosition;
        private int foodX;
        private int foodY;

        public string Name => "Sabit Snake";

        public MySnake(int foodX, int foodY) {
            this.foodX = foodX;
            this.foodY = foodY;
        }

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {
            Console.WriteLine(currentDirection + "food" + _myFoodPosition.X + _myFoodPosition.Y + "head" + _myHeadPosition.Y);
            if(currentDirection == SnakeDirection.Up 
                && _myHeadPosition.Y < _wallDistanceThreshold)
            {
				if(_myHeadPosition.X == _myFoodPosition.X && _myHeadPosition.Y < _myFoodPosition.Y)
					return SnakeDirection.Right;
				if(_myHeadPosition.X == _myFoodPosition.X && _myHeadPosition.Y > _myFoodPosition.Y)
					return SnakeDirection.Left;
				if(_myHeadPosition.Y == _myFoodPosition.Y && _myHeadPosition.Y > _myFoodPosition.Y)
					return SnakeDirection.Right;
				if(_myHeadPosition.Y == _myFoodPosition.Y && _myHeadPosition.Y < _myFoodPosition.Y)
					return SnakeDirection.Left;

            	if(_myHeadPosition.Y < _wallDistanceThreshold)
                	return SnakeDirection.Left;
            }

            if(currentDirection == SnakeDirection.Up
                && _myFoodPosition.Y < _myHeadPosition.Y)
            {
                return SnakeDirection.Up;
            }

            if (currentDirection == SnakeDirection.Right
                && _myHeadPosition.X > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Up;
            }

            if(currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left
                && _myHeadPosition.X <  _wallDistanceThreshold)
            {
                return SnakeDirection.Down;
            }

            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            Console.SetCursorPosition(0, 0);
            // Console.WriteLine("map: " + map);
            _myHeadPosition = getMyHeadPosition(map);
            _myFoodPosition = getMyFoodPosition(map);
            Console.WriteLine("head: " + _myHeadPosition + " food: " + _myFoodPosition);

        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }

        private Point getMyFoodPosition(string map) {
            var foodIndex = map.IndexOf('7');
            return new Point(foodIndex % _width, foodIndex / _width);

        }
    }
}
