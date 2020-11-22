using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    [SerializeField]
    NavMeshSurface[] list;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        while (i < list.Length)
        {
            NavMeshSurface A = list[i];
            A.BuildNavMesh();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
