using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Pathfinding pathfinding;
    private Vector3 mousePosition;
    private Vector3 mouseWorldPosition;
    private GameObject cube;

    void Start()
    {
        pathfinding = new Pathfinding(5, 5);
        //cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.GetComponent<Renderer>().material.color = Color.blue;
        //cube.transform.localScale = new Vector3(.1f, .1f, .1f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 4.9f;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Node[,] grid = pathfinding.grid.GetArray();
            pathfinding.GetGrid().GetGridXY(mouseWorldPosition, out int x, out int y);
            Debug.Log(grid[x, y].uniqueID);
            List<Node> path = pathfinding.FindPath(0, 0, x, y);

            //for (int i = 0; i < path.Count; i++)
            //{
            //    Debug.DrawLine(new Vector3(path[i].xPosition, path[i].yPosition) * 5 + Vector3.one * 1f, new Vector3(path[i+1].xPosition, path[i].yPosition) * 5 + Vector3.one * 1f, Color.green, 100f);
            //}
        }
        //cube.transform.position = mouseWorldPosition;
    }
}
