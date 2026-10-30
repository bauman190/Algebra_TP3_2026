using UnityEngine;

public class Vertex : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] vertices;

    void OnDrawGizmos()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.sharedMesh;
        vertices = mesh.vertices;
        Gizmos.color = Color.red;
        
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldVertexPos = transform.TransformPoint(vertices[i]);
            
            Gizmos.DrawSphere(worldVertexPos, 0.1f);
        }
    }
}
