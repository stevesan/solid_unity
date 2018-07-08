using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple example that tries to pickup the in-editor-specified pickupable when you hit space.
public class ExamplePlayer : MonoBehaviour, IPickupper {
	[SerializeField] IPickupableReference targetRef;

	bool carrying = false;

	void Awake() {
		Debug.Assert(targetRef != null);
	}

	// TODO only exposing this for testing because we can't inject Input yet. Should do that...
	public void OnAction() {
		IPickupable target = targetRef.Get();
		if(carrying) {
			target.OnDrop(this);
			carrying = false;
		}
		else {
			if(target.CanPickup(this)) {
				target.OnPickup(this);
				carrying = true;
			}
			else {
				Debug.Log("Woops - can't pick up " + target.GetName() + " yet");
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			OnAction();
		}
	}

	public Team GetTeam() { return Team.Blue; }
}
