using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCreater : MonoBehaviour
{
    private ObjectPool objectPool;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    public void CreateWind(Vector2 mousePos, Vector2 dir)
    {
        GameObject windObj = objectPool.GetObject();
        windObj.transform.position = mousePos;
        windObj.transform.rotation = Quaternion.FromToRotation(Vector2.right, dir);
    }
}
