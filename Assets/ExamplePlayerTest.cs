using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ExamplePlayerTest
{
	[UnityTest]
	public IEnumerator BasicPickupToggling() {
		TestUtil.TestScene scene = new TestUtil.TestScene("ExamplePlayerTest");
		yield return scene.LoadAndWait();

		ExamplePlayer player = scene.FindRootComponent<ExamplePlayer>("Player");
		Pill pill = scene.FindRootComponent<Pill>("Pill");
		TestPlayerInput input = scene.FindRootComponent<TestPlayerInput>("Player");

		Assert.IsFalse(pill.IsPickedUp());
        input.TriggerActionForNextFrame();
        yield return null;

		Assert.IsTrue(pill.IsPickedUp());
        input.TriggerActionForNextFrame();
        yield return null;

		Assert.IsFalse(pill.IsPickedUp());
	}
}
