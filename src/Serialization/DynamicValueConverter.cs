using System;
using System.Buffers;
using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yandex.Dialogs.Models.Serialization
{
    internal sealed class DynamicValueConverter : JsonConverter<object>
    {
        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            ReadValue(ref reader);

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options) =>
            WriteValue(writer, value, options);

        internal static object ReadValue(ref Utf8JsonReader reader)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.True:
                case JsonTokenType.False:
                    return reader.GetBoolean();
                case JsonTokenType.String:
                    var text = reader.GetString();
                    if (text.Length >= 19 && text[10] == 'T' && reader.TryGetDateTime(out var date))
                    {
                        return date;
                    }

                    return text;
                case JsonTokenType.Number:
                    if (reader.TryGetInt64(out var integer))
                    {
                        return integer;
                    }

                    var bytes = reader.HasValueSequence ? reader.ValueSequence.ToArray().AsSpan() : reader.ValueSpan;
                    if (bytes.IndexOfAny((byte)'.', (byte)'e', (byte)'E') >= 0)
                    {
                        return reader.GetDouble();
                    }

                    return BigInteger.Parse(JsonElement.ParseValue(ref reader).GetRawText(),
                        NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
                case JsonTokenType.StartArray:
                case JsonTokenType.StartObject:
                    return JsonElement.ParseValue(ref reader);
                default:
                    throw new JsonException("Expected a JSON value.");
            }
        }

        internal static void WriteValue(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case BigInteger integer:
                    writer.WriteRawValue(integer.ToString(CultureInfo.InvariantCulture));
                    break;
                case double number when !double.IsNaN(number) && !double.IsInfinity(number):
                    WriteFloatingPoint(writer, number.ToString("R", CultureInfo.InvariantCulture));
                    break;
                case float number when !float.IsNaN(number) && !float.IsInfinity(number):
                    WriteFloatingPoint(writer, number.ToString("R", CultureInfo.InvariantCulture));
                    break;
                default:
                    JsonSerializer.Serialize(writer, value, value.GetType(), options);
                    break;
            }
        }

        private static void WriteFloatingPoint(Utf8JsonWriter writer, string number)
        {
            // Keep whole floating-point values distinct from integers when the state is read back.
            if (number.IndexOf('.') < 0 && number.IndexOf('E') < 0)
            {
                number += ".0";
            }

            writer.WriteRawValue(number);
        }
    }
}
