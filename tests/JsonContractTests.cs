using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Xunit;
using Yandex.Dialogs.Models.Buttons;
using Yandex.Dialogs.Models.Cards;
using Yandex.Dialogs.Models.Input;

namespace Yandex.Dialogs.Models.Tests;

public class JsonContractTests
{
    [Fact]
    public void InputReadsSessionInterfacesLocationAndEntities()
    {
        var input = Read<InputModel>("""
            {
              "meta": {"locale":"ru-RU","timezone":"Europe/Moscow","client_id":"client",
                       "interfaces":{"screen":{},"geolocation_sharing":{},"account_linking":{},"payments":{}}},
              "request": {"original_utterance":"say five","command":"five","type":"SimpleUtterance",
                          "nlu":{"entities":[{"tokens":{"start":0,"end":1},"type":"YANDEX.NUMBER","value":5},
                                             {"tokens":{"start":0,"end":1},"type":"YANDEX.DATETIME","value":{"day":12}}]}},
              "session": {"new":true,"skill_id":"skill","session_id":"session","message_id":3,"user_id":"legacy",
                          "user":{"user_id":"user"},"application":{"application_id":"app"},
                          "location":{"lat":55.5,"lon":37.5,"accuracy":20}},
              "version":"1.0"
            }
            """);

        Assert.Equal("client", input.Meta.ClientId);
        Assert.True(input.Meta.Interfaces.HasScreen());
        Assert.True(input.Meta.Interfaces.HasGeolocationSharing());
        Assert.NotNull(input.Meta.Interfaces.AccountLinking);
        Assert.NotNull(input.Meta.Interfaces.Payments);
        Assert.Equal("say five", input.Request.OriginalUtterance);
        Assert.Equal("SimpleUtterance", input.Request.Type);
        Assert.Collection(input.Request.Nlu.Entities,
            entity =>
            {
                Assert.Equal(1, entity.Tokens.End);
                Assert.Equal(5L, Assert.IsType<long>(entity.Value));
            },
            entity => AssertJson("""{"day":12}""", Write(entity.Value)));
        Assert.True(input.Session.New);
        Assert.Equal("skill", input.Session.SkillId);
        Assert.Equal("session", input.Session.SessionId);
        Assert.Equal(3, input.Session.MessageId);
        Assert.Equal("legacy", input.Session.UserId);
        Assert.Equal("user", input.Session.User.UserId);
        Assert.Equal("app", input.Session.Application.ApplicationId);
        Assert.Equal(55.5f, input.Session.Location.Lat);
        Assert.Equal(37.5f, input.Session.Location.Lon);
        Assert.Equal(20f, input.Session.Location.Accuracy);
        Assert.Equal("1.0", input.Version);
    }

    [Theory]
    [InlineData("Session", "User", "Application")]
    [InlineData("session", "user", "application")]
    public void InputReadsClrStateValues(string session, string user, string application)
    {
        var input = Read<InputModel>($$"""
            {"state":{
              "{{session}}":{"IsReady":true,"NullValue":null,"Nested":{"KeepCase":[true,1]},"Date":"2025-01-02T03:04:05Z"},
              "{{user}}":{"DisplayMode":"compact"},
              "{{application}}":{"Count":2147483648,"Fraction":2.5,"Exponent":1e2,"WholeDouble":2.0,"Off":false}
            } }
            """);

        Assert.True(input.TryGetFromSessionState<bool>("IsReady", out var ready));
        Assert.True(ready);
        Assert.False(input.TryGetFromSessionState<bool>("isready", out _));
        Assert.False(input.TryGetFromSessionState<bool>("NullValue", out _));
        Assert.Null(input.State.Session["NullValue"]);
        Assert.True(input.TryGetFromSessionState<DateTime>("Date", out var date));
        Assert.Equal(new DateTime(2025, 1, 2, 3, 4, 5, DateTimeKind.Utc), date);
        AssertJson("""{"KeepCase":[true,1]}""", Write(input.State.Session["Nested"]));
        Assert.True(input.TryGetFromUserState<string>("DisplayMode", out var mode));
        Assert.Equal("compact", mode);
        Assert.True(input.TryGetFromApplicationState<long>("Count", out var count));
        Assert.Equal(2147483648L, count);
        Assert.True(input.TryGetFromApplicationState<double>("Fraction", out var fraction));
        Assert.Equal(2.5, fraction);
        Assert.Equal(100d, Assert.IsType<double>(input.State.Application["Exponent"]));
        Assert.Equal(2d, Assert.IsType<double>(input.State.Application["WholeDouble"]));
        Assert.True(input.TryGetFromApplicationState<bool>("Off", out var off));
        Assert.False(off);
        Assert.False(input.TryGetFromApplicationState<string>("Count", out _));
    }

