using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWeaponBullet : MonoBehaviour
{
    public PlayerWeaponSine weapon; 
    bool canCos = false;
    public float speed;
    public float period;
    public float amplitude;

    // Start is called before the first frame update
    void Awake()
    {
        weapon = GameObject.FindWithTag("Player").GetComponent<PlayerWeaponSine>();
    }

    // Update is called once per frame
    void Update()
    {
        float sin;

        if(canCos)
        {
            sin = amplitude * Mathf.Cos((Mathf.PI / (2 * period)) * transform.position.x);
        }
        else
        {
            sin = amplitude * Mathf.Sin((Mathf.PI / (2 * period)) * transform.position.x);
        }

        transform.Translate(new Vector2(speed, sin) * Time.deltaTime);
    }
}
