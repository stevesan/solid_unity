
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Text.RegularExpressions;

public class InterfaceReferenceTest
{
	interface IFoo
	{
		void DoFoo();
	}

	[RequireComponent(typeof(IFoo))]
	class IFooReference : InterfaceReference<IFoo> {
	}

	class FooImpl : MonoBehaviour, IFoo {
		public void DoFoo() {}
	}

	[UnityTest]
	public IEnumerator TestReferenceComponentGetsExistingReference() {
		GameObject go = new GameObject();
		FooImpl pup = go.AddComponent<FooImpl>();
		Assert.IsNotNull(pup);

		IFooReference reference = go.AddComponent<IFooReference>();
		Assert.IsNotNull(reference);

		// The reference component should automatically pickup the actual interface reference.
		Assert.AreEqual(pup, reference.Get());
		yield return null;
	}

	[UnityTest]
	public IEnumerator TestReferenceComponentErrorsWithMultipleImplementations() {
		GameObject go = new GameObject();
		FooImpl pup = go.AddComponent<FooImpl>();
		FooImpl pup2 = go.AddComponent<FooImpl>();
		Assert.IsNotNull(pup);
		Assert.IsNotNull(pup2);

		string componentName = typeof(FooImpl).Name;
		LogAssert.Expect(LogType.Error, new Regex(@".*"+go.name+".*"));
		LogAssert.Expect(LogType.Error, new Regex(@".*"+componentName+".*"));
		LogAssert.Expect(LogType.Error, new Regex(@".*"+componentName+".*"));
		IFooReference reference = go.AddComponent<IFooReference>();
		Assert.IsNotNull(reference);

		// The reference component should automatically pickup the actual interface reference.
		Assert.AreEqual(pup, reference.Get());
		yield return null;
	}

}
