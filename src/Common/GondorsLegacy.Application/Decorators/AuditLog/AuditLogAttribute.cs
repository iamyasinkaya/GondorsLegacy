using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GondorsLegacy.Application.Decorators.AuditLog;

/// <summary>
/// AuditLogAttribute, bir sınıfın denetim (audit) günlüğü özelliklerini belirtmek için kullanılan özel bir niteliktir.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class AuditLogAttribute : Attribute
{
    // Bu özel nitelik sınıfı, belirli bir sınıfın denetim günlüğü özelliklerini belirtmek amacıyla kullanılır.
    // Örneğin, bir sınıfın üzerine bu nitelik eklenirse, o sınıfın nesne oluşturulma ve değiştirilme gibi
    // işlemleri denetim günlüğüne kaydedilebilir. AttributeTargets.Class hedef tipini belirler, AllowMultiple ise
    // birden fazla bu niteliğin bir sınıfa eklenebileceğini ifade eder.

    // Özel nitelikler genellikle bir sınıfın metadatalarını belirlemek için kullanılır ve çalışma zamanında bu
    // metadatalara erişim sağlarlar. Bu sayede, sınıfların özel işlemler gerçekleştirmesi veya belirli durumlar için
    // işaretlenmesi sağlanabilir.
}
