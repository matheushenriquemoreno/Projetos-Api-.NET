using System;
using System.Collections.Generic;
using System.Text;

namespace Localica.Frotas.Infra.Singleton
{
    public class SingletonContainer
    {
       public Guid Id { get; } = Guid.NewGuid();
    }
}
