using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Path : MonoBehaviour
{
    public Color lineColor;

    private List<Transform> nodes = new List<Transform>();



    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        nodes = new List<Transform>();
        foreach (Transform child in transform)
            nodes.Add(child);        
        
        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 _currentNode = nodes[i].position;
            Vector3 _previousNode = nodes[i].position;
            if (i > 0)
                _previousNode = nodes[i - 1].position;
            //else if (i == 0 && nodes.Count > 1)
            //    _previousNode = nodes[nodes.Count - 1].position;

            Gizmos.DrawLine(_previousNode, _currentNode);
        }

    }
}
