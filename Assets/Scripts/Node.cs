using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
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

    //Used for debugging to check if the grid was working
    public int uniqueID;

    private GameObject cube;
    public Vector3 worldPosition;
    private float cubeWidth;
    private float cubeHeight;


    

    public Node previousNode;

    public Node(int xPosition, int yPosition, float cubeWidth, float cubeHeight, Vector3 worldPosition, Color cubeColor)
    {

        this.xPosition = xPosition;
        this.yPosition = yPosition;

        isTraversable = true;
        uniqueID = 0;

        this.worldPosition = worldPosition;
        this.cubeWidth = cubeWidth;
        this.cubeHeight = cubeHeight;
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = worldPosition;
        cube.transform.localScale = new Vector3(cubeWidth, cubeHeight, 0.05f);
        cube.GetComponent<Renderer>().material.color = cubeColor;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
        
    }

    public void DisableTile()
    {
        isTraversable = !isTraversable;
        if (isTraversable)
        {
            cube.GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            cube.GetComponent<Renderer>().material.color = Color.black;

        }
    }

}
