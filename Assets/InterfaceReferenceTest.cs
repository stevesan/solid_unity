
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Text.RegularExpressions;

public class InterfaceReferenceTest
{
	class TestPickupable : MonoBehaviour, IPickupable {
		public bool CanPickup(IPickupper picker) {
			return true;
		}
		public string GetName() { return "test"; }
		public void OnPickup(IPickupper picker) {}
		public void OnDrop(IPickupper picker) {}
	}

	[UnityTest]
	public IEnumerator TestReferenceComponentGetsExistingReference() {
		GameObject go = new GameObject();
		TestPickupable pup = go.AddComponent<TestPickupable>();
		Assert.IsNotNull(pup);

		PickupableReference reference = go.AddComponent<PickupableReference>();
		Assert.IsNotNull(reference);

		// The reference component should automatically pickup the actual interface reference.
		Assert.AreEqual(pup, reference.Get());
		yield return null;
	}

	[UnityTest]
	public IEnumerator TestReferenceComponentErrorsWithMultipleImplementations() {
		GameObject go = new GameObject();
		TestPickupable pup = go.AddComponent<TestPickupable>();
		TestPickupable pup2 = go.AddComponent<TestPickupable>();
		Assert.IsNotNull(pup);
		Assert.IsNotNull(pup2);

		string componentName = typeof(TestPickupable).Name;
		LogAssert.Expect(LogType.Error, new Regex(@".*"+go.name+".*"));
		LogAssert.Expect(LogType.Error, new Regex(@".*"+componentName+".*"));
		LogAssert.Expect(LogType.Error, new Regex(@".*"+componentName+".*"));
		PickupableReference reference = go.AddComponent<PickupableReference>();
		Assert.IsNotNull(reference);

		// The reference component should automatically pickup the actual interface reference.
		Assert.AreEqual(pup, reference.Get());
		yield return null;
	}

}
