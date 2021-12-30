using System.Collections.Generic;
using UnityEngine.AI;

public class NavigationBaker {

    public static void BuildNavMesh(List<NavMeshSurface> surfaces)
    {
        foreach (var surface in surfaces)
        {
            surface.BuildNavMesh();
        }
    }
}