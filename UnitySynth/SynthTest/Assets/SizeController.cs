using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    private float velUp = 0;
    private float velDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velUp = MidiJack.MidiMaster.GetKey(60);
        velDown = MidiJack.MidiMaster.GetKey(61);
        gameObject.transform.localScale += new Vector3(velUp, velUp, velUp);
        gameObject.transform.localScale -= new Vector3(velDown, velDown, velDown);
    }
}
