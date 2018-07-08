using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple example that tries to pickup the in-editor-specified pickupable when you hit space.
public class ExamplePlayer : MonoBehaviour, IPickupper {
	public IPickupableReference targetRef;

	bool carrying = false;

	void Awake() {
		Debug.Assert(targetRef != null);
	}

	// Update is called once per frame
	void Update () {
		IPickupable target = targetRef.Get();
		if(Input.GetKeyDown(KeyCode.Space)) {
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
	}

	public Team GetTeam() { return Team.Blue; }
}
