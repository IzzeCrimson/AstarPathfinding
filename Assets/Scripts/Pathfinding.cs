using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{

    //What I could have done better?
    //Seperating the pathfinding and grid script.
    //The Pathfinding, the Grid and the Player is tied togheter, the Grid is only created when the player/movement script instantiates it.

    int movementCostStraight;
    int movementCostDiagonal;

    public Grid grid;

    private List<Node> openList;
    private List<Node> closeList;

    public Pathfinding(int width, int height)
    {

        grid = new Grid(width, height, 1f);
        movementCostStraight = 10;
        movementCostDiagonal = 14;

    }

    public List<Node> FindPath(int startX, int startY, int endX, int endY)
    {
        Node startNode = grid.GetNode(startX, startY);
        Node endNode = grid.GetNode(endX, endY);

        openList = new List<Node> { startNode };
        closeList = new List<Node>();

        //Resets data before starting a new pathfinding
        for (int i = 0; i < grid.gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < grid.gridArray.GetLength(1); j++)
            {
                Node node = grid.GetNode(i, j);
                node.gCost = int.MaxValue;
                node.CalculateFCost();
                node.previousNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            Node currentNode = GetLowestFCostNode(openList);

            //OpenList - List with nodes that the unit can potentially can use to reach the goal
            //ClosedList - List with nodes that already have been checked or are intraversable
            openList.Remove(currentNode);
            closeList.Add(currentNode);

            if (currentNode == endNode)
            {
               return GetReversedPath(endNode);
  
            }

            foreach (Node neighbourNode in grid.GetNeighbours(currentNode))
            {
                if (closeList.Contains(neighbourNode))
                {
                    continue;
                }

                if (!neighbourNode.isTraversable)
                {
                    closeList.Add(neighbourNode);
                    continue;
                }

                int temporaryGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);

                if (temporaryGCost < neighbourNode.gCost)
                {
                    neighbourNode.previousNode = currentNode;
                    neighbourNode.gCost = temporaryGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }

            }

        }

        return null;
    }

    //Loops through the OpenList to fin the lowest F Cost Node
    //If 2 Nodes have the same F Cost, then the H Cost is compared instead
    private Node GetLowestFCostNode(List<Node> nodesList)
    {
        Node currentNode = nodesList[0];
        for (int i = 0; i < nodesList.Count; i++)
        {
            if (nodesList[i].fCost < currentNode.fCost || nodesList[i].fCost == currentNode.fCost && nodesList[i].hCost < currentNode.hCost)
            {
                currentNode = nodesList[i];
            }
        }
        return currentNode;
    }

    private List<Node> GetReversedPath(Node endNode)
    {
        List<Node> path = new List<Node>();
        path.Add(endNode);
        Node currentNode = endNode;
        while (currentNode.previousNode != null)
        {
            path.Add(currentNode.previousNode);
            currentNode = currentNode.previousNode;

        }
        path.Reverse();
        return path;
    }

    //Math
    private int CalculateDistanceCost(Node nodeA, Node nodeB)
    {
        int xDistance = (int)MathF.Abs(nodeA.xPosition - nodeB.xPosition);
        int yDistance = (int)MathF.Abs(nodeA.yPosition - nodeB.yPosition);
        int remaining = (int)MathF.Abs(xDistance - yDistance);

        return movementCostDiagonal * (int)MathF.Min(xDistance, yDistance) + movementCostStraight * remaining;
    }


}
