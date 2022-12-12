using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Pathfinding pathfinding;
    private Vector3 mousePosition;
    private Vector3 mouseWorldPosition;


    void Start()
    {
        pathfinding = new Pathfinding(10, 10);
        
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z * -1;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);


        if (Input.GetMouseButtonDown(0))
        {
            pathfinding.grid.GetGridCordinates(mouseWorldPosition, out int x, out int y);
            //Debug.Log(grid[x, y].uniqueID + ", " + grid[x, y].isTraversable);

            List<Node> path = pathfinding.FindPath(0, 0, x, y);
            for (int i = 0; i < path.Count - 1; i++)
            {
                Debug.DrawLine(path[i].worldPosition, path[i+1].worldPosition, Color.green, 10f);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Node[,] gridArray = pathfinding.grid.gridArray;
            pathfinding.grid.GetGridCordinates(mouseWorldPosition, out int x, out int y);
            gridArray[x, y].DisableTile();
        }
    }
}
