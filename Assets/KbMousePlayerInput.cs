
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KbMousePlayerInput : MonoBehaviour, IPlayerInput {
    public bool GetActionTriggered() {
        return Input.GetKeyDown(KeyCode.E);
    }

    public Vector2 GetThrottle() {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
