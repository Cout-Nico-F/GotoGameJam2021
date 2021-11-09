using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    static int number = 0;

    private void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        var a = PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
        number++;
        a.name = "Player " + number.ToString();
    }
}
