﻿using Hydra.Discovery;
using Hydra.Discovery.SupportedClasses;
using Hydra.Discovery.SupportedOperations;
using Hydra.Discovery.SupportedProperties;
using JsonLD.Entities;
using Nancy;
using Nancy.Bootstrapper;

namespace Hydra.Nancy
{
    /// <summary>
    /// Registrations of all necessary components
    /// </summary>
    public class HydraRegistrations : Registrations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HydraRegistrations"/> class.
        /// </summary>
        public HydraRegistrations(ITypeCatalog catalog) : base(catalog)
        {
            RegisterWithDefault<IApiDocumentationFactory>(typeof(ApiDocumentationFactory), Lifetime.PerRequest);
            RegisterWithDefault<IRdfTypeProviderPolicy>(typeof(AttributeRdfTypeProviderPolicy));
            RegisterWithDefault<ISupportedPropertySelectionPolicy>(typeof(DefaultPropertiesSelectionPolicy));
            RegisterWithDefault<ISupportedPropertyFactory>(typeof(DefaultSupportedPropertyFactory), Lifetime.PerRequest);
            RegisterWithDefault<ISupportedClassFactory>(typeof(DefaultSupportedClassFactory), Lifetime.PerRequest);
            RegisterWithDefault<ISupportedPropertyMetaProvider>(typeof(DefaultSupportedPropertyMetaProvider));
            RegisterWithDefault<ISupportedClassMetaProvider>(typeof(DefaultSupportedClassMetaProvider));
            RegisterWithDefault<IPropertyPredicateIdPolicy>(typeof(DefaultPropertyIdPolicy));
            RegisterWithDefault<IPropertyRangeRetrievalPolicy>(typeof(DefaultPropertyRangeRetrievalPolicy), Lifetime.PerRequest);
            RegisterWithDefault<ISupportedOperationFactory>(typeof(DefaultSupportedOperationFactory), Lifetime.PerRequest);
            RegisterWithDefault<IContextProvider>(typeof(NullContextProvider));
            RegisterWithUserThenDefault<IDocumentedTypeSelector>(new[]
            {
                typeof(HydraBuiltInTypesSelector)
            });
            Register<IPropertyRangeMappingPolicy>(new[]
            {
                typeof(XsdDatatypesMappingPolicy),
                typeof(XsdDatatypesNullablesMappingPolicy),
                typeof(SupportedClassRangeMappingPolicy),
            });
        }
    }
}
