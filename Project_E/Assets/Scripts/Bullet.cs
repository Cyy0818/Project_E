using System;
using System.Collections;
using System.Collections.Generic;
using Attacker;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    private Transform target;
    public GameObject ExplosionEffectPrefab;

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);
        transform.Translate( Time.deltaTime * speed *Vector3.forward);
    }
    //用Collider和RigidBody检测子弹是否击中敌人
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<AttackerBase>().GetDamage(damage);
            GameObject.Instantiate(ExplosionEffectPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