    [Fact]
    public void InputWritesLowercaseStateNamesAndPreservesDictionaryKeys()
    {
        var state = new InputState
        {
            Session = new State { ["IsReady"] = true },
            User = new State { ["DisplayMode"] = "compact" },
            Application = new State { ["maxCount"] = 3, ["WholeDouble"] = 2d }
        };

        var json = Write(state);
        AssertJson("""{"session":{"IsReady":true},"user":{"DisplayMode":"compact"},"application":{"maxCount":3,"WholeDouble":2.0}}""", json);
        Assert.Equal(2d, Assert.IsType<double>(Read<InputState>(json).Application["WholeDouble"]));
    }

    [Fact]
    public void OutputWritesBigImageDirectivesStateAndAnalytics()
    {
        var output = new OutputModel
        {
            Version = "1.0",
            Session = new Session { SessionId = "session", MessageId = 3, UserId = "user" },
            Response = new Response
            {
                Text = "Reply", Tts = "Reply", EndSession = false,
                Buttons = [new ResponseButton { Title = "Again", Hide = true, Payload = new { KeepCase = true } }],
                Card = new BigImageCard
                {
                    ImageId = "image", Title = "Title", Description = "Description",
                    Button = new CardButton { Text = "Open", Url = "https://example.com" }
                }
            }
        };
        output.InitRequestGeolocation();
        output.RequestAccountLinking();
        output.AddToSessionState("IsReady", true);
        output.AddToUserState("DisplayMode", "compact");
        output.AddToApplicationState("maxCount", 3);
        output.AddAnalyticsEvent("view", new Dictionary<string, object> { ["EventValue"] = 7 });

        AssertJson("""
            {
              "response":{"text":"Reply","tts":"Reply","end_session":false,
                          "buttons":[{"title":"Again","hide":true,"payload":{"KeepCase":true}}],
                          "card":{"type":"BigImage","image_id":"image","title":"Title","description":"Description",
                                  "button":{"text":"Open","url":"https://example.com"}},
                          "directives":{"request_geolocation":{}}},
              "analytics":{"events":[{"name":"view","value":{"EventValue":7}}]},
              "start_account_linking":{},"session":{"session_id":"session","message_id":3,"user_id":"user"},
              "session_state":{"IsReady":true},"user_state_update":{"DisplayMode":"compact"},
              "application_state":{"maxCount":3},"version":"1.0"
            }
            """, Write(output, omitNulls: true));
    }

    [Fact]
    public void OutputWritesItemsListWithDerivedHeader()
    {
        ICard card = new ItemsListCard
        {
            Header = new Footer { Text = "List", Button = new CardButton { Text = "More" } },
            Items = [new CardItem { ImageId = "item", Title = "First", Button = new CardButton { Payload = 9 } }]
        };

        AssertJson("""
            {"type":"ItemsList","header":{"text":"List","button":{"text":"More"}},
             "items":[{"image_id":"item","title":"First","button":{"payload":9}}]}
            """, Write(card, omitNulls: true));
        Assert.Equal(CardType.ItemsList, Read<CardType>("\"ItemsList\""));
        Assert.Equal("\"BigImage\"", Write(CardType.BigImage));
    }

    [Fact]
    public void OutputReadsConcreteCardsAndWritesNullsByDefault()
    {
        var card = Read<BigImageCard>("""{"type":"BigImage","image_id":"image","button":{"payload":true}}""");

        Assert.Equal("image", card.ImageId);
        Assert.True(Assert.IsType<bool>(card.Button.Payload));
        AssertJson("""
            {"text":null,"tts":null,"buttons":null,"end_session":false,"card":null,"directives":null}
            """, Write(new Response()));
        AssertJson("""{"first_name":"Ada","last_name":"Lovelace","patronymic_name":null}""",
            Write(new EntityValue { FirstName = "Ada", LastName = "Lovelace" }));
    }

    [Fact]
    public void OutputReadsAnalyticsAndWritesDerivedSession()
    {
        var output = Read<OutputModel>("""
            {"analytics":{"events":[{"name":"view","value":{"EventValue":7,"Flags":[true]}}]}}
            """);
        var entry = Assert.Single(output.Analytics.Events);
        Assert.Equal("view", entry.Name);
        Assert.Equal(7L, Assert.IsType<long>(entry.Value["EventValue"]));
        AssertJson("[true]", Write(entry.Value["Flags"]));

        output.Session = new InputSession { SkillId = "skill", New = true };
        AssertJson("""
            {"analytics":{"events":[{"name":"view","value":{"EventValue":7,"Flags":[true]}}]},
             "session":{"skill_id":"skill","new":true,"message_id":0}}
            """, Write(output, omitNulls: true));
    }

    private static T Read<T>(string json) => JsonConvert.DeserializeObject<T>(json);

    private static string Write<T>(T value, bool omitNulls = false) => JsonConvert.SerializeObject(value,
        new JsonSerializerSettings { NullValueHandling = omitNulls ? NullValueHandling.Ignore : NullValueHandling.Include });

    private static void AssertJson(string expected, string actual) =>
        Assert.True(JsonNode.DeepEquals(JsonNode.Parse(expected), JsonNode.Parse(actual)), actual);
}
