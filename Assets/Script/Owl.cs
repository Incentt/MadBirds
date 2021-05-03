using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : Bird
{
    public float radius;
    public float power;
    public float torque;
    public bool _hasBoost = false;
    public GameObject Explotion_Object;
    public override void OnTap()
    {
        Explotion();
    }

    void Explotion()
    {
        Vector3 explotionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explotionPos, radius);
        foreach (Collider2D hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            if (rb != null && !_hasBoost)
            {
                rb.AddRelativeForce(explotionPos * power, ForceMode2D.Impulse);
                rb.AddTorque(torque, ForceMode2D.Impulse);
                _hasBoost = true;
                Instantiate(Explotion_Object, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
