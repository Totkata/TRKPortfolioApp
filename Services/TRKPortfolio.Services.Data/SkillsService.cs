namespace TRKPortfolio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Data.Common.Repositories;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.ViewModels.Administration.Categories.ViewModel;
    using TRKPortfolio.Web.ViewModels.Administration.Skills.InputModel;
    using TRKPortfolio.Web.ViewModels.Administration.Skills.ViewModel;

    public class SkillsService : ISkillsService
    {
        private readonly IDeletableEntityRepository<Skill> skillRepository;

        public SkillsService(IDeletableEntityRepository<Skill> skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public async Task CreateAsync(CreateSkillInputModel input)
        {
            var skillExists = this.skillRepository.AllAsNoTracking()
                .Any(x => x.SkillTitle == input.Name);

            if (!skillExists)
            {
                var skill = new Skill
                {
                    SkillTitle = input.Name,
                };

                await this.skillRepository.AddAsync(skill);
                await this.skillRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<SkillViewModel> GetAll()
        {
            var skills = this.skillRepository.AllAsNoTracking().To<SkillViewModel>().ToList();
            return skills;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.skillRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.SkillTitle,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.SkillTitle));
        }
    }
}
