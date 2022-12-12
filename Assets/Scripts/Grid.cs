using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{

    private int width;
    private int height;
    public float cellSize;
    public Node[,] gridArray;
    private int idCounter;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        idCounter = 1;

        gridArray = new Node[width, height];

        // i = x
        // j = y
        //Loops through the array to insantiate the nodes
        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                //Draws a line on the left side and bottom of each cell
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.red, Mathf.Infinity);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.red, Mathf.Infinity);

                gridArray[i, j] = new Node(i, j, cellSize, cellSize, GetWorldPosition(i, j) + new Vector3(cellSize, cellSize) * .5f, Color.grey);
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
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                //If x and y is equal to zero then we are standing on the current node
                if (x == 0 && y == 0)
                {
                    continue;
                }
                int neighbourPositionX = currentNode.xPosition + x;
                int neighbourPositionY = currentNode.yPosition + y;

                //If cordinates are outside of the grids boundry, ignore it
                if (neighbourPositionX >= 0 && neighbourPositionX < gridArray.GetLength(0) && neighbourPositionY >= 0 && neighbourPositionY < gridArray.GetLength(1))
                {
                    neighbours.Add(gridArray[neighbourPositionX, neighbourPositionY]);
                }
            }
        }

        return neighbours;
    }

    //Convert grid position to world position
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    //Convert WordlPosition to Grid cordinates
    public void GetGridCordinates(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);

    }

    public Node GetNode(int xPosition, int yPosition)
    {
        return gridArray[xPosition, yPosition];
    }
    //public int GetGridArrayLength
    //{

    //}

    //public Node[,] GetArray()
    //{
    //    return gridArray;
    //}



}
