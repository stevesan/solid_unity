using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour, IPickupable {

    bool pickedUp = false;
    float pickupCooldownSecs = 0f;

	// Update is called once per frame
	void Update () {
        if(pickupCooldownSecs > 0f) {
            pickupCooldownSecs -= Time.deltaTime;
        }
	}

	public bool CanPickup(IPickupper picker) {
        return !pickedUp && pickupCooldownSecs <= 0f;
    }

	public void OnPickup(IPickupper picker) {
        pickedUp = true;
        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

	public void OnDrop(IPickupper picker) {
        pickedUp = false;
        pickupCooldownSecs = 2f;
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public string GetName() {
        return this.name;
    }
}
