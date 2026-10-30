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
            Vector3 normal = Normal(CrossProduct(lado1, lado2));

            Debug.DrawRay(centroPlano, normal * 2, Color.blue, 10f);
        }
    }

    Vector3 CrossProduct(Vector3 p1, Vector3 p2)
    {
        return new Vector3(p1.y * p2.z - p1.z * p2.y, p1.z * p2.x - p1.x * p2.z, p1.x * p2.y - p1.y * p2.x);
    }

    Vector3 Normal(Vector3 p)
    {
        float distancia = Mathf.Sqrt(p.x * p.x + p.y * p.y + p.z * p.z);
        
        return new Vector3(p.x / distancia, p.y / distancia, p.z / distancia);
    }
}
