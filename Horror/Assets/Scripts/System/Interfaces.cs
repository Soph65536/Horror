public interface IInteractable
{
    string GetName();
    void Interact();
}

public interface IMenuButton
{
    void OnEPress();
    void OnQPress();
}