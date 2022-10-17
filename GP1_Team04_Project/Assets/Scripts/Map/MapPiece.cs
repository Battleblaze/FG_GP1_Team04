using UnityEngine;

public class MapPiece : MonoBehaviour
{
    [SerializeField]
    private Transform _nextSpawnPoint;

    public Vector3 NextSpawnPoint
    {
        get { return _nextSpawnPoint.position; }
    }

    public Vector3 Forward
    {
        get { return _nextSpawnPoint.forward; }
    }
}