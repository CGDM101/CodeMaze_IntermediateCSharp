namespace Command
{ // Behavioural. To turn a request into an object, which contains all the information about the request. Popular. Especially when wanting to delay or queue a request's execution, or when we want to keep track of our operations. This possibility to keep track of our operations gives us the possibility to undo them as well.
    public class ProductCommand : ICommand // the command class. (extract all request details).
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly int _amount;

        public bool IsCommandExecuted { get; private set; }

        public ProductCommand(Product product, PriceAction priceAction, int amount)
        {
            _product = product;
            _priceAction = priceAction;
            _amount = amount;
        }

        public void ExecuteAction()
        {
            if (_priceAction == PriceAction.Increase)
            {
                _product.IncreasePrice(_amount);
                IsCommandExecuted = true;
            }
            else
            {
                //_product.DecreasePrice(_amount);
                IsCommandExecuted = _product.DecreasePrice(_amount);
            }
        }

        public void UndoAction()
        {
            if (!IsCommandExecuted)
                return;

            if (_priceAction == PriceAction.Increase)
            {
                _product.DecreasePrice(_amount);
            }
            else
            {
                _product.IncreasePrice(_amount);
            }
        }
    }
}
