using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Yandex.Dialogs.Models.Interfaces;

namespace Yandex.Dialogs.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class OutputModel
    {
        public Response Response { get; set; }

        public Analytics.Analytics Analytics { get; set; }

        public AccountLinking StartAccountLinking { get; set; }

        public Session Session { get; set; }

        public State SessionState { get; set; }
        
        public State UserStateUpdate { get; set; }
        
        public State ApplicationState { get; set; }

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
