using System.Collections.Generic;
using System.Text.Json.Serialization;
using Yandex.Dialogs.Models.Interfaces;

namespace Yandex.Dialogs.Models
{
    public class OutputModel
    {
        [JsonPropertyName("response")]
        public Response Response { get; set; }

        [JsonPropertyName("analytics")]
        public Analytics.Analytics Analytics { get; set; }

        [JsonPropertyName("start_account_linking")]
        public AccountLinking StartAccountLinking { get; set; }

        [JsonPropertyName("session")]
        public Session Session { get; set; }

        [JsonPropertyName("session_state")]
        public State SessionState { get; set; }
        
        [JsonPropertyName("user_state_update")]
        public State UserStateUpdate { get; set; }
        
        [JsonPropertyName("application_state")]
        public State ApplicationState { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        public void AddToSessionState(string key, object value)
        {
            if (SessionState == null)
            {
                SessionState = new State();
            }

            SessionState.Add(key, value);
        }

        public void AddToUserState(string key, object value)
        {
            if (UserStateUpdate == null)
            {
                UserStateUpdate = new State();
            }

            UserStateUpdate.Add(key, value);
        }

        public void AddToApplicationState(string key, object value)
        {
            if (ApplicationState == null)
            {
                ApplicationState = new State();
            }

            ApplicationState.Add(key, value);
        }

        public void RequestAccountLinking()
        {
            StartAccountLinking = new AccountLinking();
        }

        public void InitRequestGeolocation()
        {
            Response?.InitRequestGeolocation();
        }

        public void AddAnalyticsEvent(string name, IDictionary<string, object> value)
        {
            if (Analytics == null)
            {
                Analytics = new Analytics.Analytics();
            }

            Analytics.AddEvent(name, value);
        }
    }
}
