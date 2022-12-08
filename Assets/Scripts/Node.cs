using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    Grid grid;
    public int xPosition;
    public int yPosition;

    public bool isTraversable;
    public int gCost;
    public int hCost;
    public int fCost;

    public int uniqueID;

    public Node previousNode;

    public Node(int xPosition, int yPosition)
    {
        //this.grid = grid;
        this.xPosition = xPosition;
        this.yPosition = yPosition;

        isTraversable = true;
        uniqueID = 0;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
        
    }

}
