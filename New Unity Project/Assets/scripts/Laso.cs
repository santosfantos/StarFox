﻿using UnityEngine;
using System.Collections;

public class Laso : MonoBehaviour
{
    
    private Vector2 target;
    //boolean if laso is going towords target or going away
    private bool goForword;
   
    // Use this for initialization
    void Start()
    {
        target = GameManager.targetLaso;
        goForword = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (goForword == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, GameManager.movmentSpeed * Time.deltaTime);
            Vector3 moveDirection = gameObject.transform.position - new Vector3(-30, -8, 0);
            if ((moveDirection != Vector3.zero) && (transform.position.x != target.x) && (transform.position.y != target.y))
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                
            }
            else { goForword = false; }

        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-30,-8), GameManager.movmentSpeed * Time.deltaTime);
            if (transform.position.x == -30)
            {
                Destroy(gameObject);
                GameManager.lasoGo = true;
            }
        }
      
    }
    //Wait function
    IEnumerator waitLaso()
    {
        yield return new WaitForSeconds(10);
    }
}
