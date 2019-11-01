using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class FindPathAlgorithm
    {
        public static List<Point> AStar(int[][] map, int startX, int startY, int endX, int endY)
        {
            Point start = new Point(startX, startY);
            Point end = new Point(endX, endY);
            List<Point> allPoints = new List<Point>();
            for(int i = 0; i < map.Length; i++)
            {
                for(int j = 0; j < map[i].Length; j++)
                {
                    allPoints.Add(new Point(i, j) { Value = map[i][j] });
                }
            }

            return AStar(allPoints, start, end);
        }

        public static List<Point> AStar(List<Point> allPoints, Point start, Point end)
        {
            List<Point> finalPath = new List<Point>();
            List<Point> openPathList = new List<Point>();
            List<Point> closedPathList = new List<Point>();

            openPathList.Add(start);

            bool findSuccess = false;
            while (openPathList.Count > 0)
            {
                IEnumerable<Point> minPoints = GetMinFPoints(openPathList);
                foreach(Point p in minPoints)
                {
                    if(p == end)
                    {                        
                        findSuccess = true;
                        break;
                    }
                    List<Point> neighborPoints = GetNeighborPoints(allPoints, p);
                    foreach(Point childPoint in neighborPoints)
                    {
                        if (closedPathList.Contains(childPoint))
                            continue;
                        if (!openPathList.Contains(childPoint))
                        {
                            openPathList.Add(childPoint);
                            childPoint.Parent = p;
                        }
                        else
                        {

                        }
                    }
                }
                if (findSuccess)
                    break;
            }
            if (findSuccess)
            {
                
            }
                        
            

            return finalPath;
        }

        public static void FindNext(List<Point> openPathList, List<Point> closedPathList, Point current)
        {
            if (!closedPathList.Contains(current))
            {
                closedPathList.Add(current);
            }
        }

        /// <summary>
        /// 获取距离最小的数据
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private static IEnumerable<Point> GetMinFPoints(IEnumerable<Point> points)
        {
            int minDistance = points.Min(c => c.DistanceToEnd + c.DistanceToStart);
            return points.Where(c => c.DistanceToStart + c.DistanceToEnd == minDistance);
        }

        /// <summary>
        /// 获取当前点的前后左右数据
        /// </summary>
        /// <param name="allPoints"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public static List<Point> GetNeighborPoints(List<Point> allPoints, Point current)
        {
            List<Point> neighborPoints = new List<Point>();

            Point leftPoint = allPoints.Where(c => c.X == current.X - 1 && c.Y == current.Y && c.Value == 0).FirstOrDefault();
            if (leftPoint != null)            
                neighborPoints.Add(leftPoint);
                

            Point rightPoint = allPoints.Where(c => c.X == current.X + 1 && c.Y == current.Y && c.Value == 0).FirstOrDefault();
            if (rightPoint != null)
                neighborPoints.Add(rightPoint);                

            Point upPoint = allPoints.Where(c => c.X == current.X && c.Y == current.Y - 1 && c.Value == 0).FirstOrDefault();
            if (upPoint != null)
                neighborPoints.Add(upPoint);

            Point downPoint = allPoints.Where(c => c.X == current.X && c.Y == current.Y + 1 && c.Value == 0).FirstOrDefault();
            if (downPoint != null)
                neighborPoints.Add(downPoint);

            return neighborPoints;
        }

        /// <summary>
        /// 计算两点之间的曼哈顿距离
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static int ManhattanTwoPoints(Point x1, Point x2)
        {
            return Math.Abs(x1.X - x2.X) + Math.Abs(x1.Y - x2.Y);
        }
    }

    public class Point :IComparable
    {
        public int X { get; set; }

        public int Y { get; set; }

        /// <summary>
        /// g(n)
        /// </summary>
        public int DistanceToStart { get; set; }

        /// <summary>
        /// H(n)
        /// </summary>
        public int DistanceToEnd { get; set; }

        public List<Point> Children { get; set; }

        public Point Parent { get; set; }
        
        /// <summary>
        /// Value = 0 表示没有遮挡
        /// > 0 表示有遮挡
        /// </summary>
        public int Value { get; set; }
        
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            
            Point targetObj = (Point)obj;
            if (this.X < targetObj.X)
                return -1;
            else if (this.X == targetObj.X)
            {
                if (this.Y < targetObj.Y)
                    return -1;
                else if (this.Y == targetObj.Y)
                    return 0;
                else
                    return 1;
            }
            else
                return 1;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return this.CompareTo(obj) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
