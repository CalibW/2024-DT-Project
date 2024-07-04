using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proijectile : MonoBehaviour
{
    public GameObject impactVFX;
    public float impactidie;
    private bool collided;

    void OnCollisionEnter(Collision co)
    {
        if(co.gameObject.tag !="FireBall" && co.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            var impact = Instantiate (impactVFX, co.contacts[0].point, Quaternion.identity) as GameObject;
            Destroy (impact, impactidie);
            Destroy (gameObject);
        }
    }
}
