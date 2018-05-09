using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Snake
{
    public class Snake : MonoBehaviour
    {
        public Color SnakeColor = Color.black;
        public Color HeadColor = Color.green;
        public List<GameObject> StartConfiguration;
        public GameObject SnakeSegment;

        private float lastStepTime;
        private float stepDuration = .5f;
        private LinkedList<GameObject> snakeSegmentsList = new LinkedList<GameObject>();
        private float stepDist = 1.0f;
        private Spawner spawner;
        private string collectableTag = "Collectable";
        private GameManager gameManager;
        private string snakeTag = "Snake";
        private string wallTag = "Wall";

        enum Dir //don't reorder enum values
        {
            Up = 0,
            Left = 1,
            Down = 2, 
            Right = 3
        }

        private Dir? curDir;

        private Vector3 pressPosition;

        public Vector3 MoveVector
        {
            get
            {
                Assert.IsTrue(curDir.HasValue);
                return GetDirVector(curDir.Value);
            }
        }

        [Inject]
        void Construct(Spawner spawner, GameManager gameManager)
        {
            this.spawner = spawner;
            this.gameManager = gameManager;
        }

        void Awake()
        {
            lastStepTime = Time.time;
            foreach (var segment in StartConfiguration)
            {
                snakeSegmentsList.AddLast(segment);
            }
        }

        void Start()
        {
            UpdateColors();
        }

        // Update is called once per frame

        void Update ()
        {
            HandleInput();

            if (curDir.HasValue && Time.time - lastStepTime > stepDuration)
            {
                ProcessStep();
            }
        }

        private void ProcessStep()
        {
            Vector3 headPos = snakeSegmentsList.First.Value.transform.position;

            Vector3 headPosNext = headPos + stepDist * MoveVector;

            GameObject collideable = GridManager.TryGetCollideable(headPosNext);

            if (collideable != null)
            {
                if (collideable.CompareTag(collectableTag))
                {
                    collideable.tag = snakeTag;
                    collideable.transform.SetParent(transform, true);
                    snakeSegmentsList.AddFirst(collideable);

                    spawner.SpawnSegment();
                }
                else
                {
                    if (collideable.CompareTag(snakeTag) || collideable.CompareTag(wallTag))
                    {
                        gameManager.GameOver();
                    }
                }
            }
            else
            {
                snakeSegmentsList.AddFirst(snakeSegmentsList.Last.Value);
                snakeSegmentsList.RemoveLast();
                snakeSegmentsList.First.Value.transform.position = headPosNext;
            }

            UpdateColors();

            lastStepTime = Time.time;
        }

        private void UpdateColors()
        {
            foreach (var segment in snakeSegmentsList)
            {
                segment.GetComponent<Block>().ChangeColor(SnakeColor);
            }
            snakeSegmentsList.First.Value.GetComponent<Block>().ChangeColor(HeadColor);
        }

        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                pressPosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                Vector3 swipeVector = (Input.mousePosition - pressPosition).normalized;
                TryChangeDirection(GetDragDirection(swipeVector));
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryChangeDirection(Dir.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryChangeDirection(Dir.Right);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TryChangeDirection(Dir.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                TryChangeDirection(Dir.Down);
            }
        }
        private Dir GetDragDirection(Vector3 dragVector)
        {
            float positiveX = Mathf.Abs(dragVector.x);
            float positiveY = Mathf.Abs(dragVector.y);
            Dir draggedDir;
            if (positiveX > positiveY)
            {
                draggedDir = (dragVector.x > 0) ? Dir.Right : Dir.Left;
            }
            else
            {
                draggedDir = (dragVector.y > 0) ? Dir.Up : Dir.Down;
            }
            Debug.Log(draggedDir);
            return draggedDir;
        }
        private void TryChangeDirection(Dir newDir)
        {
            if (curDir.HasValue)
            {
                if (curDir == newDir) return;

                var isOppositeDirections = IsOppositeDirections(newDir, curDir.Value);
                if (isOppositeDirections) return;
            }
            curDir = newDir;
            ProcessStep();
        }

        private bool IsOppositeDirections(Dir newDir, Dir dir)
        {
            int dirDist = Math.Abs((int) dir - (int) newDir);
            return 2 == dirDist;
        }

        private Vector3 GetDirVector(Dir dir)
        {
            switch (dir)
            {
                case Dir.Up:
                    return Vector3.up;
                case Dir.Left:
                    return Vector3.left;
                case Dir.Down:
                    return Vector3.down;
                case Dir.Right:
                    return Vector3.right;
                default:
                    throw new ArgumentOutOfRangeException("dir", dir, null);
            }
        }

        public class Factory : Factory<Snake> { }
    }
}
