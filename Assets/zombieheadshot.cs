using UnityEngine;
using System.Collections;

public class zombieheadshot : MonoBehaviour {
    SkinnedMeshRenderer meshRenderer;
    MeshCollider meshcollider;
    // Use this for initialization
    void Start () {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        meshcollider = GetComponent<MeshCollider>();

	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 12)
        {
            transform.root.GetComponent<zombiemovement>().GetDamaged(45);
            Destroy(col.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update () {
        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh);
        meshcollider.sharedMesh = null;
        meshcollider.sharedMesh = colliderMesh;
    }
}
