using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private int nextLevel;

    public void LoadNextLevel ()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
        //MusicPlayer.chooser(nextLevel);
        

    }

	public void LoadLevel (string name)
    {
		//Debug.Log (name);
		SceneManager.LoadScene (name);
	}
	public void QuitGame ()
    {
		//Debug.Log ("Quit Game Requested");
		Application.Quit ();
	}
}
