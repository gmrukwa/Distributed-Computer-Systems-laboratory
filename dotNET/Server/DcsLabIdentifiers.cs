/******************************************************************************
**
** <auto-generated>
**     This code was generated by a tool: UaModeler
**     Runtime Version: 1.5.2, using .NET Server 2.5.0 template (version 3)
**
**     Changes to this file may cause incorrect behavior and will be lost if
**     the code is regenerated.
**
**     Generated by Grzegorz Mrukwa <Grzegorz.Mrukwa@polsl.pl>
** </auto-generated>
**
** Copyright (c) 2006-2018 Unified Automation GmbH All rights reserved.
**
** Software License Agreement ("SLA") Version 2.6
**
** Unless explicitly acquired and licensed from Licensor under another
** license, the contents of this file are subject to the Software License
** Agreement ("SLA") Version 2.6, or subsequent versions
** as allowed by the SLA, and You may not copy or use this file in either
** source code or executable form, except in compliance with the terms and
** conditions of the SLA.
**
** All software distributed under the SLA is provided strictly on an
** "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED,
** AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
** LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
** PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the SLA for specific
** language governing rights and limitations under the SLA.
**
** Project: .NET OPC UA SDK information model for namespace http://yourorganisation.org/DCS-lab/
**
** Description: OPC Unified Architecture Software Development Kit.
**
** The complete license agreement can be found here:
** http://unifiedautomation.com/License/SLA/2.6/
**
** Created: 07.01.2018
**
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using UnifiedAutomation.UaBase;

namespace PolslMacrocourse.DcsLab
{
    #region DataType Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class DataTypes
    {
    }
    #endregion

    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the Controllers Object.
        /// </summary>
        public const uint Controllers = 5003;

    }
    #endregion

    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the StationType ObjectType.
        /// </summary>
        public const uint StationType = 1002;

        /// <summary>
        /// The identifier for the AssemblyStationType ObjectType.
        /// </summary>
        public const uint AssemblyStationType = 1003;

    }
    #endregion

    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class Methods
    {
    }
    #endregion

    #region ReferenceType Identifiers
    /// <summary>
    /// A class that declares constants for all ReferenceTyped in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class ReferenceTypes
    {
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the ALARM Variable.
        /// </summary>
        public const uint StationType_ALARM = 6005;

        /// <summary>
        /// The identifier for the BLOCKED Variable.
        /// </summary>
        public const uint StationType_BLOCKED = 6008;

        /// <summary>
        /// The identifier for the CYCLE_TIME Variable.
        /// </summary>
        public const uint StationType_CYCLE_TIME = 6003;

        /// <summary>
        /// The identifier for the EMPTY Variable.
        /// </summary>
        public const uint StationType_EMPTY = 6007;

        /// <summary>
        /// The identifier for the EXCLUDED Variable.
        /// </summary>
        public const uint StationType_EXCLUDED = 6009;

        /// <summary>
        /// The identifier for the INTERVENTION Variable.
        /// </summary>
        public const uint StationType_INTERVENTION = 6006;

        /// <summary>
        /// The identifier for the RUN Variable.
        /// </summary>
        public const uint StationType_RUN = 6004;

        /// <summary>
        /// The identifier for the ST_INPUT Variable.
        /// </summary>
        public const uint StationType_ST_INPUT = 6001;

        /// <summary>
        /// The identifier for the ST_OUTPUT Variable.
        /// </summary>
        public const uint StationType_ST_OUTPUT = 6002;

        /// <summary>
        /// The identifier for the TIMEOUT Variable.
        /// </summary>
        public const uint StationType_TIMEOUT = 6010;

    }
    #endregion

    #region VariableTypes Identifiers
    /// <summary>
    /// A class that declares constants for all VariableTypes in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class VariableTypes
    {
    }
    #endregion

    #region DataType Node Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class DataTypeIds
    {
    }
    #endregion

    #region Method Node Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class MethodIds
    {
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the Controllers Object.
        /// </summary>
        public static readonly ExpandedNodeId Controllers = new ExpandedNodeId(Objects.Controllers, Namespaces.DcsLab);

    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the StationType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId StationType = new ExpandedNodeId(ObjectTypes.StationType, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the AssemblyStationType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId AssemblyStationType = new ExpandedNodeId(ObjectTypes.AssemblyStationType, Namespaces.DcsLab);

    }
    #endregion

    #region ReferenceType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ReferenceTypes in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class ReferenceTypeIds
    {
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the StationType_ALARM Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_ALARM = new ExpandedNodeId(Variables.StationType_ALARM, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the StationType_BLOCKED Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_BLOCKED = new ExpandedNodeId(Variables.StationType_BLOCKED, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the StationType_CYCLE_TIME Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_CYCLE_TIME = new ExpandedNodeId(Variables.StationType_CYCLE_TIME, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the StationType_EMPTY Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_EMPTY = new ExpandedNodeId(Variables.StationType_EMPTY, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the StationType_EXCLUDED Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_EXCLUDED = new ExpandedNodeId(Variables.StationType_EXCLUDED, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the StationType_INTERVENTION Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_INTERVENTION = new ExpandedNodeId(Variables.StationType_INTERVENTION, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the StationType_RUN Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_RUN = new ExpandedNodeId(Variables.StationType_RUN, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the StationType_ST_INPUT Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_ST_INPUT = new ExpandedNodeId(Variables.StationType_ST_INPUT, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the StationType_ST_OUTPUT Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_ST_OUTPUT = new ExpandedNodeId(Variables.StationType_ST_OUTPUT, Namespaces.DcsLab);

        /// <summary>
        /// The identifier for the StationType_TIMEOUT Variable.
        /// </summary>
        public static readonly ExpandedNodeId StationType_TIMEOUT = new ExpandedNodeId(Variables.StationType_TIMEOUT, Namespaces.DcsLab);

    }
    #endregion

    #region VariableType Node Identifiers
    /// <summary>
    /// A class that declares constants for all VariableType in the Model.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("UaModeler", "1.5.2")]
    public static partial class VariableTypeIds
    {
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the ALARM component.
        /// </summary>
        public const string ALARM = "ALARM";
        /// <summary>
        /// The BrowseName for the AssemblyStationType component.
        /// </summary>
        public const string AssemblyStationType = "AssemblyStationType";
        /// <summary>
        /// The BrowseName for the BLOCKED component.
        /// </summary>
        public const string BLOCKED = "BLOCKED";
        /// <summary>
        /// The BrowseName for the CYCLE_TIME component.
        /// </summary>
        public const string CYCLE_TIME = "CYCLE_TIME";
        /// <summary>
        /// The BrowseName for the Controllers component.
        /// </summary>
        public const string Controllers = "Controllers";
        /// <summary>
        /// The BrowseName for the EMPTY component.
        /// </summary>
        public const string EMPTY = "EMPTY";
        /// <summary>
        /// The BrowseName for the EXCLUDED component.
        /// </summary>
        public const string EXCLUDED = "EXCLUDED";
        /// <summary>
        /// The BrowseName for the INTERVENTION component.
        /// </summary>
        public const string INTERVENTION = "INTERVENTION";
        /// <summary>
        /// The BrowseName for the RUN component.
        /// </summary>
        public const string RUN = "RUN";
        /// <summary>
        /// The BrowseName for the ST_INPUT component.
        /// </summary>
        public const string ST_INPUT = "ST_INPUT";
        /// <summary>
        /// The BrowseName for the ST_OUTPUT component.
        /// </summary>
        public const string ST_OUTPUT = "ST_OUTPUT";
        /// <summary>
        /// The BrowseName for the StationType component.
        /// </summary>
        public const string StationType = "StationType";
        /// <summary>
        /// The BrowseName for the TIMEOUT component.
        /// </summary>
        public const string TIMEOUT = "TIMEOUT";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the Model.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the DcsLab namespace.
        /// </summary>
        public const string DcsLab = "http://yourorganisation.org/DCS-lab/";

        /// <summary>
        /// The URI for the DcsLabXsd namespace.
        /// </summary>
        public const string DcsLabXsd = "http://yourorganisation.org/DCS-lab/Types.xsd";
    }
    #endregion
}

