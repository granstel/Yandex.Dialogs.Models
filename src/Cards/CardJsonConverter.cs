using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Cards
{
    internal sealed class CardJsonConverter : JsonConverter<ICard>
    {
        public override ICard Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var card = JsonElement.ParseValue(ref reader);
            if (card.ValueKind != JsonValueKind.Object)
            {
                throw new JsonException("Expected a card object.");
            }

            var comparison = options.PropertyNameCaseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            foreach (var property in card.EnumerateObject())
            {
                if (!string.Equals(property.Name, "type", comparison))
                {
                    continue;
                }

                switch (property.Value.Deserialize<CardType>(options))
                {
                    case CardType.BigImage:
                        return card.Deserialize<BigImageCard>(options);
                    case CardType.ItemsList:
                        return card.Deserialize<ItemsListCard>(options);
                    default:
                        throw new JsonException("Unknown card type.");
                }
            }

            throw new JsonException("Missing card type.");
        }

        public override void Write(Utf8JsonWriter writer, ICard value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
