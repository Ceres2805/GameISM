using UnityEngine.Rendering;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private void Start(){
        Vector2 randomPosition = new Vector2(Random.Range(minX,minY),Random.Range(maxX,maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

    }
    
}
