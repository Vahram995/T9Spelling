namespace T9Spelling.Models.RequestModels
{
    public class T9SpellingRequestModel
    {
        public string Text { get; set; }

        public T9SpellingRequestModel() { }

        public T9SpellingRequestModel(string text)
        {
            Text = text;
        }
    }
}
