using System.Globalization;
using System.Text.Json.Serialization;

namespace space.Nasa.Apod.Models
{
    public class MediaOfToday
    {
        [JsonPropertyName("copyright")]
        public string? PhotoCopyright { get; set; }
        [JsonPropertyName("date")]
        public string? PhotoDate { get; set; }
        [JsonPropertyName("explanation")]
        public string? PhotoExplanation { get; set; }
        [JsonPropertyName("title")]
        public string? PhotoTitle { get; set; }
        [JsonPropertyName("url")]
        public string? PhotoUrl { get; set; }

        public override string ToString()
        {
            var variableStr = String.IsNullOrEmpty(PhotoCopyright) ? "" : String.Format($" by {PhotoCopyright}");
            CultureInfo format = CultureInfo.CreateSpecificCulture("en-GB");
            format.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            var convertedPhotoDate = (PhotoDate is not null) ? DateOnly.Parse(PhotoDate) : new DateOnly();
            return String.Format($"{convertedPhotoDate.ToString("d", format)}\n\'{PhotoTitle}\'{variableStr}\n{PhotoExplanation}\n{PhotoUrl}\n");
        }
    }
}
