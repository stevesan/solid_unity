using UnityEngine;

public interface IPlayerInput
{
    // Return true if on this frame, 'action' is triggered.
    bool GetActionTriggered();

    // Reads the current movement throttle. (0,0) means no motion, and the expected ranges are [-1, -1] to [1, 1].
    // Returning magnitudes > 1 is OK, since the reader should magnitude-clamp it anyway.
    Vector2 GetThrottle();
}
