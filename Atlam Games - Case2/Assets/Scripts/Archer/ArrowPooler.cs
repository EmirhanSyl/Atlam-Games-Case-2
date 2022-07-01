using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPooler : MonoBehaviour
{

    public static ArrowPooler instance;

    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject arrowsStorageObject;

    public Queue<GameObject> arrowPool = new Queue<GameObject>();

    void Start()
    {
        instance = this;

        for (int i = 0; i < 40; i++)
        {
            var projectiles = Instantiate(arrowPrefab);
            projectiles.transform.parent = arrowsStorageObject.transform;
            arrowPool.Enqueue(projectiles);
            projectiles.SetActive(false);
        }
    }

    public void AddPool(GameObject projectile)
    {
        arrowPool.Enqueue(projectile);
    }

    public GameObject CreateProjectile(Vector3 position, Quaternion rotation)
    {
        var projectile = arrowPool.Dequeue();
        projectile.transform.position = position;
        projectile.transform.rotation = rotation;
        projectile.SetActive(true);
        return projectile;
    }
}
