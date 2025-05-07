using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public float scanrange;
    public LayerMask targetlayer;
    public RaycastHit2D[] targets;
    public Transform selecttarget;

    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanrange, Vector2.zero, 0f, targetlayer);
        selecttarget = GetTarget();

    }
    Transform GetTarget()
    {
        Transform scantarget = null;
        float range = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector3 mypos = transform.position;
            Vector3 targetpos = target.transform.position;
            float distance = Vector3.Distance(mypos, targetpos);

            if (distance < range)
            {
                scantarget = target.transform;
                range = distance;
                scantarget = target.transform;
            }

        }

        return scantarget;
    }
}
