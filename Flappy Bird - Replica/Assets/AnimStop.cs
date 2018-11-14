using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStop : MonoBehaviour {
    public float delay;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
