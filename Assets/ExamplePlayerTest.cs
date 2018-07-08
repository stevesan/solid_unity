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
		TestPlayerInput input = scene.FindRootObjectOfType<TestPlayerInput>("Player");

		Assert.IsFalse(pill.IsPickedUp());
        input.TriggerActionForNextFrame();
        yield return null;

		Assert.IsTrue(pill.IsPickedUp());
        input.TriggerActionForNextFrame();
        yield return null;

		Assert.IsFalse(pill.IsPickedUp());
	}
}
