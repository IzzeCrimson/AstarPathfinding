using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{

    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    //public GameObject cellBlock;

    public Grid(int width, int height, float cellSize) 
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width,height];

        // i = x
        // j = y
        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.red, Mathf.Infinity);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.red, Mathf.Infinity);
                //CellBlock cellBlock = new CellBlock(cellSize, cellSize, GetWorldPosition(i, j));

            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.red, Mathf.Infinity);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.red, Mathf.Infinity);

    }


    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,y) * cellSize;
    }

}
