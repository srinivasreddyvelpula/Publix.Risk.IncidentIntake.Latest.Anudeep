using MediatR;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.Domain.Features.Entity
{
    public class CreateEntityCommand : IRequest<CreateEntityResult>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Abbreviation { get; set; }
        public string? AlsoKnownAs { get; set; }
        public string? Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public string? City { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string? ZipCode { get; set; }
        public int? TypeCodeId { get; set; }    // Entity Table ID / Glossary ID
        public int? ParentEId { get; set; }
        public int? DeptEId { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? TaxId { get; set; }
        public int? SexId { get; set; }
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? Minor { get; set; }
        public int? InvolvementId { get; set; }
        public string? SpousesName { get; set; }
        public string? GaurdiansName { get; set; }
    }


    public class CreateEntityResult
    {
        public EntityEntity? Entity { get; set; }
    }


    public class CreateEntityCommandHandler : IRequestHandler<CreateEntityCommand, CreateEntityResult>
    {
        private ILogger Logger { get; }

        private IAssureClaimsRepository claimsRepo { get; }

        public CreateEntityCommandHandler(ILogger logger, IAssureClaimsRepository repo)
        {
            Logger = logger;
            claimsRepo = repo;
        }

        public async Task<CreateEntityResult> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await claimsRepo.CreateEntity(request);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, null, request);
                throw;
            }
        }
    }
}
