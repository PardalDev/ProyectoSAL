using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;
    public static GameSettings GameSettings { get { return instance._gameSettings; } }

    private List<NetworkPrefab> _networkPrefabs = new List<NetworkPrefab>();
    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation) {

                foreach (NetworkPrefab networkPrefab in instance._networkPrefabs) {

            if (networkPrefab.Prefab == obj) {
                if (networkPrefab.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkPrefab.Path, position, rotation);
                    return result;
                }
                else {
                    Debug.LogError("path is empry for gameobject name" + networkPrefab.Prefab);
                
                }
            }
        }

        return null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void PopulateNetworkPrefabs() {
        if (!Application.isEditor)
            return;

        GameObject[] results = Resources.LoadAll<GameObject>("");

        for (int i=0; i<results.Length; i++) {
            if (results[i].GetComponent<PhotonView>() != null) {
                /*string path = AssetDatabase.GetAssetPath(results[i]);
                instance._networkPrefabs.Add(new NetworkPrefab(results[i], path));*/
            }
        }

    }
}
