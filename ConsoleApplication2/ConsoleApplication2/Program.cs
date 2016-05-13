using System;
using FeatureToggle.Core;
using FeatureToggle.Core.Fluent;
using FeatureToggle.Toggles;

/*
    FixedTimeCacheDecorator
    FallbackValueDecorator
    CompositeOrDecorator
    CompositeAndDecorator - true if all “child” toggles are enabled
    DefaultToDisabledOnErrorDecorator - If an error occurs evaluating the toggle value, just default to disabled (use with caution)
    DefaultToEnabledOnErrorDecorator - If an error occurs evaluating the toggle value, just default to enabled (use with caution)
    FixedTimeCacheDecorator - Caches he underlying toggle value for expensive toggle lookups (sql server, remote http, etc)
*/
namespace ConsoleApplication2
{
    internal class Program
    {
        private static void Main()
        {
            

            Console.WriteLine(Is<MyFeatureOn>.Enabled ? "Enabled" : "Disabled");
            Console.WriteLine(Is<MyFeatureOff>.Enabled ? "Enabled" : "Disabled");

            Console.WriteLine(new MyFeatureDateAfter().FeatureEnabled ? "Enabled" : "Disabled");
            Console.WriteLine(new MyFeatureDateBefore().FeatureEnabled ? "Enabled" : "Disabled");
            Console.WriteLine(new MyFeatureDateBetween().FeatureEnabled ? "Enabled" : "Disabled");

            Console.WriteLine(new MyFeatureSimple().FeatureEnabled ? "Enabled" : "Disabled");
            Console.WriteLine(new MyFeatureRandom().FeatureEnabled ? "Enabled" : "Disabled");

            Console.WriteLine(new MyFeatureWeekDay().FeatureEnabled ? "Enabled" : "Disabled");
            Console.WriteLine(new MyFeatureSql().FeatureEnabled ? "Enabled" : "Disabled");

            Console.WriteLine(new MyFeatureVersion().FeatureEnabled ? "Enabled" : "Disabled");

            var composite = new FallbackValueDecorator(new MyFeatureFaulty(), new MyFeatureOn());

            //Console.WriteLine(new MyFeatureFaulty().FeatureEnabled ? "f Enabled" : "f Disabled");
            Console.WriteLine(composite.FeatureEnabled ? "c Enabled" : "c Disabled");

            Console.ReadKey();
        }
    }
    

    public class MyFeatureOff2 : HttpJsonFeatureToggle { } // no config

    public class MyFeatureOff : AlwaysOffFeatureToggle { } // no config

    public class MyFeatureOn : AlwaysOnFeatureToggle { } // no config

    public class MyFeatureFaulty : EnabledOnOrAfterDateFeatureToggle { } // config date

    public class MyFeatureDateAfter : EnabledOnOrAfterDateFeatureToggle { } // config date

    public class MyFeatureDateBefore : EnabledOnOrBeforeDateFeatureToggle { } // config date

    public class MyFeatureDateBetween : EnabledBetweenDatesFeatureToggle { } // config date interval

    public class MyFeatureSimple : SimpleFeatureToggle { } // config on/off

    public class MyFeatureRandom : RandomFeatureToggle { } // no config

    public class MyFeatureWeekDay : EnabledOnDaysOfWeekFeatureToggle { } // config weekdays

    public class MyFeatureSql : SqlFeatureToggle { } // config connection string and sql

    public class MyFeatureVersion : EnabledOnOrAfterAssemblyVersionWhereToggleIsDefinedToggle { } // config version number like 1.0 or 1.0.0 or 1.0.0.0
}
