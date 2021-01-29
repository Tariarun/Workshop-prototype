using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public List<Vector3Int> children; //used to stock childrens position
    public Vector3Int position; //used to stock himself's position
    public Node parent; //usesd to set his parent for reverse pathfinding
    public bool usable;
    public GameObject objecton;

    public Node(List<Vector3Int> children,Vector3Int position, Node parent, bool usable, GameObject objecton) //constructor of Node class
    {
        this.children = children;
        this.position = position;
        this.parent = parent;
        this.usable = usable;
        this.objecton = objecton;
    }
    
    
}
