
using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;

public static class TestUtil
{
	public class TestScene
	{
		string sceneName;

		List<GameObject> rootObjs = null;

		bool loaded = false;

		public TestScene(string sceneName) {
			this.sceneName = sceneName;
		}

		// Call like "yield return scene.LoadAndWait();"
		public IEnumerator LoadAndWait()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerPicksUpPill");

			// Takes one more frame to actually load.
			yield return null;

			loaded = true;
		}

		string GetLogPrefix() {
			return "In test scene '" + this.sceneName + "': ";
		}

		// This will assert-fail if not found.
		public GameObject FindRootObject(string objName) {
			Debug.Assert(loaded);

			if(rootObjs == null) {
				rootObjs = new List<GameObject>();
				UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects(rootObjs);
			}

			GameObject obj = rootObjs.Find(o => o.name == objName);
			Assert.IsNotNull(obj, GetLogPrefix() + "Could not find root test object named '" + objName + "'.");
			return obj;
		}

		// This will assert-fail if the object isn't found OR if it doesn't have the expected component.
		public TComponent FindRootObjectOfType<TComponent>(string objName) {
			GameObject obj = this.FindRootObject(objName);
			TComponent component = obj.GetComponent<TComponent>();
			Assert.IsNotNull(component, GetLogPrefix() + "Root object '"+objName+"' did not have expected component: "
				+ typeof(TComponent).Name);
			return component;
		}

	}
}
