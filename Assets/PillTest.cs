using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PillTest {

	class TestGrabber : IPickupper {
		public Team GetTeam() {
			return Team.Blue;
		}
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator TestPillCooldown() {
        GameObject pillGo = new GameObject();
        pillGo.AddComponent<Pill>();
        IPickupable pickup = pillGo.GetComponent<IPickupable>();
        Assert.IsNotNull(pickup);

		TestGrabber grabber = new TestGrabber();

        Assert.IsTrue(pickup.CanPickup(grabber));
        pickup.OnPickup(grabber);
        Assert.IsFalse(pickup.CanPickup(grabber));

        pickup.OnDrop(grabber);
        // Should not be pickupable for 2 seconds of cooldown.
        Assert.IsFalse(pickup.CanPickup(grabber));

        // Wait for cooldown - then should be pickupable.
        yield return new WaitForSeconds(2.1f);
		Assert.IsTrue(pickup.CanPickup(grabber));
	}

	[UnityTest]
	public IEnumerator TestPillExposedAsPickupable() {
		GameObject pillGo = new GameObject();
		Pill pill = pillGo.AddComponent<Pill>();
		pillGo.AddComponent<IPickupableReference>();

		IPickupableReference pillRef = pillGo.GetComponent<IPickupableReference>();
		Assert.AreEqual(pill, pillRef.Get());

		yield return null;
	}



}
