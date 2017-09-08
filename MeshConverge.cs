#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(MeshFilter))]
public class MeshConverge : MonoBehaviour {
    public MeshFilter[] meshFilters;
    public CombineInstance[] combine;
    // Use this for initialization
    void Start()
    {
        meshFilters= GetComponentsInChildren<MeshFilter>();
        combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        AssetDatabase.CreateAsset(GetComponent<MeshFilter>().mesh, "Assets/" + name + ".asset");
        transform.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
#endif