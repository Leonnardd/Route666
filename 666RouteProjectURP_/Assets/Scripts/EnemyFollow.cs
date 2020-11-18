using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private float speed = 30, rotatingSpeed = 8;

    private GameObject target;
    private Rigidbody mybody;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null){
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        Vector3 pointTarget = transform.position - target.transform.position;
        pointTarget.Normalize();

        float value = Vector3.Cross(pointTarget, transform.forward).y;

        mybody.angularVelocity = rotatingSpeed * value * new Vector3(0,1,0);
        mybody.velocity = transform.forward*speed;
    }
}
