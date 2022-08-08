#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

// Usage: Attach to an object, assign target gameobject (from where the mesh is taken), Run, Press savekey

public class SaveMeshInEditor : MonoBehaviour
{
    public string saveName = "SavedMesh";
    public Transform selectedGameObject;

    void Start()
    {
        StartCoroutine(WaitFunc());
    }

    IEnumerator WaitFunc() {
        yield return new WaitForSeconds(5);
        SaveAsset();
    }

    void SaveAsset()
    {
        var mf = selectedGameObject.GetComponent<MeshFilter>();
        if (mf)
        {
            var savePath = "Assets/" + saveName + ".asset";
            Debug.Log("Saved Mesh to:" + savePath);
            AssetDatabase.CreateAsset(mf.mesh, savePath);
        }
    }
}
#endif