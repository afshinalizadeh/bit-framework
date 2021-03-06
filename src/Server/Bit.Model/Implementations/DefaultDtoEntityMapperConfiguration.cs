﻿using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using AutoMapper;
using Bit.Model.Contracts;

namespace Bit.Model.Implementations
{
    public class DefaultDtoEntityMapperConfiguration : IDtoEntityMapperConfiguration
    {
        public virtual void Configure(IMapperConfigurationExpression mapperConfigExpression)
        {
            mapperConfigExpression.ValidateInlineMaps = false;

            mapperConfigExpression.CreateMissingTypeMaps = true;

            bool MapperPropConfigurationCondition(PropertyMap p)
            {
                return (p.DestinationProperty.GetCustomAttribute<ForeignKeyAttribute>() != null || p.DestinationProperty.GetCustomAttribute<InversePropertyAttribute>() != null)
                       && !typeof(IEnumerable).IsAssignableFrom(p.DestinationProperty.ReflectedType)
                       && typeof(IDto).IsAssignableFrom(p.DestinationProperty.ReflectedType);
            }

            mapperConfigExpression.ForAllPropertyMaps(MapperPropConfigurationCondition, (p, member) =>
            {
                p.Ignored = true;
            });
        }
    }
}
