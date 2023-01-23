using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshTransformerADV : MonoBehaviour
{
    public Mesh OriginalMesh;
    private Mesh pMesh;

    public void Init_pMesh()
    {
        
        pMesh = MeshTransformer.CloneMesh(OriginalMesh);
        

    }
    
}
