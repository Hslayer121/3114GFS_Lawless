using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour 
{
	public void NewGameBTN(string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
	}
	public void ExitGameBtn()
	{
		Application.Quit ();
	}
}
