namespace Command
{ // Behavioural. To turn a request into an object, which contains all the information about the request. Popular. Especially when wanting to delay or queue a request's execution, or when we want to keep track of our operations. This possibility to keep track of our operations gives us the possibility to undo them as well.
    public interface ICommand
    {
        void ExecuteAction();
        void UndoAction();
    }
}
