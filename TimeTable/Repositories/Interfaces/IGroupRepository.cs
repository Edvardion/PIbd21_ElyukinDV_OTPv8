using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Repositories.Interfaces
{
   public interface IGroupRepository
{
    void Add(Group group);
    Group GetByName(string groupName);
    IEnumerable<Group> GetAll();
    void Update(Group group);
    void Delete(string groupName);
}
}
