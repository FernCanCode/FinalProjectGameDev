using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public Animator anima;
    public float openRange;

    private PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerHealth.instance.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < openRange)
        {
            anima.SetBool("doorOpen", true);
        }
        else
        {
            anima.SetBool("doorOpen", false);
        }
    }
}
