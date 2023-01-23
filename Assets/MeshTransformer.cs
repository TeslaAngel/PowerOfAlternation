using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshTransformer : MonoBehaviour
{
    public Mesh OriginalMesh;
    private Mesh pMesh;

    private void OnEnable()
    {
        pMesh = CloneMesh(OriginalMesh);
        GetComponent<MeshFilter>().mesh = OriginalMesh;
        //DebugList();
    }

    private void Start()
    {
        //pMesh.vertices = AlternateV3Element(pMesh.vertices, 1, new Vector3(3, 3, 3));
        //SyncMeshFilter();
    }

    private void Update()
    {
        Vector3[] MV = pMesh.vertices;
        Vector3[] NV = pMesh.normals;
        for (int i = 0; i < MV.Length; i++)
        {
            MV[i] = Mathf.Sin(Time.time * Time.deltaTime)*0.01f * NV[i] + MV[i];
            //print(Mathf.Sin(Time.time * Time.deltaTime) * NV[i]);
        }
        pMesh.vertices = MV;
        SyncMeshFilter();
    }

    public static Vector3[] AlternateV3Element(Vector3[] Origin, int i, Vector3 Substitution)
    {
        Origin[i] = Substitution;
        return Origin;
    }
    public static Vector2[] AlternateV3Element(Vector2[] Origin, int i, Vector2 Substitution)
    {
        Origin[i] = Substitution;
        return Origin;
    }
    public static int[] AlternateV3Element(int[] Origin, int i, int Substitution)
    {
        Origin[i] = Substitution;
        return Origin;
    }

    public static Mesh CloneMesh(Mesh originalMesh)
    {
        Mesh clonedMesh = new Mesh();
        clonedMesh.name = "clone";
        clonedMesh.vertices = originalMesh.vertices;
        clonedMesh.triangles = originalMesh.triangles;
        clonedMesh.normals = originalMesh.normals;
        clonedMesh.uv = originalMesh.uv;
        return clonedMesh;
    }

    public void SyncMeshFilter()
    {
        GetComponent<MeshFilter>().mesh = pMesh;
    }

    public void DebugList()
    {
        string VAR = "Mesh Debug Log:\n";
        for(int i = 0; i < pMesh.vertices.Length; i++)
        {
            VAR += ("Ver-" + pMesh.vertices[i] + "\n");
        }
        for (int i = 0; i < pMesh.triangles.Length; i++)
        {
            VAR += ("Tri-" + pMesh.triangles[i] + "\n");
        }
        for (int i = 0; i < pMesh.normals.Length; i++)
        {
            VAR += ("normal-" + pMesh.normals[i] + "\n");
        }
        for (int i = 0; i < pMesh.uv.Length; i++)
        {
            VAR += ("uv-" + pMesh.uv[i] + "\n");
        }
        for (int i = 0; i < pMesh.tangents.Length; i++)
        {
            VAR += ("tangents-" + pMesh.uv[i] + "\n");
        }

        Debug.Log(VAR);
    }

}
