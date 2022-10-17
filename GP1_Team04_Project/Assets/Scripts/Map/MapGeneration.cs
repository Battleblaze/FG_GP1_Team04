using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _mapPiecePrefabs;

    [SerializeField]
    private List<MapPiece> _placedPieces;

    [SerializeField]
    private float _xCutOffPoint = 50f;

    [SerializeField]
    private int _piecesToPlace = 10;

    private void Awake()
    {
        if (_mapPiecePrefabs == null || _placedPieces == null)
        {
            Debug.LogError("You need to assign prefabs in MapGeneration.");
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < _placedPieces.Count; i++)
        {
            if (_placedPieces[i].gameObject.transform.position.x > _xCutOffPoint)
            {
                Destroy(_placedPieces[i].gameObject);
                _placedPieces.RemoveAt(i);
            }
        }

        if (_placedPieces.Count < _piecesToPlace)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        MapPiece lastPlacedPieces = _placedPieces[^1];
        var randomPrefabIndex = Random.Range(0, _mapPiecePrefabs.Length);

        GameObject newPiece = Instantiate(_mapPiecePrefabs[randomPrefabIndex], lastPlacedPieces.NextSpawnPoint, Quaternion.LookRotation(lastPlacedPieces.Forward, Vector3.up));
        _placedPieces.Add(newPiece.GetComponent<MapPiece>());
    }
}