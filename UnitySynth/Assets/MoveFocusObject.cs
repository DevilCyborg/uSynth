using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFocusObject : MonoBehaviour
{
	Rigidbody rb;
	public float speed = 5f;
	private float[] vel;
	AudioSource audioData;
	
	
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = false;
		vel = new float[33];
		audioData = GetComponent<AudioSource>();
	}
	
    // Update is called once per frame
    void FixedUpdate()
    {
		//checks for all MIDI keys
		vel[1] = MidiJack.MidiMaster.GetKey(41);
        vel[2] = MidiJack.MidiMaster.GetKey(42);
        vel[3] = MidiJack.MidiMaster.GetKey(43);
        vel[4] = MidiJack.MidiMaster.GetKey(44);
        vel[5] = MidiJack.MidiMaster.GetKey(45);
        vel[6] = MidiJack.MidiMaster.GetKey(46);
        vel[7] = MidiJack.MidiMaster.GetKey(47);
        vel[8] = MidiJack.MidiMaster.GetKey(48);
        vel[9] = MidiJack.MidiMaster.GetKey(49);
        vel[10] = MidiJack.MidiMaster.GetKey(50);
        vel[11] = MidiJack.MidiMaster.GetKey(51);
        vel[12] = MidiJack.MidiMaster.GetKey(52);
        vel[13] = MidiJack.MidiMaster.GetKey(53);
        vel[14] = MidiJack.MidiMaster.GetKey(54);
        vel[15] = MidiJack.MidiMaster.GetKey(55);
        vel[16] = MidiJack.MidiMaster.GetKey(56);
        vel[17] = MidiJack.MidiMaster.GetKey(57);
        vel[18] = MidiJack.MidiMaster.GetKey(58);
        vel[19] = MidiJack.MidiMaster.GetKey(59);
        vel[20] = MidiJack.MidiMaster.GetKey(60);
        vel[21] = MidiJack.MidiMaster.GetKey(61);
        vel[22] = MidiJack.MidiMaster.GetKey(62);
        vel[23] = MidiJack.MidiMaster.GetKey(63);
        vel[24] = MidiJack.MidiMaster.GetKey(64);
        vel[25] = MidiJack.MidiMaster.GetKey(65);
        vel[26] = MidiJack.MidiMaster.GetKey(66);
        vel[27] = MidiJack.MidiMaster.GetKey(67);
        vel[28] = MidiJack.MidiMaster.GetKey(68);
        vel[29] = MidiJack.MidiMaster.GetKey(69);
        vel[30] = MidiJack.MidiMaster.GetKey(70);
        vel[31] = MidiJack.MidiMaster.GetKey(71);
        vel[32] = MidiJack.MidiMaster.GetKey(72);
		
		
		foreach (float velocity in vel) {
			if (velocity > 0) audioData.Play(0);
		}
		
		
        rb.AddForce((vel[22]-vel[20]) * speed, 0, (vel[24]-vel[25]) * speed);
		
		if (vel[32] > 0f) gameObject.transform.position = new Vector3(0, 0.55f, -7);
	}
}
