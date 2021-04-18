using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkPrefab
{
    public GameObject Prefab;

    public string Path;

    public NetworkPrefab(GameObject obj, string path)
    {
        Prefab = obj;
        Path = ReturnPrefabPath(path);
    }

    private string ReturnPrefabPath(string path) {

        int extensionLength = System.IO.Path.GetExtension(path).Length;
        int startIndex = path.ToLower().IndexOf("resources");

        if (startIndex == -1)
        {
            return string.Empty;

        }
        else {
            return path.Substring(startIndex, path.Length - (startIndex + extensionLength));
        }

    }


}
