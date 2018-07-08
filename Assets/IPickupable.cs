
public enum Team {
	Blue,
	Red
}

public interface IPickupper {
	Team GetTeam();
}

public interface IPickupable {
	bool CanPickup(IPickupper picker);
	string GetName();
	void OnPickup(IPickupper picker);
	void OnDrop(IPickupper picker);
}
