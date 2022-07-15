using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    //bullet
    public List<GameObject> BulletsPooled;    
    public GameObject BulletToPool;    
    public int BulletAmountToPool;

    //fire element
    public List<GameObject> FiresPooled;
    public GameObject FireToPool;
    public int FireAmountToPool;

    //watter element
    public List<GameObject> WatersPooled;
    public GameObject WaterToPool;
    public int WaterAmountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        BulletsPooled = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < BulletAmountToPool; i++)
        {
            tmp = Instantiate(BulletToPool);
            tmp.SetActive(false);
            BulletsPooled.Add(tmp);
        }

        FiresPooled = new List<GameObject>();        
        for (int i = 0; i < FireAmountToPool; i++)
        {
            tmp = Instantiate(FireToPool);
            tmp.SetActive(false);
            FiresPooled.Add(tmp);
        }

        WatersPooled = new List<GameObject>();
        for (int i = 0; i < WaterAmountToPool; i++)
        {
            tmp = Instantiate(WaterToPool);
            tmp.SetActive(false);
            WatersPooled.Add(tmp);
        }
    }

    public GameObject GetBulletPooledObject()
    {
        for (int i = 0; i < BulletAmountToPool; i++)
        {
            if (!BulletsPooled[i].activeInHierarchy)
            {
                return BulletsPooled[i];
            }
        }
        return null;
    }

    public GameObject GetFireEffectPooledObject()
    {
        for (int i = 0; i < FireAmountToPool; i++)
        {
            if (!FiresPooled[i].activeInHierarchy)
            {
                return FiresPooled[i];
            }
        }
        return null;
    }

    public GameObject GetWaterEffectPooledObject()
    {
        for (int i = 0; i < WaterAmountToPool; i++)
        {
            if (!WatersPooled[i].activeInHierarchy)
            {
                return WatersPooled[i];
            }
        }
        return null;
    }
}
