using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ExamplePlayerTest {

	[UnityTest]
	public IEnumerator Initializes() {
		GameObject pill = new GameObject("tested");
		pill.AddComponent<Pill>();
		var pupRef = pill.AddComponent<IPickupableReference>();

		GameObject playerObj = new GameObject();
		playerObj.SetActive(false); // So we get a chance to set fields
		ExamplePlayer player = playerObj.AddComponent<ExamplePlayer>();
		player.targetRef = pupRef;

		playerObj.SetActive(true);

		yield return null;
	}
}
