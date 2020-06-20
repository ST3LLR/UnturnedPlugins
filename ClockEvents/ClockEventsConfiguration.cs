using System.Xml.Serialization;

using Rocket.API;

namespace ST3LLR.ClockEvents
{
    public class ClockEventsConfiguration : IRocketPluginConfiguration
    {

        [XmlArrayItem("Event")]
        [XmlArray(ElementName = "Events")]
        public Event[] Events;

        public void LoadDefaults()
        {
            Events = new Event[]
            {
                new Event(500,"Saving server, I guess","Red","save"),
                new Event(400,"Airdrop!","Green","airdrop"),
                new Event(700,"Good day, indeed!","Yellow",""),
            };
        }
    }

    public sealed class Event
    {
        [XmlAttribute("Time")]
        public int time;

        [XmlAttribute("Message")]
        public string message;

        [XmlAttribute("Color")]
        public string color;

        [XmlAttribute("Command")]
        public string command;

        public Event(int _time, string _message, string _color, string _command)
        {
            time = _time;
            message = _message;
            color = _color;
            command = _command;
        }

        public Event()
        {
            time = 0;
            message = "";
            color = "";
            command = "";
        }
    }
}