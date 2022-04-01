using UnityEngine.SceneManagement;
using UnityEngine;


public class NextV : MonoBehaviour
{
   
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
  
    }

}
