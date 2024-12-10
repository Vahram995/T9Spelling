using T9Spelling.Models.RequestModels;
using T9Spelling.Models.ResponseModels;

namespace T9Spelling.Services.Abstraction
{
    public interface IT9SpellingService
    {
        T9SpellingResponseModel ConvertToT9(T9SpellingRequestModel model);
    }
}
