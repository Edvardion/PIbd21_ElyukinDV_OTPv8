using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Repositories.Interfaces;
using TimeTable.Models;

namespace TimeTable.Repositories.Stubs
{
    public class GroupRepository : IGroupRepository
    {
        public void Add(Group group) => throw new NotImplementedException();
        public Group GetByName(string groupName) => throw new NotImplementedException();
        public IEnumerable<Group> GetAll() => new List<Group>();
        public void Update(Group group) => throw new NotImplementedException();
        public void Delete(string groupName) => throw new NotImplementedException();
    }
}
