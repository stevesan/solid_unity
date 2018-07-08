using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ExamplePlayerTest
{
	[UnityTest]
	public IEnumerator BasicPickupToggling() {
		TestUtil.TestScene scene = new TestUtil.TestScene("PlayerPicksUpPill");
		yield return scene.LoadAndWait();

		ExamplePlayer player = scene.FindRootObjectOfType<ExamplePlayer>("Player");
		Pill pill = scene.FindRootObjectOfType<Pill>("Pill");

		Assert.IsFalse(pill.IsPickedUp());
		player.OnAction();
		Assert.IsTrue(pill.IsPickedUp());
		player.OnAction();
		Assert.IsFalse(pill.IsPickedUp());
	}
}
