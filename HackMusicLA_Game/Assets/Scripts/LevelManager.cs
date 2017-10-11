using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
	enum SceneLoadState { IS_LOADED, IS_NOT_LOADED};
	SceneLoadState loadPersistent = SceneLoadState.IS_NOT_LOADED;

	void Awake()
	{
		// Load extra scenes on top of the main scene.
		if (SceneManager.sceneCount > 0) 
		{
			for (int i = 0; i < SceneManager.sceneCount; i++) 
			{
				if (SceneManager.GetSceneAt (i).name == "Persistent") 
				{
					loadPersistent = SceneLoadState.IS_LOADED;
				}
			}
		}

		// Load the persistent scene if it is not yet loaded.
		if (loadPersistent == SceneLoadState.IS_NOT_LOADED) 
		{
			SceneManager.LoadScene ("Persistent", LoadSceneMode.Additive);
		}
	}
}
