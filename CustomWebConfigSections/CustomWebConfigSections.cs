using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace bla bla bla
{
    public class GroupMap
    {
        public KeyValuePair<string, Map> GroupedMap;

        public GroupMap(string unickey, Map map)
        {
            GroupedMap = new KeyValuePair<string, Map>(unickey, map);
        }
    }

    public class Map
    {
        public KeyValuePair<string, string> Mapping;

        public Map(string product, string usergroup)
        {
            Mapping = new KeyValuePair<string, string>(product, usergroup);
        }
    }

    public class GroupMapping : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            return CreateStatic(parent, section);
        }

        internal static object CreateStatic(object parent, XmlNode section)
        {
            var a = new object();
            foreach (XmlNode child in section.ChildNodes)
            {
               
                
            }
            return a;
        }

        internal static string RemoveRequiredAttribute(XmlNode node, string name)
        {
            return RemoveRequiredAttribute(node, name, false/*allowEmpty*/);
        }

        internal static string RemoveRequiredAttribute(XmlNode node, string name, bool allowEmpty)
        {
            XmlNode attribute = node.Attributes.RemoveNamedItem(name);

            if (attribute == null)
            {
                throw new ConfigurationErrorsException(
                                string.Format("missing missing attribute {0}",name),
                                node);
            }

            if (String.IsNullOrEmpty(attribute.Value) && allowEmpty == false)
            {
                throw new ConfigurationErrorsException(
                                string.Format("missing missing attribute {0}", name),
                                node);
            }

            return attribute.Value;
        }

        internal static void CheckForUnrecognizedAttributes(XmlNode node)
        {
            if (node.Attributes != null && node.Attributes.Count != 0)
            {
                 throw new ConfigurationErrorsException("contains UnrecognizedAttributes",node);
                
            }
        }

        internal static bool IsIgnorableAlsoCheckForNonElement(XmlNode node)
        {
            if (node.NodeType == XmlNodeType.Comment || node.NodeType == XmlNodeType.Whitespace)
            {
                return true;
            }

            CheckForNonElement(node);

            return false;
        }

        internal static void CheckForNonElement(XmlNode node)
        {
            if (node.NodeType != XmlNodeType.Element)
            {
                throw new ConfigurationErrorsException(
                                "contains NonElement",node);
            }
        }
    }
}