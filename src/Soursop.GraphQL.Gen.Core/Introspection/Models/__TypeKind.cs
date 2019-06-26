﻿namespace Soursop.GraphQL.Gen.Core.Introspection.Models
{
    public enum __TypeKind
    {
        // Indicates this type is a scalar.
        SCALAR,
        // Indicates this type is an object. fields and interfaces are valid fields.
        OBJECT,
        // Indicates this type is an interface. fields and possibleTypes are valid fields.
        INTERFACE,
        // Indicates this type is a union. possibleTypes is a valid field.
        UNION,
        // Indicates this type is an enum. enumValues is a valid field.
        ENUM,
        // Indicates this type is an input object. inputFields is a valid field.
        INPUT_OBJECT,
        // Indicates this type is a list. ofType is a valid field.
        LIST,
        // Indicates this type is a non-null. ofType is a valid field.
        NON_NULL
    }
}
