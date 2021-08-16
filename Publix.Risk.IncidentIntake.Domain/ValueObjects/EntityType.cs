namespace Publix.Risk.IncidentIntake.Domain.ValueObjects
{
    public class EntityType : Enumeration<EntityType, int>
    {
        public bool CanBeCreated { get; } = false;

        public EntityType(int value) : base(value)
        {
            var et = EntityType.FromValue(value);
            this.CanBeCreated = et?.CanBeCreated ?? false;
        }

        private EntityType(int value, string description, bool canBeCreated = false) : base(value, description)
        {
            CanBeCreated = canBeCreated;
        }


        public static readonly EntityType Client = new EntityType(1005, "Client");
        public static readonly EntityType Company = new EntityType(1006, "Company");
        public static readonly EntityType Operation = new EntityType(1060, "Operation");
        public static readonly EntityType Region = new EntityType(1060, "Region");
        public static readonly EntityType Division = new EntityType(1060, "Division");
        public static readonly EntityType Location = new EntityType(1060, "Location");
        public static readonly EntityType Facility = new EntityType(1060, "Facility");
        public static readonly EntityType Department = new EntityType(1060, "Department");
        public static readonly EntityType OtherPeople = new EntityType(1060, "Other People", true);
        public static readonly EntityType Employee = new EntityType(1060, "Employee");
        public static readonly EntityType Witness = new EntityType(1060, "Witness", true);
        public static readonly EntityType Passenger = new EntityType(1060, "Passenger", true);
        public static readonly EntityType Drivers = new EntityType(1060, "Drivers", true);
        public static readonly EntityType OtherEmployees = new EntityType(1060, "Other Employee", true);
        public static readonly EntityType Vendor = new EntityType(1060, "Vendor");
    }
}
