using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Pathfinding pathfinding;
    private Vector3 mouseWorldPosition;
    private Vector3 mousePosition;
    private Vector3 playerPosition;
    private List<Node> path;
    //private List<Vector3> vector3List;
    private float speed;
    private int index;

    void Start()
    {
        pathfinding = new Pathfinding(20, 12);
        playerPosition = pathfinding.grid.GetWorldPosition(pathfinding.grid.gridArray[5, 5].xPosition, pathfinding.grid.gridArray[5, 5].yPosition);
        gameObject.transform.position = new Vector3(playerPosition.x + pathfinding.grid.cellSize * 0.5f, playerPosition.y + pathfinding.grid.cellSize * 0.5f, 0);

        speed = 5;
        index = 0;
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
            pathfinding.grid.GetGridCordinates(playerPosition, out int playerGridPositionX, out int playerGridPositionY);
            path = pathfinding.FindPath(playerGridPositionX, playerGridPositionY, mouseGridPositionX, mouseGridPositionY);
            //vector3List = pathfinding.GetWorldPositionList(playerGridPositionX, playerGridPositionY, mouseGridPositionX, mouseGridPositionY);
            index = 0;

            for (int i = 0; i < path.Count - 1; i++)
            {
                Debug.DrawLine(path[i].worldPosition, path[i + 1].worldPosition, Color.green, 3);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Node[,] gridArray = pathfinding.grid.gridArray;
            pathfinding.grid.GetGridCordinates(mouseWorldPosition, out int x, out int y);
            gridArray[x, y].DisableTile();
        }

        if (path != null)
        {
            Vector3 targetPosition = path[index].worldPosition;
            if (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            }
            else
            {
                index++;
                if (index >= path.Count)
                {
                    path = null;
                    index = 0;

                }
            }
        }



    }


    //private void GetMouseGridCordinates(Vector3 worldPosition, out int mouseGridPositionX, out int mouseGridPositionY)
    //{
    //    pathfinding.grid.GetGridCordinates(worldPosition, out int x, out int y);
    //    mouseGridPositionX = x;
    //    mouseGridPositionY = y;

    //}
}
