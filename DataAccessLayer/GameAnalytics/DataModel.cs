using LinqToDB.Mapping;
using System;

namespace DataAccessLayer.GameAnalytics
{
    public interface GameId
    {
        long GameId { get; set; }
    }

    public interface GameUserId
    {
        long GameUserId { get; set; }
    }


    public interface IId
    {
        long Id { get; set; }
    }


    [Table(Name = "GAMES", Database = "game_analytics")]
    public class Games : IId
    {      
        [Column(Name = "GAME_ID", IsPrimaryKey = true)]
        [PrimaryKey]
        public long Id { get; set; }

        [Column(Name = "GAME_NAME")]
        public string Name { get; set; }
    }

    [Table(Name = "GAMES", Database = "game_analytics")]
    public class EventsLog : IId
    {
        [Column(Name = "EVENTS_LOG_ID")]
        public long Id { get; set; }

        [Column(Name = "EVENT_GAME_ID")]
        public long EventGameId { get; set; }

        [Column(Name = "EVENT_TYPE_ID")]
        public long EventTypeId { get; set; }

        [Column(Name = "EVENT_DATA")]
        public string EventData { get; set; }
    }

    [Table(Name = "HEATMAPS", Database = "game_analytics")]
    public class Heatmaps : IId
    {
        [Column(Name = "HEATMAP_ID")]
        public long Id { get; set; }

        [Column(Name = "SESSION_ID")]
        public string SessionId { get; set; }

        [Column(Name = "GAME_ID")]
        public long GameId;

        [Column(Name = "DATA")]
        public string Data { get; set; }

        [Column(Name = "USER_ID")]
        public long UserId { get; set; }

        [Column(Name = "CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "SCENE_NAME")]
        public string SceneName { get; set; }
    }
}
