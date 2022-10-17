using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _mapPiecePrefabs;

    [SerializeField]
    private List<MapPiece> _placedPieces = new();

    [SerializeField]
    private float _xCutOffPoint = 20f;

    [SerializeField]
    private float _piecesToPlace = 5f;


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
        var randomPrefabIndex = Random.Range(0, _mapPiecePrefabs.Length - 1);

        GameObject newPiece = Instantiate(_mapPiecePrefabs[randomPrefabIndex], lastPlacedPieces.NextSpawnPoint, Quaternion.LookRotation(lastPlacedPieces.Forward, Vector3.up));
        _placedPieces.Add(newPiece.GetComponent<MapPiece>());
    }
}