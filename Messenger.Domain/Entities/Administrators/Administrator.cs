using System.ComponentModel.DataAnnotations.Schema;
using CSN.Domain.Entities.Accounts;

namespace CSN.Domain.Entities.Administrators;

[Table("Administrators")]
public partial class Administrator : Account { }
