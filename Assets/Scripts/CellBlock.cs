using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBlock
{

    Color32 myColor = new Color32(153, 0, 153, 1);

    private float width;
    private float height;
    Vector3 position;
    GameObject cell;

    public CellBlock(float width, float height, Vector3 position, Color color)
    {
        this.width = width;
        this.height = height;
        this.position = position;

        cell = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cell.GetComponent<Renderer>().material.color = color;
        cell.transform.localScale = new Vector3(width, height, 0.05f);
        cell.transform.position = position;
    }

   

}
