using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Serialization
{
    internal abstract class DynamicDictionaryConverter<T> : JsonConverter<T> where T : class, IDictionary<string, object>
    {
        protected abstract T CreateDictionary();

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected a dictionary object.");
            }

            var result = CreateDictionary();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return result;
                }

                var key = reader.GetString();
                if (!reader.Read())
                {
                    break;
                }

                result[key] = DynamicValueConverter.ReadValue(ref reader);
            }

            throw new JsonException("Incomplete dictionary object.");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var entry in value)
            {
                writer.WritePropertyName(entry.Key);
                DynamicValueConverter.WriteValue(writer, entry.Value, options);
            }

            writer.WriteEndObject();
        }
    }

    internal sealed class StateJsonConverter : DynamicDictionaryConverter<State>
    {
        protected override State CreateDictionary() => new State();
    }

    internal sealed class AnalyticsValueConverter : DynamicDictionaryConverter<IDictionary<string, object>>
    {
        protected override IDictionary<string, object> CreateDictionary() => new Dictionary<string, object>();
    }
}
