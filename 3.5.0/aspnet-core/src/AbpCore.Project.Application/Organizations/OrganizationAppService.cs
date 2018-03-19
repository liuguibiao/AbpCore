using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.Organizations;
using Abp.UI;
using AbpCore.Project.Dto;
using AbpCore.Project.Extend;
using AbpCore.Project.Organizations.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbpCore.Project.Organizations
{
    public class OrganizationAppService : AsyncCrudAppService<OrganizationUnit, OrganizationDto, long, QueryPageBaseInput, CreateOrUpdateOrganizationDto, CreateOrUpdateOrganizationDto>, IOrganizationAppService
    {
        private readonly IRepository<OrganizationUnit, long> _iOrganizationUnit;
        private readonly OrganizationUnitManager _organizationUnitManager;
        private readonly ILocalizationContext _iLocalizationContext;
        public OrganizationAppService(
            IRepository<OrganizationUnit, long> iOrganizationUnit
            , OrganizationUnitManager organizationUnitManager
            , ILocalizationContext iLocalizationContext
            ) : base(iOrganizationUnit)
        {
            _iOrganizationUnit = iOrganizationUnit;
            _organizationUnitManager = organizationUnitManager;
            _iLocalizationContext = iLocalizationContext;
        }

        public async Task CreateAsync(CreateOrUpdateOrganizationDto input)
        {
            var organizationUnit = new OrganizationUnit
            {
                DisplayName = input.DisplayName,
                ParentId = input.ParentId,
            };
            await _organizationUnitManager.CreateAsync(organizationUnit);
        }

        public async Task<List<OrganizationUnit>> FindChildrenAsync(long? parentId, bool recursive = false)
        {
            var entitys = await _organizationUnitManager.FindChildrenAsync(parentId, recursive);
            return entitys;
        }

        public async Task<string> GetCodeAsync(long id)
        {
            var codes = await _organizationUnitManager.GetCodeAsync(id);
            return codes;
        }

        public async Task<OrganizationUnit> GetLastChildOrNullAsync(long? parentId)
        {
            var entity = await _organizationUnitManager.GetLastChildOrNullAsync(parentId);
            return entity;
        }

        public async Task<string> GetNextChildCodeAsync(long? parentId)
        {
            var code = await _organizationUnitManager.GetNextChildCodeAsync(parentId);
            return code;
        }

        public async Task MoveAsync(long id, long? parentId)
        {
            await _organizationUnitManager.MoveAsync(id, parentId);
        }

        public async Task UpdateAsync(CreateOrUpdateOrganizationDto createOrUpdateOrganizationDto)
        {
            var organizationUnit = await _iOrganizationUnit.FirstOrDefaultAsync(createOrUpdateOrganizationDto.Id);
            if (organizationUnit == null)
                throw new UserFriendlyException(Tow.DataAnomaly.TL());
            organizationUnit.ParentId = createOrUpdateOrganizationDto.ParentId;
            organizationUnit.DisplayName = createOrUpdateOrganizationDto.DisplayName;
            await _organizationUnitManager.UpdateAsync(organizationUnit);
        }
    }
}
