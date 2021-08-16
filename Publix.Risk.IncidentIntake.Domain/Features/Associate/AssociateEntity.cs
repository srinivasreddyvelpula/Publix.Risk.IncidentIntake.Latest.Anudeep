using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using System;


namespace Publix.Risk.IncidentIntake.Domain.Features.Associate
{
    public class AssociateEntity
    {
        public AssociateEntity()
        {
            PERNR = string.Empty;
            HireDate = null;
            FullTime = false;
            EntityId = 0;
            Entity = new EntityEntity();
            DepartmentId = null;
            Department = null;
        }


        public AssociateEntity(string pernr, DateTime? hireDate, bool fullTime, int entityId, EntityEntity entity, int? departmentId, EntityEntity? department)
        {
            PERNR = pernr;
            HireDate = hireDate;
            FullTime = fullTime;
            EntityId = entityId;
            Entity = entity;
            DepartmentId = departmentId;
            Department = department;
        }


        public string PERNR { get; private set; }

        public DateTime? HireDate { get; private set; }

        public bool FullTime { get; private set; }

        public int EntityId { get; private set; }

        public virtual EntityEntity Entity { get; private set; }

        public int? DepartmentId { get; private set; }

        public virtual EntityEntity? Department { get; private set; }

    }
}