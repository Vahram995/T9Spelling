using T9Spelling.Models.RequestModels;
using T9Spelling.Models.ResponseModels;
using T9Spelling.Services.Abstraction;

namespace T9Spelling.Services.Implementation
{
    public class T9SpellingService : IT9SpellingService
    {
        private static readonly Dictionary<char, string> _t9Dictionary = new()
        {
            {'a',"2"},    {'b',"22"},   {'c',"222"},
            {'d',"3"},    {'e',"33"},   {'f',"333"},
            {'g',"4"},    {'h',"44"},   {'i',"444"},
            {'j',"5"},    {'k',"55"},   {'l',"555"},
            {'m',"6"},    {'n',"66"},   {'o',"666"},
            {'p',"7"},    {'q',"77"},   {'r',"777"}, {'s',"7777"},
            {'t',"8"},    {'u',"88"},   {'v',"888"},
            {'w',"9"},    {'x',"99"},   {'y',"999"}, {'z',"9999"},
            {' ',"0"}
        };

        public T9SpellingResponseModel ConvertToT9(T9SpellingRequestModel model)
        {
            var result = string.Empty;
            var previousKeys = string.Empty;

            foreach (var c in model.Text)
            {
                if (!_t9Dictionary.TryGetValue(c, out var keys))
                    throw new KeyNotFoundException($"Character {c} was not found.");

                if (!string.IsNullOrEmpty(previousKeys) && previousKeys[previousKeys.Length - 1] == keys[0])
                    result += " ";

                result += keys;
                previousKeys = keys;
            }

            return new T9SpellingResponseModel(result);
        }
    }
}
