using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_427
    {
        public Medium_427()
        {

        }

        // Definition for a QuadTree node.
        public class Node
        {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node()
            {
                val = false;
                isLeaf = false;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }
        }


        public class Solution
        {
            /*
            public Node Construct(int[][] grid)
            {
                if (grid.Length == 1)
                    return new Node(grid[0][0] == 1, true);

                int midPoint = grid.Length / 2;

                Node topLeft = ConstructDivided(grid, 0, midPoint, 0, midPoint);
                Node topRight = ConstructDivided(grid, 0, midPoint, midPoint, grid.Length);
                Node bottompLeft = ConstructDivided(grid, midPoint, grid.Length, 0, midPoint);
                Node bottomRight = ConstructDivided(grid, midPoint, grid.Length, midPoint, grid.Length);

                if (topLeft.isLeaf && topRight.isLeaf && bottompLeft.isLeaf && bottomRight.isLeaf
                    && topLeft.val == topRight.val && topRight.val == bottompLeft.val && bottompLeft.val == bottomRight.val)
                    return new Node(topLeft.val, true);

                return new Node(false, false, topLeft, topRight, bottompLeft, bottomRight);
            }*/
            public Node Construct(int[][] grid)
            {
                if (grid.Length == 1)
                    return new Node(grid[0][0] == 1, true);

                return ConstructDivided(grid, 0, grid.Length, 0, grid.Length);
            }
            public Node ConstructDivided(int[][] grid, int startX, int endX, int startY, int endY)
            {
                if (endX - startX == 1)
                    return new Node(grid[startX][startY] == 1, true);

                int midPointX = (startX + endX) / 2;
                int midPointY = (startY + endY) / 2;

                Node topLeft = ConstructDivided(grid, startX, midPointX, startY, midPointY);
                Node topRight = ConstructDivided(grid, startX, midPointX, midPointY, endY);
                Node bottompLeft = ConstructDivided(grid, midPointX, endX, startY, midPointY);
                Node bottomRight = ConstructDivided(grid, midPointX, endX, midPointY, endY);

                if (topLeft.isLeaf && topRight.isLeaf && bottompLeft.isLeaf && bottomRight.isLeaf
                    && topLeft.val == topRight.val && topRight.val == bottompLeft.val && bottompLeft.val == bottomRight.val)
                    return new Node(topLeft.val, true);

                return new Node(false, false, topLeft, topRight, bottompLeft, bottomRight);
            }

        }
    }
}
