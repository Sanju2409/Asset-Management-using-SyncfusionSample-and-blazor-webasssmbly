using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SyncfusionSample.Products;
using SyncfusionSample.Projects;
using Volo.Abp.DependencyInjection;


namespace SyncfusionSample.Data2
{
    public class SampleDataService : ISingletonDependency
    {
        private List<ProjectDto> DataSource = new List<ProjectDto>()
        {
            new ProjectDto
            {
                Id = Guid.NewGuid(),
                Name= "Project1",
                Description="dcfgvhb",
                URL="https://ghbjn"
            },
             new ProjectDto
            {
                Id = Guid.NewGuid(),
                Name= "Project2",
                Description="dvbvhb",
                URL="https://gdbjn"
            }
        };
        public List<ProjectDto> GetProjects()
        {
            return DataSource;
        }

        public ProjectDto GetProject(Guid id)
        {
            return DataSource.SingleOrDefault(x => x.Id == id);
        }
        public ProjectDto CreateProject(ProjectDto input)
        {
            DataSource.Add(new ProjectDto
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                URL= input.URL

            });

            return input;
        }
        public ProjectDto UpdateProject(ProjectDto input)
        {
            DeleteProject(input);
            CreateProject(input);

            return input;
        }
        public void DeleteProject(ProjectDto input) 
        {
            DataSource.Remove(input);
        }


    }
}
