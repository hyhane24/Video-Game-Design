using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{

    //public Animation ani;

    void OnTriggerEnter(Collider c) {


        if (c.attachedRigidbody != null) {
            BallCollector bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();
            if (bc != null) {
                EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
                //EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.localscale);
                
                //scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);

                transform.position = new Vector3(transform.position.x+1, 1,0); 
            
                //ani = c.attachedRigidbody.gameObject.GetComponent<Animation>();
                //ani.Play();
                //Instantiate(this.gameObject); 
                //transform.scale = new Vector3(transform.localscale.x + 1, transform.localscale.y + 1,transform.localscale.z + 1);        
                //bc.ReceiveBall();
            }
        }
    }
}



