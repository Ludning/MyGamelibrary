using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Graph_Algorithm
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    internal class A_star
    {
        const int CostStraight = 10;
        const int CostDiagonal = 14;

        private class ASNode
        {
            public Point point;
            public Point parent;

            public int g; // 
            public int h;
            public int f;

            public ASNode(Point point, Point parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }

        static Point[] Direction =
        {
                new Point(0,+1),//상
                new Point(0,-1),//하
                new Point(-1,0),//좌
                new Point(+1,0),//우
                new Point(-1,+1),//좌상
                new Point(-1,-1),//좌하
                new Point(+1,+1),//우상
                new Point(+1,-1)//우하
        };
        public static bool PathFinding(in bool[,] tileMap, in Point start, in Point end, out List<Point> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);
            //탐색된 노드를 저장할 배열과 방문 여부를 나타내는 배열을 초기화
            ASNode[,] nodes = new ASNode[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize];

            //다음에 탐색할 노드를 우선순위 큐에 저장
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            //시작 정점을 생성하여 추가(시작노드를 생성하여 큐에 추가)
            ASNode startNode = new ASNode(start, new Point(), 0, Heuristric(start, end));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                //탐색할 정점을 꺼내기
                //다음에 탐색할 노드를 우선순위 큐에서 가져온다
                ASNode nextNode = nextPointPQ.Dequeue();
                //방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true;

                //탐색할 정점이 도착지인 경우
                //도착했다고 판단해서 경로반환

                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    path = new List<Point>();
                    Point point = end;
                    while ((point.x == start.x && point.y == start.y) == false)
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parent;
                    }
                    path.Add(start);
                    path.Reverse();
                    return true;
                }

                //A*탐색 진행
                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;
                    //탐색라면 안되는 경우
                    //맵을 벗어나는 경우
                    if (x < 0 || x > xSize || y < 0 || y > ySize)
                        continue;
                    //탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false)
                        continue;
                    else if (visited[y, x])
                        continue;
                    //대각선으로 이동이 불가능한 지역일 경우
                    else if (i >= 4 && tileMap[y, nextNode.point.x] == false && tileMap[nextNode.point.y, x] == false)
                        continue;
                    //탐색한 정점 만들기
                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);
                    int h = Heuristric(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);
                    if (nodes[y, x] == null || nodes[y, x].f > newNode.f)
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }
            path = null;
            return false;
        }
        //휴리스틱 : 최상의 경로를 추정하는 순위값. 휴리스틱에 의해 경로탐색 효율이 결정됨
        private static int Heuristric(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);//가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);//세로로 가야하는 횟수

            //맨해튼 거리
            //return ConstStraight * (xSize + ySize);

            //타일맵 : 직선과 대각선을 통해 이동하는 거리
            int starightCount = Math.Abs(xSize - ySize);
            int diagonalCount = Math.Abs(xSize - ySize) - starightCount;

            return CostStraight * starightCount + diagonalCount;
        }
    }

    class AstarTest
    {
        static void Main(string[] args)
        {
            bool[,] tileMap = new bool[9, 9]
            {
                { false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true, false,  true,  true,  true, false },
                { false,  true, false,  true, false,  true,  true,  true, false },
                { false, false, false, false, false, false, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false },
            };

            A_star.PathFinding(tileMap, new Point(1, 1), new Point(1, 7), out List<Point> path);

            PrintResult(tileMap, path);
        }
        static void PrintResult(in bool[,] tileMap, in List<Point> path)
        {
            char[,] pathMap = new char[tileMap.GetLength(0), tileMap.GetLength(1)];

            for (int y = 0; y < pathMap.GetLength(0); y++)
            {
                for (int x = 0; x < pathMap.GetLength(1); x++)
                {
                    if (tileMap[y, x]) pathMap[y, x] = ' ';
                    else pathMap[y, x] = 'x';
                }
            }

            foreach (Point point in path)
            {
                pathMap[point.y, point.x] = '*';
            }

            Point start = path.First();//경로의 첫번째 지점을 시작으로
            Point end = path.Last();//경로의 마지막 지점을 끝점으로
            pathMap[start.y, start.x] = 'S';
            pathMap[end.y, end.x] = 'E';

            for (int i = 0; i < pathMap.GetLength(0); i++)
            {
                for (int k = 0; k < pathMap.GetLength(1); k++)
                {
                    Console.Write(pathMap[i, k]);
                }
                Console.WriteLine();
            }
        }
    }
}
