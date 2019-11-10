using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveFocusObject : MonoBehaviour
{
	Rigidbody rb; // represents the Rigidbody component of the focus item
	public float speed = 5f; // a multiplier for speed with note velocity
	private float[] vel; // an array of velocities from key presses
	private bool[] press; // an array of bools from key presses
	private bool[] sans; // an array of bools to track determination
	private int[] indexes; // indexes for random control schemes
	AudioSource audioData; // AudioSource component object
	// the following are audio clips representing memes, as well as the default woosh sound
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
	public AudioClip swamp;
	public AudioClip weed;
	public AudioClip dziendobry;
	public AudioClip cena;
	private bool invert; // represents if controls are inverted or not
	
	
	void Start() {
		rb = GetComponent<Rigidbody>(); // gets Rigidbody component
		vel = new float[34]; // holds 32 keys and 1 mod wheel
		press = new bool[33]; // holds 32 keys
		sans = new bool[10]; // there are 10 notes in the first line
		for (int i = 0; i < sans.Length; i++){
			sans[i] = false; // sets all bools in sans array to false
		}
		invert = false; // nobody starts with invert, nobody.
		audioData = GetComponent<AudioSource>(); // gets AudioSource component
		indexes = new int[33];
		for (int i = 0; i < indexes.Length-1; i++) {
			indexes[i+1] = i + 1;
		}
		
		for (int t = 1; t < indexes.Length; t++) {
			int tmp = indexes[t];
			int r = Random.Range(t, indexes.Length);
			indexes[t] = indexes[r];
			indexes[r] = tmp;
		}
		for (int i = 1; i < 12; i++) {
			if (indexes[i] == 15) indexes[i] = 32;
		}
		
		string word = string.Join(", ", indexes.Select(i => i.ToString()).ToArray());
		Debug.Log(word);
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
		
		// plays current audioclip on keypress
		for (int i = 1; i < 33; i++) {
			if (vel[i] > 0) audioData.Play(0);
		}
		
		if (vel[33] > 0f) audioData.pitch = 0.5f + vel[33];
		
		// starts check on Megalovania progress
		foreach (bool pressed in press) {
			if (pressed) Megalovania(press, pressed);
		}
		
		// if invert is on, it switches round the movement keys
		// also has a shoot into air part
		if (invert){
			rb.AddForce((vel[indexes[20]]-vel[indexes[22]]) * speed, vel[indexes[21]], (vel[indexes[25]]-vel[indexes[24]]) * speed);
		} else {
			rb.AddForce((vel[indexes[22]]-vel[indexes[20]]) * speed, vel[indexes[21]], (vel[indexes[24]]-vel[indexes[25]]) * speed);
		}
		
		// keys 1-11 represents sounds
		if (vel[indexes[1]] > 0f) audioData.clip = woosh;
		if (vel[indexes[2]] > 0f) audioData.clip = bruh; 
		if (vel[indexes[3]] > 0f) audioData.clip = slap;
		if (vel[indexes[4]] > 0f) audioData.clip = kurwa;
		if (vel[indexes[5]] > 0f) audioData.clip = wow;
		if (vel[indexes[6]] > 0f) audioData.clip = sanic;
		if (vel[indexes[7]] > 0f) audioData.clip = hellothere;
		if (vel[indexes[8]] > 0f) audioData.clip = metalgear;
		if (vel[indexes[9]] > 0f) audioData.clip = boneless;
		if (vel[indexes[10]] > 0f) audioData.clip = hurt;
		if (vel[indexes[11]] > 0f) audioData.clip = swamp;
		if (vel[indexes[12]] > 0f) audioData.clip = weed;
		if (vel[indexes[13]] > 0f) audioData.clip = dziendobry;
		
		// key 19 toggles invert
		if (vel[indexes[19]] > 0f) {
			if (invert) {
				invert = false;
				Debug.Log("UNINVERTED!");
			} else {
				invert = true;
				Debug.Log("INVERTED!");
			}
		}
	}
	
	// this code basically tracks progress towards the easter egg: a bonus sound
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
	
	// a method to help set all bools to false
	void SansFalse() {
		for (int i = 0; i < sans.Length; i++){
			sans[i] = false;
		}
	}
}
