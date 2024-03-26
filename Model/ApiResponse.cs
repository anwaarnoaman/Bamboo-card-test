using Newtonsoft.Json;

namespace Api 
{
    public class ApiResponse
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "Message")]
        public string Message
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "Success")]
        public bool Success
        {
            get;
            set;
        }    
       [JsonProperty(PropertyName = "Status")]
        public string Status
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "Data")]
        public object Data
        {
            get;
            set;
        }

             [JsonProperty(PropertyName = "StackTrace")]
        public string StackTrace
        {
            get;
            set;
        }


         public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
