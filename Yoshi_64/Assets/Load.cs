using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load : MonoBehaviour {

	//SceneManager.LoadScene("Scene");

	public void ChangeScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
