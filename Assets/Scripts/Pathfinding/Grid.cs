using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform startPos;
    public LayerMask wallMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float distance;
    public Node[,] grid;
    public List<Node> finalPath;
    float nodeDiameter;
    int gridSizeX, gridSizeY;
    public Transform npcPosition;

    private void Awake() {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
        CreateGrid();
    }

    void CreateGrid(){
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2
        - Vector3.up * gridWorldSize.y / 2;

        for(int x = 0; x < gridSizeX; x++){
            for(int y = 0; y < gridSizeY; y++){
                Vector3 worldPoint = bottomLeft + Vector3.right * (x*nodeDiameter+nodeRadius)
                + Vector3.up*(y*nodeDiameter+nodeRadius);
                bool wall = false;
                Vector2 radius = new Vector2(nodeRadius, nodeRadius);
                if(Physics2D.OverlapBox(worldPoint, radius, 90, wallMask)){
                    wall = true;
                }
                grid[x, y] = new Node(wall, worldPoint, x, y);
            }
        } 
    }
    public Node NodeFromWorldPosition(Vector3 worldPos){
        float xPoint = (worldPos.x + gridSizeX / 2) / gridWorldSize.x;
        float yPoint = (worldPos.y + gridSizeY/ 2) / gridWorldSize.y;
        xPoint = Mathf.Clamp01(xPoint);
        yPoint = Mathf.Clamp01(yPoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xPoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * yPoint);

        return grid[x,y];
    }
    public List<Node> GetNeighboringNodes(Node node){
        List<Node> neighboringNods = new List<Node>();
        int xCheck;
        int yCheck;

        xCheck = node.gridX + 1;
        yCheck = node.gridY;
        if(xCheck >= 0 && xCheck < gridSizeX){
            if(yCheck >= 0 && yCheck < gridSizeY){
                neighboringNods.Add(grid[xCheck, yCheck]);
            }
        }

        xCheck = node.gridX - 1;
        yCheck = node.gridY;
        if(xCheck >= 0 && xCheck < gridSizeX){
            if(yCheck >= 0 && yCheck < gridSizeY){
                neighboringNods.Add(grid[xCheck, yCheck]);
            }
        }

        xCheck = node.gridX;
        yCheck = node.gridY + 1;
        if(xCheck >= 0 && xCheck < gridSizeX){
            if(yCheck >= 0 && yCheck < gridSizeY){
                neighboringNods.Add(grid[xCheck, yCheck]);
            }
        }

        xCheck = node.gridX;
        yCheck = node.gridY - 1;
        if(xCheck >= 0 && xCheck < gridSizeX){
            if(yCheck >= 0 && yCheck < gridSizeY){
                neighboringNods.Add(grid[xCheck, yCheck]);
            }
        }
        return neighboringNods;
    }
    /*private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x,gridWorldSize.y, 1));
        if(grid != null){
            Node npcNode = NodeFromWorldPosition(npcPosition.position);
            foreach(Node node in grid){
                if(node.isWall){
                    Gizmos.color = Color.yellow;
                }
                else{
                    Gizmos.color = Color.white;
                }
                if(npcNode == node){
                    Gizmos.color = Color.cyan;
                }

                /*if(finalPath != null){
                    Gizmos.color = Color.red;
                }*/

                /*Gizmos.DrawCube(node.position, Vector3.one * (nodeDiameter -.1f));
            }
        }
    }*/
}
