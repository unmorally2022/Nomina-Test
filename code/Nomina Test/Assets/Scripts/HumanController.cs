using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{

    [SerializeField]
    GameObject TurretChild;

    [SerializeField]
    WeaponCannon Turret;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            Turret.TembakDIAAAAA();


        if (Input.GetMouseButtonDown(0))
            Turret.changeElemt();
    }

    private void FixedUpdate()
    {

        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = TurretChild.transform.position.z;
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldSpace.z = TurretChild.transform.position.z;

        Vector2 targetPosition = mouseWorldSpace;
        Vector2 DeltaDistance = targetPosition - (Vector2)TurretChild.transform.position;
        float direction = Mathf.Atan2(DeltaDistance.y, DeltaDistance.x) * Mathf.Rad2Deg - 90;
        Quaternion quaternion = Quaternion.AngleAxis(direction, Vector3.forward);

        TurretChild.transform.rotation = quaternion;
        ////////////
         
    }
}
