namespace T9Spelling.Models.ResponseModels
{
    public class T9SpellingResponseModel
    {
        public string ConvertedText { get; set; }

        public T9SpellingResponseModel() { }
        public T9SpellingResponseModel(string convertedText)
        {
            ConvertedText = convertedText;
        }
    }
}
