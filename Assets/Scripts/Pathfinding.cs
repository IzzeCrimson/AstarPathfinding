using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{

    public Grid grid;

    private List<Node> openList;
    private List<Node> closeList;

    public Pathfinding(int width, int height)
    {

        grid = new Grid(width, height, 1);

    }

    private List<Node> FindPath(int startX, int startY, int endX, int endY)
    {
        Node startNode = grid.GetNode(startX, startY);
        Node endNode = grid.GetNode(endX, endY);

        openList = new List<Node> {startNode };
        closeList = new List<Node>();


    }

}
