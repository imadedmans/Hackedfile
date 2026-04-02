using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTime : MonoBehaviour
{
    public float timeBeforeDestroy = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimingEnum());
    }

    IEnumerator TimingEnum()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(gameObject);
    }
}
