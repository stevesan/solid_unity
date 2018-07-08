﻿using UnityEngine;

// You could get a little crazier and actually have this implement IPickupable itself,
// forwarding every method to the reference! Doesn't seem worth the trouble.
[RequireComponent(typeof(IPickupable))]
public class IPickupableReference : InterfaceReference<IPickupable> {
}

