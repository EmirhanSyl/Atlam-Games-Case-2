using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPooler : MonoBehaviour
{

    public static LogPooler Instance;

    [SerializeField] private GameObject logPrefab;
    [SerializeField] private GameObject logsMainObject;
    
    private Queue<GameObject> logQueue = new Queue<GameObject>();

    void Start()
    {
        Instance = this;

        for (int i = 0; i < 48; i++)
        {
            var log = Instantiate(logPrefab);
            log.transform.parent = logsMainObject.transform;
            log.SetActive(false);
            logQueue.Enqueue(log);
        }
    }

    public void AddPool(GameObject log)
    {
        logQueue.Enqueue(log);
    }

    public GameObject CreateObject(Vector3 position, Quaternion rotation)
    {
        var log = logQueue.Dequeue();
        log.transform.position = position;
        log.transform.rotation = rotation;
        log.SetActive(true);
        return log;
    }
}
