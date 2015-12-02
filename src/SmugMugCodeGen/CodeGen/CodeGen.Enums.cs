﻿// Copyright (c) Alex Ghiondea. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using SmugMug.Shared.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmugMugCodeGen
{
    public partial class CodeGen
    {
        //TODO: This can probably be updated to 
        // Dictionary<string, List<HashSet<string>>>>
        // that way we don't have to do look-ups for the typename traversing the dictionary multiple times
        static Dictionary<string, HashSet<string>> mapTypeToMembers = new Dictionary<string, HashSet<string>>();

        //TODO: We need to be able to rename types
        // for now, hardcode it...
        static Dictionary<string, string> renameMap = new Dictionary<string, string>()
        {
            {"Status", "CommentStatus"},
            {"Status1", "ImageStatus"}
        };

        private static string GetEnumTypeName(SelectProperty prop)
        {
            string typeName = Helpers.NormalizeString(prop.Name);

            // find the enums that start with the same name
            var listOfEnum = mapTypeToMembers.Keys
                .Where(k => k.StartsWith(typeName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (listOfEnum.Count() == 1)
                return listOfEnum.First();

            // Creating the current props so that we don't re-run the normalize multiple times.
            HashSet<string> props = new HashSet<string>(prop.Options.Select(o => Helpers.NormalizeString(o)));

            //find the enum that contains all the required values
            foreach (var item in listOfEnum)
            {
                // get the list of enum values to look for
                HashSet<string> toSearchFor = new HashSet<string>(props);
                foreach (var looking in mapTypeToMembers[item])
                {
                    toSearchFor.Remove(Helpers.NormalizeString(looking));
                }
                if (toSearchFor.Count == 0)
                    return item;
            }

            // We should not get here
            throw new InvalidOperationException(string.Format("Could not find the enum {0}", typeName));
        }

        private void AnalyzeEnums(IEnumerable<Entity> list)
        {
            // get all the properties of the SelectProperty type
            var selectProps = list.SelectMany(p => p.Properties.Where(pp => pp is SelectProperty))
                .Cast<SelectProperty>()
                .OrderBy(prop => prop.Name)
                .ThenBy(prop => prop.Options.Count)
                .ToList();

            foreach (SelectProperty prop in selectProps)
            {
                string typeName = Helpers.NormalizeString(prop.Name);

                // TODO: A different data structure might help
                // find the enums that start with the same name
                var listOfEnum = mapTypeToMembers.Keys
                    .Where(k => k.StartsWith(typeName, StringComparison.OrdinalIgnoreCase));

                bool found = false;
                HashSet<string> existingMembers;
                foreach (var item in listOfEnum)
                {
                    existingMembers = mapTypeToMembers[item];

                    bool overlap = false;
                    foreach (var opt in prop.Options)
                    {
                        if (existingMembers.Contains(Helpers.NormalizeString(opt)))
                        {
                            overlap = true;
                            break;
                        }
                    }

                    if (overlap)
                    {
                        // let's merge the two
                        foreach (var opt in prop.Options)
                        {
                            existingMembers.Add(Helpers.NormalizeString(opt));
                        }
                        found = true;
                    }
                }

                if (!found)
                {
                    existingMembers = new HashSet<string>();
                    foreach (var item in prop.Options)
                    {
                        existingMembers.Add(Helpers.NormalizeString(item));
                    }

                    // Do we have a conflict?
                    int conflict = 1;
                    while (mapTypeToMembers.ContainsKey(typeName))
                        typeName += conflict.ToString();

                    mapTypeToMembers.Add(typeName, existingMembers);
                }
            }
        }

        public static Dictionary<string, string> BuildEnums()
        {
            Dictionary<string, string> enumTypeDefs = new Dictionary<string, string>();

            foreach (var item in mapTypeToMembers)
            {
                string typeName = item.Key;
                if (renameMap.ContainsKey(typeName))
                    typeName = renameMap[typeName];

                string enumCode = string.Format(Constants.EnumDefinition, typeName + "Enum", string.Join(",", item.Value));
                enumTypeDefs.Add(typeName, enumCode);
            }

            return enumTypeDefs;
        }
    }
}