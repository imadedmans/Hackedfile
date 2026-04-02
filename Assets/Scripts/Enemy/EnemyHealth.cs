using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject parent;
    public DebugTrigger allowHackability; 

    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        health -= damage;
        
        if(health == 0)
        {
            if(allowHackability != null)
            {
                allowHackability.AudioPlayAndGameObjectDelete();
                Debug.Log("Hey!");
                Death();
            }
            else
            {
                Death();
            }
        }
    }

    public void Death()
    {
        Destroy(parent);
        // This should be the object's parent
    }
}
