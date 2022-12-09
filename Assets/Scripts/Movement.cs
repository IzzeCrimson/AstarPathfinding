using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Pathfinding pathfinding;
    Vector3 mouseWorldPosition;
    Vector3 mousePosition;
    Vector3 playerPosition;

    void Start()
    {
        pathfinding = new Pathfinding(10, 10);
        gameObject.transform.position = pathfinding.grid.GetWorldPosition(pathfinding.grid.gridArray[0, 0].xPosition, pathfinding.grid.gridArray[0, 0].yPosition);
    }

    
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z * -1;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        playerPosition = gameObject.transform.position;
        playerPosition.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            pathfinding.grid.GetGridCordinates(mouseWorldPosition, out int mouseGridPositionX, out int mouseGridPositionY);
            pathfinding.grid.GetGridCordinates(playerPosition, out int playerGridPositionX, out int playerPositionY);
            pathfinding.FindPath(playerGridPositionX, playerPositionY, mouseGridPositionX, mouseGridPositionY);

        }
    }

    //private void GetMouseGridCordinates(Vector3 worldPosition, out int mouseGridPositionX, out int mouseGridPositionY)
    //{
    //    pathfinding.grid.GetGridCordinates(worldPosition, out int x, out int y);
    //    mouseGridPositionX = x;
    //    mouseGridPositionY = y;

    //}
}
