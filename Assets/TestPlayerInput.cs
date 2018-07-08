
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerInput : MonoBehaviour, IPlayerInput {
    public Vector2 throttle;
    int lastActionFrame = -1;

    public bool GetActionTriggered() {
        return lastActionFrame == Time.frameCount;
    }

    public void TriggerActionForNextFrame() {
        lastActionFrame = Time.frameCount + 1;
    }

    public Vector2 GetThrottle() {
        return throttle;
    }
}
