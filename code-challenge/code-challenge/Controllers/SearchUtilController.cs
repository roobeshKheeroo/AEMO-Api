using Microsoft.AspNetCore.Mvc;

namespace code_challenge.Controllers
{
    [ApiController]
    [Route("api/textutil")]
    public class SearchUtilController : ControllerBase
    {
        [Route("search")]
        [HttpGet]
        ///Match the subtext against the text, outputting the character positions of the beginning of each match for the subtext within the text.
        public async Task<int[]> SearchSubText(string mainText, string subText)
        {
            // Validate input
            if (string.IsNullOrEmpty(mainText) || string.IsNullOrEmpty(subText))
            {
                throw new ArgumentNullException("Main text and subtext cannot be null or empty");
            }

            List<int> positions = new();

            string lowerMainText =  mainText.ToLower();
            string lowerSubText = subText.ToLower();
         
            int index = 0;
            while ((index = lowerMainText.IndexOf(lowerSubText, index)) != -1)
            {
                positions.Add(index + 1); //Store position (1-based index)  
                index += 1;  // Move past the current match to find the next one
            }

            return positions.ToArray();
        }
    }
}
