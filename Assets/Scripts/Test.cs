using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Pathfinding pathfinding;
    public int x, y;

    void Start()
    {
        pathfinding = new Pathfinding(5, 5);
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pathfinding.grid.GetNode(x, y);
        }
    }
}
