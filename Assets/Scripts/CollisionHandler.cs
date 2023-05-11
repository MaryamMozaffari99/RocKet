using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;

    void OnCollisionEnter(Collision other)
    {
       switch (other.gameObject.tag )
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            /*case "Fuel":
                Debug.Log("You picked up the Fuel!");
                break;*/
                ////case "Finish":
                //Debug.Log("Congrats, you blew up!");
                //////    LoadNextLevel();
            case "Finish":
                //LoadNextLevel();
                SrartSuccessSequence();
                break;

          /*  case "Finishh":
                Debug.Log("Hora!");
                break;*/
            
            default:
                //Debug.Log("SORRY, you blew up!");
                //ReloadLevel();
                //RestartCurrentScene();
                StartCrashSequence();
                Invoke("ReloadLevel" , 1f);
                break;

        }

    }

    private void SrartSuccessSequence()
    {
          // throw new NotImplementedException();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);


    }

    /* void SrartSuccessSequence()
{
    // todo add SFX upon crash
    // todo add particle effect upon crash
    // Invoke("ReloadLevel", levelLoadDelay);
    ReloadLevel();
}*/


    void StartCrashSequence()
        {
        // todo add SFX upon crash
        // todo add particle effect upon crash

        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);

        //GetComponent<Movement>().enabled = false;
        //Invoke("StartCrashSequence", levelLoadDelay);

    }
    void LoadNextLevel()
    {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0; 
            }
        else
        {
            //RestartCurrentScene();
            ReloadLevel();

        }

        //SceneManager.LoadScene(currentSceneIndex);
        SceneManager.LoadScene(nextSceneIndex);
         

        }
        void ReloadLevel()
        {
                //1 SceneManager.LoadScene(0);

                //2 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
                //Clean Code

                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
        }
   /* void RestartCurrentScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }*/

}
