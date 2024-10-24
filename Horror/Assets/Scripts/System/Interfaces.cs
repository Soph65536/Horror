public interface IInteractable
{
    string GetName();
    void Interact();
}

public interface IMenuButton
{
    void OnButtonPress();
}