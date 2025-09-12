namespace DoubleLinkedListDemo
{
    public enum TypeOfGrain
    {
        Wheat,
        Oat,
        Rice,
        Corn,
        Almond,
        Other
    }

    public class Cookie
    {
        public string Brand { get; set; } = string.Empty;
        public int CaloriesPerServing { get; set; }
        public string Ingredients { get; set; } = string.Empty;
        public double SugarGrams { get; set; }
        public TypeOfGrain GrainType { get; set; }
        public bool IsGlutenFree { get; set; }

        public override string ToString()
        {
            return $"{Brand} | {CaloriesPerServing} cal | Sugar: {SugarGrams}g | Grain: {GrainType} | GlutenFree: {IsGlutenFree}";
        }
    }
}
