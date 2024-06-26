using DemoNetCore.Models;

namespace DemoNetCore.Data
{
    public static class DbInitialize
    {
        public static void Initialize(ProjectContext projectContext)
        {
            projectContext.Database.EnsureCreated();

            if (projectContext.Staffs.Any()) return;

            var staffs = new Staff[]
            {
                new Staff{FullName="Nguyen van a", Address="Quảng Nam", Phone="0123123123", Sex=Sex.MALE},
                new Staff{FullName="Nguyen thi b", Address="Đà Nẵng", Phone="0567123123", Sex=Sex.FEMALE},
                new Staff{FullName="Nguyen ngoc c", Address="Huế", Phone="0123123456", Sex=Sex.FEMALE},
                new Staff{FullName="Nguyen chinh d", Address="Quảng Trị", Phone="0123456789", Sex=Sex.MALE},
                new Staff{FullName="Nguyen duc e", Address="Quảng Ngãi", Phone="0000000000", Sex=Sex.MALE},
            };
            foreach (Staff s in staffs)
            {
                projectContext.Staffs.Add(s);
            }
            projectContext.SaveChanges();

            var projects = new Project[]
            {
                new Project{CodeProject="PROJECT0001", NameProject="Warehouse management systems", Description="WMS", StartDate=DateTime.Now, EndDate=DateTime.Now.AddMonths(1), StatusProject=StatusProject.IN_PROGRESS},
                new Project{CodeProject="PROJECT0002", NameProject="Spa", Description="Spa", StartDate=DateTime.Now, EndDate=DateTime.Now.AddMonths(2), StatusProject=StatusProject.PENDING},
                new Project{CodeProject="PROJECT0003", NameProject="Retail Pos", Description="Pos", StartDate=DateTime.Now, EndDate=DateTime.Now.AddMonths(3), StatusProject=StatusProject.INIT},
            };
            foreach (var project in projects)
            {
                projectContext.Projects.Add(project);
            }
            projectContext.SaveChanges();

            var participants = new Participant[] {
                new Participant{StaffId=1, ProjectId=1,RoleProject=RoleProject.PM,Description="Project manager"},
                new Participant{StaffId=1, ProjectId=2,RoleProject=RoleProject.PM,Description="Project manager"},
                new Participant{StaffId=2, ProjectId=1,RoleProject=RoleProject.DEV,Description="Develop"},
                new Participant{StaffId=2, ProjectId=2,RoleProject=RoleProject.BA,Description="Business analyst"},
                new Participant{StaffId=3, ProjectId=1,RoleProject=RoleProject.DEV,Description="Develop"},
                new Participant{StaffId=3, ProjectId=2,RoleProject=RoleProject.PM,Description="Develop"},

            };
            foreach (var item in participants)
            {
                projectContext.Participants.Add(item);
            }
            projectContext.SaveChanges();
        }
    }

}
