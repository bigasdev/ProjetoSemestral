using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public int gridX;
    public int gridY;
    public bool isWall;
    public Vector3 position;
    public Node parent;
    public int gCost;
    public int hCost;
    public int fCost {get {return gCost + hCost;}}
    public Node(bool _isWall, Vector3 a_Pos, int a_gridX, int a_gridY){
        isWall = _isWall;
        position = a_Pos;
        gridX = a_gridX;
        gridY = a_gridY;
    }

}
