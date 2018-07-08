using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple example that tries to pickup the in-editor-specified pickupable when you hit space.
[RequireComponent(typeof(IPlayerInput))]
public class ExamplePlayer : MonoBehaviour, IPickupper {
	[SerializeField] IPickupableReference targetRef;

	IPlayerInput input;

	bool carrying = false;

	void Awake() {
		Debug.Assert(targetRef != null);

        input = GetComponent<IPlayerInput>();
		Debug.Assert(input != null);
	}

	void OnAction() {
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
		if(input.GetActionTriggered()) {
			OnAction();
		}
	}

	public Team GetTeam() { return Team.Blue; }
}
