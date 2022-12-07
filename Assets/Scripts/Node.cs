using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    Grid grid;
    public int xPosition;
    public int yPosition;

    public int gCost;
    public int hCost;
    public int fCost;

    public Node previousNode;

    public Node(int xPosition, int yPosition)
    {
        //this.grid = grid;
        this.xPosition = xPosition;
        this.yPosition = yPosition;

    }

}
