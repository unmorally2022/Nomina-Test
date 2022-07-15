using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCannon : MonoBehaviour
{
    [SerializeField]
    private int CurrentElement = 0;

    [SerializeField]
    private Transform BulletStartTransform;

    [SerializeField]
    Material[] materials;//0 fire 1 water/ 2 soil

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeElemt() {
        if (CurrentElement < 2)
        {
            CurrentElement += 1;
        }
        else {
            CurrentElement = 0;
        }
    }

    public void TembakDIAAAAA() {

        GameObject bullet = ObjectPool.SharedInstance.GetBulletPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = BulletStartTransform.transform.position;
            bullet.transform.rotation = BulletStartTransform.transform.rotation;
            bullet.SetActive(true);

            bullet.GetComponent<Bullet>().Init(CurrentElement, materials[CurrentElement]);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * AppManager.BulletSpeed;

        }
    }
}
