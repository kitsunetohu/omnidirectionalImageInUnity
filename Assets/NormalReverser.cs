using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalReverser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] triangles = GetComponent<MeshFilter>().mesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }
        GetComponent<MeshFilter>().mesh.triangles = triangles;

    }
    // Update is called once per frame
    void Update()
    {

    }

}
