using Publix.Risk.IncidentIntake.Domain.Features.Code;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Publix.Risk.IncidentIntake.Domain.ValueObjects
{
    public class CodeType : Enumeration<CodeType, int>
    {
        public string ListType { get; }
        [JsonIgnore]
        public int TableId { get; }
        [JsonIgnore]
        public int? FilterId { get; }
        public List<CodeEntity> Codes { get; private set; }
        public string Name
        {
            get { return base.Description; }
        }

        public int CodeTypeId
        {
            get { return this.Value; }
        }

        [JsonIgnore]
        public new string Description { get; }

        private CodeType(int value, string name, string listType, int tableId, int? filterId = null) : base(value, name)
        {
            ListType = listType;
            TableId = tableId;
            FilterId = filterId;
            Codes = new List<CodeEntity>();
        }


        public static readonly CodeType YesNoOnly = new CodeType(10, "Yes No Only", "Simple", 2031);
        public static readonly CodeType YesNoUnkown = new CodeType(20, "Yes No", "Simple", 1241);
        public static readonly CodeType AccidentTypes = new CodeType(100, "Accident Type", "Simple", 1090);
        public static readonly CodeType BodyParts = new CodeType(200, "Body Part", "Simple", 1021);
        public static readonly CodeType InjuryTypes = new CodeType(300, "Injury Type", "Simple", 1026);
        public static readonly CodeType InjurySources = new CodeType(400, "Injury Source", "Simple", 2073);
        public static readonly CodeType InjuryCauses = new CodeType(500, "Injury Cause", "Simple", 2066);
        public static readonly CodeType InvolvementTypes = new CodeType(600, "Involvement Types", "Simple", 2069);
        public static readonly CodeType ProductCategories = new CodeType(700, "Product Category", "Simple", 2045);
        public static readonly CodeType TimeOfDay = new CodeType(800, "Time of Day", "Simple", 2037);
        public static readonly CodeType WeatherConditions = new CodeType(900, "Weather Condition", "Simple", 2036);
        public static readonly CodeType DispatchLocations = new CodeType(1000, "Locations", "Hierarchical", 0);
        public static readonly CodeType VehicleTypes = new CodeType(1100, "Vehicle Type", "Simple", 1059);
        public static readonly CodeType Shifts = new CodeType(1200, "Shifts", "Simple", 2070);
        public static readonly CodeType ActivityEngagements = new CodeType(1300, "Activities", "Simple", 2078);
        public static readonly CodeType InsideOutside = new CodeType(1400, "Inside Outside", "Simple", 2046);
        public static readonly CodeType ResponsibleDept = new CodeType(1500, "Department", "Hierarchical", 1012);
        public static readonly CodeType IncidentLocations = new CodeType(1600, "Incident Location", "Simple", 2032);
        public static readonly CodeType ClaimTypes = new CodeType(1700, "Claim Type", "Simple", 1023);
        public static readonly CodeType IncidentTypes = new CodeType(1800, "Incident Type", "Simple", 2104);
        public static readonly CodeType FloorTypes = new CodeType(1900, "Flood Type", "Simple", 2049);
        public static readonly CodeType LocationEquipment = new CodeType(2000, "Location Equipment", "Simple", 2055);
        public static readonly CodeType Chemicals = new CodeType(2100, "Chemicals", "Simple", 2056);
        public static readonly CodeType FlooColors = new CodeType(2200, "Floor Color", "Simple", 2048);
        public static readonly CodeType TripTypes = new CodeType(2300, "Trip Type", "Simple", 2034);
        public static readonly CodeType StruckByObjects = new CodeType(2400, "Struck By Objects", "Simple", 2035);
        public static readonly CodeType NotificationMethods = new CodeType(2500, "Notification Method", "Simple", 2044);
        public static readonly CodeType CloseMethods = new CodeType(2600, "Close Method", "Simple", 2139);
        public static readonly CodeType RxTypes = new CodeType(2700, "Rx Type", "Simple", 2062);
        public static readonly CodeType TransmitMethods = new CodeType(2800, "Transmit Methods", "Simple", 2063);
        public static readonly CodeType ErrorDiscoveryMethods = new CodeType(2900, "Discovery Method", "Simple", 2064);
        public static readonly CodeType Sex = new CodeType(3000, "Sex", "Simple", 1033);
        public static readonly CodeType Country = new CodeType(3100, "Country", "Simple", 1772);
        public static readonly CodeType CartDamageCause = new CodeType(3200, "Cart Damage Cause", "Simple", 2042);
        public static readonly CodeType PrimaryLanguage = new CodeType(3300, "Primary Language", "Simple", 1240);
        public static readonly CodeType States = new CodeType(3400, "States", "Simple", 2153);
        public static readonly CodeType ActivityEngagedIn = new CodeType(3500, "Activity Engaged In", "Simple", 2078);
        public static readonly CodeType LocationTypes = new CodeType(3600, "Location Types", "Simple", 1028);
        public static readonly CodeType LossCategories = new CodeType(3700, "Loss Categories", "Simple", 2038);
        public static readonly CodeType PrimaryLocations = new CodeType(3800, "Primary Locations", "Simple", 1032);

        public List<CodeEntity> SetCodes(List<CodeEntity> codeList)
        {
            Codes = codeList;

            return Codes;
        }
    }
}
