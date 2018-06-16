using System;
using System.Collections.Generic;
using System.Text;

namespace Encamina.workshop.Backend
{
    public static class DbInitializer
    {
        public static void Initialize(ConferenceContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
