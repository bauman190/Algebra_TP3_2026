using System;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] vertices;
    int[] indices;


    void OnDrawGizmos()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.sharedMesh;
        vertices = mesh.vertices;
        indices = mesh.triangles;
        Gizmos.color = Color.red;
        
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldVertexPos = transform.TransformPoint(vertices[i]);
            
            Gizmos.DrawSphere(worldVertexPos, 0.1f);
        }

        for (int i = 0; i < indices.Length; i += 3)
        {
            int indiceA = indices[i];
            int indiceB = indices[i + 1];
            int indiceC = indices[i + 2];

            Vector3 puntoA = vertices[indiceA];
            Vector3 puntoB = vertices[indiceB];
            Vector3 puntoC = vertices[indiceC];
            
            Vector3 mundoA = transform.TransformPoint(puntoA);
            Vector3 mundoB = transform.TransformPoint(puntoB);
            Vector3 mundoC = transform.TransformPoint(puntoC);
            
            Debug.DrawLine(mundoA, mundoB, Color.green, 10f);
            Debug.DrawLine(mundoB, mundoC, Color.green, 10f);
            Debug.DrawLine(mundoC, mundoA, Color.green, 10f);
            
            Vector3 centroPlano = (mundoA + mundoB + mundoC) / 3f;

            Vector3 lado1 = mundoB - mundoA;
            Vector3 lado2 = mundoC - mundoA;
            Vector3 normal = Vector3.Cross(lado1, lado2).normalized;

            Debug.DrawRay(centroPlano, normal * 2, Color.blue, 10f);
        }
    }
}
