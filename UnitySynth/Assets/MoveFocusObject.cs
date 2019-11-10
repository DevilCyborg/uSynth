using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFocusObject : MonoBehaviour
{
	Rigidbody rb;
	public float speed = 5f;
	private float[] vel;
	private bool[] press;
	private bool[] sans;
	AudioSource audioData;
	public AudioClip megalovania;
	public AudioClip bruh;
	public AudioClip woosh;
	public AudioClip slap;
	public AudioClip kurwa;
	public AudioClip wow;
	public AudioClip hurt;
	public AudioClip hellothere;
	public AudioClip boneless;
	public AudioClip metalgear;
	public AudioClip sanic;
	public AudioClip sure;
	private bool invert;
	
	
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = false;
		vel = new float[34];
		press = new bool[33];
		sans = new bool[10];
		for (int i = 0; i < sans.Length; i++){
			sans[i] = false;
		}
		invert = false;
		audioData = GetComponent<AudioSource>();
	}
	
    // Update is called once per frame
    void FixedUpdate()
    {
		//checks for all MIDI keys
		press[1] = MidiJack.MidiMaster.GetKeyDown(41);
        press[2] = MidiJack.MidiMaster.GetKeyDown(42);
        press[3] = MidiJack.MidiMaster.GetKeyDown(43);
        press[4] = MidiJack.MidiMaster.GetKeyDown(44);
        press[5] = MidiJack.MidiMaster.GetKeyDown(45);
        press[6] = MidiJack.MidiMaster.GetKeyDown(46);
        press[7] = MidiJack.MidiMaster.GetKeyDown(47);
        press[8] = MidiJack.MidiMaster.GetKeyDown(48);
        press[9] = MidiJack.MidiMaster.GetKeyDown(49);
        press[10] = MidiJack.MidiMaster.GetKeyDown(50);
        press[11] = MidiJack.MidiMaster.GetKeyDown(51);
        press[12] = MidiJack.MidiMaster.GetKeyDown(52);
        press[13] = MidiJack.MidiMaster.GetKeyDown(53);
        press[14] = MidiJack.MidiMaster.GetKeyDown(54);
        press[15] = MidiJack.MidiMaster.GetKeyDown(55);
        press[16] = MidiJack.MidiMaster.GetKeyDown(56);
        press[17] = MidiJack.MidiMaster.GetKeyDown(57);
        press[18] = MidiJack.MidiMaster.GetKeyDown(58);
        press[19] = MidiJack.MidiMaster.GetKeyDown(59);
        press[20] = MidiJack.MidiMaster.GetKeyDown(60); 
        press[21] = MidiJack.MidiMaster.GetKeyDown(61);
        press[22] = MidiJack.MidiMaster.GetKeyDown(62);
        press[23] = MidiJack.MidiMaster.GetKeyDown(63);
        press[24] = MidiJack.MidiMaster.GetKeyDown(64);
        press[25] = MidiJack.MidiMaster.GetKeyDown(65);
        press[26] = MidiJack.MidiMaster.GetKeyDown(66);
        press[27] = MidiJack.MidiMaster.GetKeyDown(67);
        press[28] = MidiJack.MidiMaster.GetKeyDown(68);
        press[29] = MidiJack.MidiMaster.GetKeyDown(69);
        press[30] = MidiJack.MidiMaster.GetKeyDown(70);
        press[31] = MidiJack.MidiMaster.GetKeyDown(71);
        press[32] = MidiJack.MidiMaster.GetKeyDown(72);
		
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
        vel[33] = MidiJack.MidiMaster.GetKnob(1,0);
		
		foreach (float velocity in vel) {
			if (velocity > 0) audioData.Play(0);
		}
		
		foreach (bool pressed in press) {
			if (pressed) Megalovania(press, pressed);
		}
		
		if (invert){
			rb.AddForce((vel[20]-vel[22]) * speed, 0, (vel[25]-vel[24]) * speed);
		} else {
			rb.AddForce((vel[22]-vel[20]) * speed, 0, (vel[24]-vel[25]) * speed);
		}
		
		if (vel[32] > 0f) gameObject.transform.position = new Vector3(0, 0.55f, -7);
		
		if (vel[1] > 0f) audioData.clip = woosh;
		
		if (vel[2] > 0f) audioData.clip = bruh; 
		
		if (vel[3] > 0f) audioData.clip = slap;
		
		if (vel[4] > 0f) audioData.clip = kurwa;
		
		if (vel[5] > 0f) audioData.clip = wow;
		
		if (vel[6] > 0f) audioData.clip = sanic;
		
		if (vel[7] > 0f) audioData.clip = hellothere;
		
		if (vel[8] > 0f) audioData.clip = metalgear;
		
		if (vel[9] > 0f) audioData.clip = boneless;
		
		if (vel[10] > 0f) audioData.clip = hurt;
		
		if (vel[11] > 0f) audioData.clip = sure;
		
		if (vel[19] > 0f) {
			if (invert) {
				invert = false;
			} else {
				invert = true;
			}
		}
	}
	
	void Megalovania(bool[] pressArray, bool keyPressed) {
		int index = System.Array.IndexOf(pressArray, keyPressed);
		if (sans[0]) {
			if (sans[1]) {
				if (sans[2]) {
					if (sans[3]) {
						if (sans[4]) {
							if (sans[5]) {
								if (sans[6]) {
									if (sans[7]) {
										if (sans[8]) {
											if (index == 15){
												Debug.Log("!");
												audioData.clip = megalovania;
												audioData.Play(0);
											} else {
												SansFalse();
											}
										} else if (index ==  13) {
											sans[8] = true;
											Debug.Log("e");
										} else {
											SansFalse();
										}
									} else if (index == 10) {
										sans[7] = true;
										Debug.Log("l");
									} else {
										SansFalse();
									}
								} else if (index == 13) {
									sans[6] = true;
									Debug.Log("a");
								} else {
									SansFalse();
								}
							} else if (index == 15) {
								sans[5] = true;
								Debug.Log("t");
							} else {
								SansFalse();
							}
						} else if (index == 16) {
							sans[4] = true;
							Debug.Log("r");
						} else {
							SansFalse();
						}
					} else if (index == 17) {
						sans[3] = true;
						Debug.Log("e");
					} else {
						SansFalse();
					}
				} else if (index == 22) {
					sans[2] = true;
					Debug.Log("d");
				} else {
					SansFalse();
				}
			} else if (index == 10) {
				sans[1] = true;
				Debug.Log("n");
			} else {
				SansFalse();
			}
		} else if (index == 10) {
			sans[0] = true;
			Debug.Log("u");
		} else {
			SansFalse();
		}
	}
	
	void SansFalse() {
		for (int i = 0; i < sans.Length; i++){
			sans[i] = false;
		}
	}
}
