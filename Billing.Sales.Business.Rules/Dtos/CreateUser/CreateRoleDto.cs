using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Entities.Dtos.CreateUser;

public class CreateRoleDto
{
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<UserRoleDto> UserRoles { get; set; } = new List<UserRoleDto>();
    
}
