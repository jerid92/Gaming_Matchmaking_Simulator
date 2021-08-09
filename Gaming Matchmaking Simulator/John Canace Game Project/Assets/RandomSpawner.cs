using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Placed on rect transfrom or panel
/// </summary>
public class RandomSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public float spawnEverySeconds = 2;
    public float timer;//readonly
    //public RectTransform PlayerPanel;
    //public float zPosition = -5.8f;
    //public int spawnRadius = 50;

    //multi spawn points
    public List<SpawnPoint> spawnPoints;
    //spawn needs : player - position - 

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;//0.02=dt
        if (timer > spawnEverySeconds)
        {
            timer = 0;

            GameObject player = Instantiate(playerPrefab);

            player.transform.SetParent(transform,false);

            SpawnPoint sp = spawnPoints[ Random.Range(0,spawnPoints.Count) ];

            Vector3 randomRadius = Random.insideUnitSphere * sp.radius;

            randomRadius.z = 0;

            player.transform.position = sp.position + randomRadius;

            //player.transform.position = transform.position + new Vector3(randomXY.x, randomXY.y, 0);


        }
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            SpawnPoint sp = spawnPoints[i];

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(sp.position,sp.radius);
        }


    }





}

[System.Serializable]
public class SpawnPoint
{
    public float radius;
    public Vector3 position;
    public Quaternion rotation;
}

