using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int element = -1;
    int lifeAmmount = 3;
    [SerializeField]
    Rigidbody rBody;

    public void Init(int ElementType, Material material)
    {
        element = ElementType;
        lifeAmmount = 3;
        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
        meshRenderer.material = material;

        if (ElementType == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (ElementType == 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide" + collision.gameObject.tag);
        ContactPoint contact = collision.contacts[0];
        Vector3 newDirection = Vector3.Reflect(transform.forward, contact.normal);

        transform.rotation = Quaternion.LookRotation(newDirection);

        if (collision.gameObject.tag == "Limit")
        {
            //ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.LookRotation(contact.normal);

            if (collision.gameObject.name == "top")
            {
                Vector3 rot1 = rot.eulerAngles;
                rot1 = new Vector3(rot.x + 90, rot.y + 90, rot.z + 180);
                rot = Quaternion.Euler(rot1);
            }
            else if (collision.gameObject.name == "bottom")
            {
                Vector3 rot1 = rot.eulerAngles;
                rot1 = new Vector3(rot.x + -90, rot.y + 90, rot.z + 180);
                rot = Quaternion.Euler(rot1);
            }

            switch (element)
            {
                case 0:
                    GameObject fireEffect = ObjectPool.SharedInstance.GetFireEffectPooledObject();
                    if (fireEffect != null)
                    {
                        fireEffect.transform.position = contact.point;
                        fireEffect.transform.rotation = rot;
                        fireEffect.SetActive(true);
                        fireEffect.GetComponent<HideCounter>().init();
                    }
                    rBody.velocity = transform.forward * AppManager.BulletSpeed;
                    break;
                case 1:
                    GameObject waterEffect = ObjectPool.SharedInstance.GetWaterEffectPooledObject();
                    if (waterEffect != null)
                    {
                        waterEffect.transform.position = contact.point;
                        waterEffect.transform.rotation = rot;
                        waterEffect.SetActive(true);
                        waterEffect.GetComponent<HideCounter>().init();
                    }
                    rBody.velocity = Vector3.zero;
                    rBody.velocity = transform.forward * AppManager.BulletSpeed;
                    break;
                case 2:
                    //rBody.velocity = rBody.velocity * 0.7f;
                    rBody.velocity = transform.forward * (lifeAmmount * (AppManager.BulletSpeed * 0.2f));

                    break;
            }

        }
        else
        {
            rBody.velocity = transform.forward * 160;
        }

        Debug.Log(rBody.velocity);

        lifeAmmount -= 1;
        if (lifeAmmount < 0)
        {
            rBody.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }

    }
}
