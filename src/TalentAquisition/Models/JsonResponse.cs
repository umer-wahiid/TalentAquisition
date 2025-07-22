namespace TalentAquisition.Models
{
    public class JsonResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static JsonResponse Success(object data = null, string message = "")
        {
            return new JsonResponse { success = true, data = data, message = message };
        }

        public static JsonResponse Error(string message, object data = null)
        {
            return new JsonResponse { success = false, message = message, data = data };
        }
    }
}
