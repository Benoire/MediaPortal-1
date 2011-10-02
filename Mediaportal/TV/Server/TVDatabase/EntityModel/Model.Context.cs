//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Objects;
using System.Data.EntityClient;
using Mediaportal.TV.Server.TVDatabase.Entities;
using Version = System.Version;

namespace Mediaportal.TV.Server.TVDatabase.EntityModel
{
    public partial class Model : ObjectContext
    {
        public const string ConnectionString = "name=Model";
        public const string ContainerName = "Model";
    
        #region Constructors
    
        public Model()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public Model(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public Model(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<CanceledSchedule> CanceledSchedules
        {
            get { return _canceledSchedules  ?? (_canceledSchedules = CreateObjectSet<CanceledSchedule>("CanceledSchedules")); }
        }
        private ObjectSet<CanceledSchedule> _canceledSchedules;
    
        public ObjectSet<Card> Cards
        {
            get { return _cards  ?? (_cards = CreateObjectSet<Card>("Cards")); }
        }
        private ObjectSet<Card> _cards;
    
        public ObjectSet<CardGroup> CardGroups
        {
            get { return _cardGroups  ?? (_cardGroups = CreateObjectSet<CardGroup>("CardGroups")); }
        }
        private ObjectSet<CardGroup> _cardGroups;
    
        public ObjectSet<CardGroupMap> CardGroupMaps
        {
            get { return _cardGroupMaps  ?? (_cardGroupMaps = CreateObjectSet<CardGroupMap>("CardGroupMaps")); }
        }
        private ObjectSet<CardGroupMap> _cardGroupMaps;
    
        public ObjectSet<Channel> Channels
        {
            get { return _channels  ?? (_channels = CreateObjectSet<Channel>("Channels")); }
        }
        private ObjectSet<Channel> _channels;
    
        public ObjectSet<ChannelGroup> ChannelGroups
        {
            get { return _channelGroups  ?? (_channelGroups = CreateObjectSet<ChannelGroup>("ChannelGroups")); }
        }
        private ObjectSet<ChannelGroup> _channelGroups;
    
        public ObjectSet<ChannelLinkageMap> ChannelLinkageMaps
        {
            get { return _channelLinkageMaps  ?? (_channelLinkageMaps = CreateObjectSet<ChannelLinkageMap>("ChannelLinkageMaps")); }
        }
        private ObjectSet<ChannelLinkageMap> _channelLinkageMaps;
    
        public ObjectSet<ChannelMap> ChannelMaps
        {
            get { return _channelMaps  ?? (_channelMaps = CreateObjectSet<ChannelMap>("ChannelMaps")); }
        }
        private ObjectSet<ChannelMap> _channelMaps;
    
        public ObjectSet<Conflict> Conflicts
        {
            get { return _conflicts  ?? (_conflicts = CreateObjectSet<Conflict>("Conflicts")); }
        }
        private ObjectSet<Conflict> _conflicts;
    
        public ObjectSet<DisEqcMotor> DisEqcMotors
        {
            get { return _disEqcMotors  ?? (_disEqcMotors = CreateObjectSet<DisEqcMotor>("DisEqcMotors")); }
        }
        private ObjectSet<DisEqcMotor> _disEqcMotors;
    
        public ObjectSet<Favorite> Favorites
        {
            get { return _favorites  ?? (_favorites = CreateObjectSet<Favorite>("Favorites")); }
        }
        private ObjectSet<Favorite> _favorites;
    
        public ObjectSet<GroupMap> GroupMaps
        {
            get { return _groupMaps  ?? (_groupMaps = CreateObjectSet<GroupMap>("GroupMaps")); }
        }
        private ObjectSet<GroupMap> _groupMaps;
    
        public ObjectSet<History> Histories
        {
            get { return _histories  ?? (_histories = CreateObjectSet<History>("Histories")); }
        }
        private ObjectSet<History> _histories;
    
        public ObjectSet<Keyword> Keywords
        {
            get { return _keywords  ?? (_keywords = CreateObjectSet<Keyword>("Keywords")); }
        }
        private ObjectSet<Keyword> _keywords;
    
        public ObjectSet<KeywordMap> KeywordMaps
        {
            get { return _keywordMaps  ?? (_keywordMaps = CreateObjectSet<KeywordMap>("KeywordMaps")); }
        }
        private ObjectSet<KeywordMap> _keywordMaps;
    
        public ObjectSet<PendingDeletion> PendingDeletions
        {
            get { return _pendingDeletions  ?? (_pendingDeletions = CreateObjectSet<PendingDeletion>("PendingDeletions")); }
        }
        private ObjectSet<PendingDeletion> _pendingDeletions;
    
        public ObjectSet<PersonalTVGuideMap> PersonalTVGuideMaps
        {
            get { return _personalTVGuideMaps  ?? (_personalTVGuideMaps = CreateObjectSet<PersonalTVGuideMap>("PersonalTVGuideMaps")); }
        }
        private ObjectSet<PersonalTVGuideMap> _personalTVGuideMaps;
    
        public ObjectSet<Program> Programs
        {
            get { return _programs  ?? (_programs = CreateObjectSet<Program>("Programs")); }
        }
        private ObjectSet<Program> _programs;
    
        public ObjectSet<ProgramCategory> ProgramCategories
        {
            get { return _programCategories  ?? (_programCategories = CreateObjectSet<ProgramCategory>("ProgramCategories")); }
        }
        private ObjectSet<ProgramCategory> _programCategories;
    
        public ObjectSet<ProgramCredit> ProgramCredits
        {
            get { return _programCredits  ?? (_programCredits = CreateObjectSet<ProgramCredit>("ProgramCredits")); }
        }
        private ObjectSet<ProgramCredit> _programCredits;
    
        public ObjectSet<RadioChannelGroup> RadioChannelGroups
        {
            get { return _radioChannelGroups  ?? (_radioChannelGroups = CreateObjectSet<RadioChannelGroup>("RadioChannelGroups")); }
        }
        private ObjectSet<RadioChannelGroup> _radioChannelGroups;
    
        public ObjectSet<RadioGroupMap> RadioGroupMaps
        {
            get { return _radioGroupMaps  ?? (_radioGroupMaps = CreateObjectSet<RadioGroupMap>("RadioGroupMaps")); }
        }
        private ObjectSet<RadioGroupMap> _radioGroupMaps;
    
        public ObjectSet<Recording> Recordings
        {
            get { return _recordings  ?? (_recordings = CreateObjectSet<Recording>("Recordings")); }
        }
        private ObjectSet<Recording> _recordings;
    
        public ObjectSet<RuleBasedSchedule> RuleBasedSchedules
        {
            get { return _ruleBasedSchedules  ?? (_ruleBasedSchedules = CreateObjectSet<RuleBasedSchedule>("RuleBasedSchedules")); }
        }
        private ObjectSet<RuleBasedSchedule> _ruleBasedSchedules;
    
        public ObjectSet<Satellite> Satellites
        {
            get { return _satellites  ?? (_satellites = CreateObjectSet<Satellite>("Satellites")); }
        }
        private ObjectSet<Satellite> _satellites;
    
        public ObjectSet<Schedule> Schedules
        {
            get { return _schedules  ?? (_schedules = CreateObjectSet<Schedule>("Schedules")); }
        }
        private ObjectSet<Schedule> _schedules;
    
        public ObjectSet<ScheduleRulesTemplate> ScheduleRulesTemplates
        {
            get { return _scheduleRulesTemplates  ?? (_scheduleRulesTemplates = CreateObjectSet<ScheduleRulesTemplate>("ScheduleRulesTemplates")); }
        }
        private ObjectSet<ScheduleRulesTemplate> _scheduleRulesTemplates;
    
        public ObjectSet<Entities.Server> Servers
        {
          get { return _servers ?? (_servers = CreateObjectSet<Entities.Server>("Servers")); }
        }
        private ObjectSet<Entities.Server> _servers;
    
        public ObjectSet<Setting> Settings
        {
            get { return _settings  ?? (_settings = CreateObjectSet<Setting>("Settings")); }
        }
        private ObjectSet<Setting> _settings;
    
        public ObjectSet<SoftwareEncoder> SoftwareEncoders
        {
            get { return _softwareEncoders  ?? (_softwareEncoders = CreateObjectSet<SoftwareEncoder>("SoftwareEncoders")); }
        }
        private ObjectSet<SoftwareEncoder> _softwareEncoders;
    
        public ObjectSet<Timespan> Timespans
        {
            get { return _timespans  ?? (_timespans = CreateObjectSet<Timespan>("Timespans")); }
        }
        private ObjectSet<Timespan> _timespans;
    
        public ObjectSet<TuningDetail> TuningDetails
        {
            get { return _tuningDetails  ?? (_tuningDetails = CreateObjectSet<TuningDetail>("TuningDetails")); }
        }
        private ObjectSet<TuningDetail> _tuningDetails;
    
        public ObjectSet<TvMovieMapping> TvMovieMappings
        {
            get { return _tvMovieMappings  ?? (_tvMovieMappings = CreateObjectSet<TvMovieMapping>("TvMovieMappings")); }
        }
        private ObjectSet<TvMovieMapping> _tvMovieMappings;
    
        public ObjectSet<Version> Versions
        {
            get { return _versions  ?? (_versions = CreateObjectSet<Version>("Versions")); }
        }
        private ObjectSet<Version> _versions;

        #endregion
    }
}
