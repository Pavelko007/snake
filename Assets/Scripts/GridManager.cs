using UnityEngine;

namespace Snake
{
    public class GridManager
    {
        private static readonly int _minX = -5;
        private static readonly int _minY = -9;
        private static readonly int _maxX = 5;
        private static readonly int _maxY = 9;

        public static GameObject TryGetCollideable(Vector3 pos)
        {
            var col = Physics2D.OverlapPoint(pos);
            if (col != null) return col.gameObject;
            else return null;
        }

        public static Vector3 GetRandomPosition()
        {
            Vector3 randomPosition;

            do randomPosition = new Vector3(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY), 0);
            while (null != TryGetCollideable(randomPosition));

            return randomPosition;
        }
    }
}