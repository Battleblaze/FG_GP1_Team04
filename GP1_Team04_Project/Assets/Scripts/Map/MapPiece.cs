using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPiece : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPoint;

    [SerializeField]
    private MapPieceType _type;

    public Vector3 spawnPoint 
    {
        get { return this._spawnPoint.position; }
    }

    public MapPieceType type
    {
        get { return this._type; }
    }

    public Vector3 forward
    {
        get { return this._spawnPoint.forward; }
    }


    void Start() // For obstacle generation?
    {

    }
}

public enum MapPieceType
{
    Right,
    Left,
    Straight,
}
