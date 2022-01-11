using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPitch : MonoBehaviour
{

    public float maxPitch;
    public float minPitch;

    private AudioSource asou;
    private float myPitch;

    // Start is called before the first frame update
    void Start()
    {
        myPitch = Random.Range(minPitch, maxPitch);
        asou = GetComponent<AudioSource>();
        asou.pitch = myPitch;
    }
}
