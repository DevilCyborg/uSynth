using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	//[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	public AudioClip sure;
	AudioSource audioData;
	
	void Start(){
		audioData = (AudioSource) FindObjectOfType<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				//animatorFunctions.disableOnce = true;

                switch (thisIndex)
                {
                    case 0:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        break;
                    case 1:
                        audioData.clip = sure;
						audioData.Play(0);
                        break;
                    case 2:
                        Application.Quit();
                        break;
                    
                }
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }
}
