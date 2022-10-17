using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    [SerializeField] private MapPiece[] straightPieces;
    [SerializeField] private int straightWeight = 60;
    [SerializeField] private MapPiece[] rightPieces;
    [SerializeField] private int rightWeight = 20;
    [SerializeField] private MapPiece[] leftPieces;
    [SerializeField] private int leftWeight = 20;
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private List<MapPiece> placedPieces = new List<MapPiece>();
    [SerializeField] private float zCutOffPoint;
    
    //[SerializeField] private MapPiece[] obstacle;
    [SerializeField] private int obstacleWeight;
    //[SerializeField] private MapPiece[] coinPickup;
    [SerializeField] private int coinWeight;
   // [SerializeField] private MapPiece[] healthPickup;
    [SerializeField] private int healthWeight;
    //[SerializeField] private Vector3 spawnPoint;
    [SerializeField] private List<MapPiece> placedPickups = new List<MapPiece>();

   [SerializeField] private GameObject obstacle;
   [SerializeField] private GameObject healthPickup;
   [SerializeField] private GameObject coinPickup;
   [SerializeField] private Vector3 spawnObstacle0;
   [SerializeField] private Vector3 spawnObstacle1;
   [SerializeField] private Vector3 spawnObstacle2;
   [SerializeField] private Vector3 spawnHealth0;
   [SerializeField] private Vector3 spawnHealth1;
   [SerializeField] private Vector3 spawnHealth2;
   [SerializeField] private Vector3 spawnCoin0;
   [SerializeField] private Vector3 spawnCoin1;
   [SerializeField] private Vector3 spawnCoin2;

   private int combinedWeight;

    // Start is called before the first frame update
    void Start()
    {
        this.combinedWeight = this.obstacleWeight + this.coinWeight + this.healthWeight;

        this.Generate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (this.placedPieces[0].gameObject.transform.position.x > this.zCutOffPoint)
        {
            Destroy(this.placedPieces[0].gameObject);
            this.placedPieces.RemoveAt(0);
        }
        
        if (this.placedPieces.Count < 5)
        {
            this.Generate();
            GeneratePickup();
        } else if (this.placedPieces.Count > 20)
        {
            Destroy(this.placedPieces[0].gameObject);
            this.placedPieces.RemoveAt(0);
        }
    }

    void Generate()
    {
        while(true)
        {
            var last = this.placedPieces[this.placedPieces.Count - 1];
            this.Spawn(last.spawnPoint, last.forward, MapPieceType.Straight);
            return;

            if (last.type != MapPieceType.Straight) // To not get two turns in a row
            {
                this.Spawn(last.spawnPoint, last.forward, MapPieceType.Straight);
                return;
            }

            var rand = Random.Range(0, this.combinedWeight - 1);

            if (rand < this.straightWeight) // Generate until next turn
            {
                this.Spawn(last.spawnPoint, last.forward, MapPieceType.Straight);
                continue;
            } else if (rand < this.straightWeight + this.rightWeight)
            {
                this.Spawn(last.spawnPoint, last.forward, MapPieceType.Right);
                return;
            } else if (rand < this.straightWeight + this.rightWeight + this.leftWeight)
            {
                this.Spawn(last.spawnPoint, last.forward, MapPieceType.Left);
                return;
            }
        }
    }
    void GeneratePickup()
    {
        var rand = Random.Range(0, 100);
            if (rand < 45) // Generate until next turn
            {
                SpawnObstacle();
                
            }
            if (rand < 90 && rand > 45)
            {
                SpawnCoinPickup();
                
            }
            if (rand > 90)
            {
                SpawnHealthPickup();
                
            }
    }

    void Spawn(Vector3 position, Vector3 forward, MapPieceType type)
    {
        MapPiece prefab;
        if (type == MapPieceType.Right)
        {
            var rand = Random.Range(0, this.rightPieces.Length - 1);
            prefab = this.rightPieces[rand];
        }
        else if (type == MapPieceType.Left)
        {
            var rand = Random.Range(0, this.leftPieces.Length - 1);
            prefab = this.leftPieces[rand];
        }
        else if (type == MapPieceType.Straight)
        {
            var rand = Random.Range(0, this.straightPieces.Length - 1);
            prefab = this.straightPieces[rand];
        }
        else 
        {
            return;
        }

        var newPiece = GameObject.Instantiate(prefab.gameObject, position, Quaternion.LookRotation(forward, Vector3.up));

        this.placedPieces.Add(newPiece.GetComponent<MapPiece>());
    }

    void SpawnHealthPickup()
    {
        var newSpawn = Instantiate(healthPickup, this.placedPieces[placedPieces.Count-1].gameObject.transform);
        int randspawn = Random.Range(0, 3);
        Debug.Log(randspawn);
        if (randspawn == 0)
        {
            newSpawn.transform.position = spawnHealth0;
        }
        else if (randspawn == 1)
        {
            newSpawn.transform.position = spawnHealth1;
        }
        else if (randspawn == 2)
        {
            newSpawn.transform.position = spawnHealth2;
        }
        //this.placedPieces.Add(newSpawn.GetComponent<MapPiece>());
    }
    void SpawnCoinPickup()
    {
        var newSpawn = Instantiate(coinPickup, this.placedPieces[placedPieces.Count-1].gameObject.transform);
        int randspawn = Random.Range(0, 3);
        if (randspawn == 0)
        {
            newSpawn.transform.position = spawnCoin0;
        }
        else if (randspawn == 1)
        {
            newSpawn.transform.position = spawnCoin1;
        }
        else if (randspawn == 2)
        {
            newSpawn.transform.position = spawnCoin2;
        }
        //this.placedPieces.Add(newSpawn.GetComponent<MapPiece>());
    }
    void SpawnObstacle()
    {
        var newSpawn = Instantiate(obstacle, this.placedPieces[placedPieces.Count-1].gameObject.transform);
        int randspawn = Random.Range(0, 3);
        if (randspawn == 0)
        {
            newSpawn.transform.position = spawnObstacle0;
        }
        else if (randspawn == 1)
        {
            newSpawn.transform.position = spawnObstacle1;
        }
        else if (randspawn == 2)
        {
            newSpawn.transform.position = spawnObstacle2;
        }
    }
}