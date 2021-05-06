﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();

        Invoke("Think", 3);

    }
    
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Plant"));
        if (rayHit.collider != null)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke("Think", 3);
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);


    }
}
