using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

    }

 public void LoadCurrentSceneWithDelay()
 {
     Invoke("LoadCurrentScene", 2f);
     Debug.Log("respawn");
 }

}
