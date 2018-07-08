
using UnityEngine;

public static class Util
{
    public static int ReturnTwo() {
        return 2;
    }

	// Unity doesn't allow interface types to be used as editor fields.
	// So use this instead. You also of course need to add this component
	// to any pickupables that you'd like to drag into these editor fields.
	// For code that uses the reference, just use fieldName.Get() to get the interface
	// reference.
	public class InterfaceReference<TInterface> : MonoBehaviour {
		TInterface actualReference;

		void Awake() {
			actualReference = GetComponent<TInterface>();
			Debug.Assert(actualReference != null,
				this.name + " does not actually have a component that implements " + typeof(TInterface).Name);

			#if UNITY_EDITOR
			TInterface[] impls = GetComponents<TInterface>();
			if(impls.Length != 1) {
				Debug.LogError(this.name + " should have exactly 1 implementation of " + typeof(TInterface).Name + ". All found impls types:", this.gameObject);
				foreach(TInterface impl in impls) {
					Debug.LogError(impl.GetType().Name);
				}

			}
			// Make sure there is only one implementation.
			#endif
		}

		public TInterface Get() {
			return actualReference;
		}
	}

}
