namespace Commons
{
    public class SelectableDataOptions
    {
        private object[] Options { get; }
        public SelectableDataOptions(object [] dataValueOptions)
        {
            this.Options = dataValueOptions;
        }
        public bool IsValidDataValue(object value)
        {
            foreach (var option in Options)
                if (option.Equals(value))
                    return true;
            return false;
        }
    }
}
