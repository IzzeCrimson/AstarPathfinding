using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{

    private int width;
    private int height;
    private float cellSize;
    private Node[,] gridArray;
    private int idCounter;

    //public GameObject cellBlock;

    public Grid(int width, int height, float cellSize) 
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        idCounter = 0;

        gridArray = new Node[width,height];

        // i = x
        // j = y
        //Loops through the array
        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                //Draws a line on the left side and bottom of each cell
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.red, Mathf.Infinity);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.red, Mathf.Infinity);

                CellBlock cellBlock = new CellBlock(cellSize, cellSize, GetWorldPosition(i, j) + new Vector3(cellSize, cellSize) * .5f, Color.white);
                gridArray[i, j] = new Node(i, j);
                gridArray[i, j].uniqueID = idCounter;
                idCounter++;

            }
        }
        //Draws a line on top of the whole grid and to the right of the grid
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.red, Mathf.Infinity);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.red, Mathf.Infinity);

    }

    public List<Node> GetNeighbours(Node currentNode)
    {
        List<Node> neighbours = new List<Node>();
        //Loop through all 9 nodes next to currentNode
        for (int i = -1; i < 1; i++)
        {
            for (int j = -1; j < 1; j++)
            {
                //If i and j is equal to zero then we are standing on the current node
                if (i != 0 && j != 0)
                {
                    int neighbourPositionX = currentNode.xPosition + i;
                    int neighbourPositionY = currentNode.yPosition + j;

                    if (neighbourPositionX >= 0 && neighbourPositionX < width && neighbourPositionY >= 0 && neighbourPositionY < height)
                    {
                        neighbours.Add(gridArray[neighbourPositionX, neighbourPositionY]);
                    }
                }
            }
        }

        return neighbours;
    }
    
    //Convert grid position to world position
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,y) * cellSize;
    }

    public void GetGridXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
        
    } 

    public Node GetNode(int xPosition, int yPosition)
    {
        return gridArray[xPosition, yPosition];
    }

    public Node[,] GetArray()
    {
        return gridArray;
    }

    

}
