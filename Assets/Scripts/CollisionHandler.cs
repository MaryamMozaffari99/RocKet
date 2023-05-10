using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
       switch (other.gameObject.tag )
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Fuel":
                Debug.Log("You picked up the Fuel!");
                break;
            case "Finish":
                //Debug.Log("Congrats, you blew up!");
                LoadNextLevel();
                break;
            default:
                //Debug.Log("SORRY, you blew up!");
                ReloadLevel();
                break;
                
            }
        }
        void LoadNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0; 
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
    
}
