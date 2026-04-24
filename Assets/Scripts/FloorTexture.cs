using UnityEngine;

public class FloorTexture : MonoBehaviour
{
    private Mesh mesh;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        mesh = GetComponent<MeshFilter>().mesh;
        material.mainTextureScale = new Vector2(
            mesh.bounds.size.x * transform.localScale.x,
            mesh.bounds.size.z * transform.localScale.z
        );
    }
}
