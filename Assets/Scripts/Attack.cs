﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    static GameObject NearTarget(Vector2 position, Collider2D[] array)
    {
        Collider2D current = null;
        float dist = Mathf.Infinity;

        foreach (Collider2D coll in array)
        {
            float curDist = Vector2.Distance(position, coll.transform.position);

            if (curDist < dist)
            {
                current = coll;
                dist = curDist;
            }
        }

        return (current != null) ? current.gameObject : null;
    }
    public static void Action(Vector2 point, float radius, int layerMask, float damage, bool allTargets)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);

        if (!allTargets)
        {
            GameObject obj = NearTarget(point, colliders);
            if (obj != null && obj.GetComponent<Enemy>())
            {
                obj.GetComponent<Enemy>().HP -= damage;
            }
            return;
        }

        foreach (Collider2D hit in colliders)
        {
            if (hit.GetComponent<Enemy>())
            {
                hit.GetComponent<Enemy>().HP -= damage;
            }
        }
    }
}
