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
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                        break;
                    case 1:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        break;
                    case 2:
                        Debug.Log("QUIT GAME");
                        Application.Quit();
                        break;
                    
                }
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }
}
