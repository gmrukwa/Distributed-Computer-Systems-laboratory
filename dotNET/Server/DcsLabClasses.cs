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
using System.Linq;
using System.Text;
using System.Xml;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace PolslMacrocourse.DcsLab
{
    #region StationModel
    /// <summary>
    /// </summary>
    [UaTypeDefinition(NodeId=ObjectTypes.StationType, NamespaceUri=PolslMacrocourse.DcsLab.Namespaces.DcsLab)]
    public partial class StationModel : BaseObjectModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="StationModel" /> class.
        /// </summary>
        public StationModel() : this((StationModel)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationModel" /> class.
        /// </summary>
        /// <param name="template">The template.</param>
        public StationModel(StationModel template) : base(template)
        {
            if (template == null)
            {
            }
            else
            {
                ALARM = template.ALARM;
                BLOCKED = template.BLOCKED;
                CYCLE_TIME = template.CYCLE_TIME;
                EMPTY = template.EMPTY;
                EXCLUDED = template.EXCLUDED;
                INTERVENTION = template.INTERVENTION;
                RUN = template.RUN;
                ST_INPUT = template.ST_INPUT;
                ST_OUTPUT = template.ST_OUTPUT;
                TIMEOUT = template.TIMEOUT;
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ALARM
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public bool ALARM { get; set; }

        /// <summary>
        /// Gets or sets the BLOCKED
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public bool BLOCKED { get; set; }

        /// <summary>
        /// Gets or sets the CYCLE_TIME
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public byte CYCLE_TIME { get; set; }

        /// <summary>
        /// Gets or sets the EMPTY
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public bool EMPTY { get; set; }

        /// <summary>
        /// Gets or sets the EXCLUDED
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public bool EXCLUDED { get; set; }

        /// <summary>
        /// Gets or sets the INTERVENTION
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public bool INTERVENTION { get; set; }

        /// <summary>
        /// Gets or sets the RUN
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public bool RUN { get; set; }

        /// <summary>
        /// Gets or sets the ST_INPUT
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public bool ST_INPUT { get; set; }

        /// <summary>
        /// Gets or sets the ST_OUTPUT
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public bool ST_OUTPUT { get; set; }

        /// <summary>
        /// Gets or sets the TIMEOUT
        /// </summary>
        [UaInstanceDeclaration(NamespaceUri = Namespaces.DcsLab)]
        public bool TIMEOUT { get; set; }


        #endregion
    }
    #endregion


    #region AssemblyStationModel
    /// <summary>
    /// </summary>
    [UaTypeDefinition(NodeId=ObjectTypes.AssemblyStationType, NamespaceUri=PolslMacrocourse.DcsLab.Namespaces.DcsLab)]
    public partial class AssemblyStationModel : StationModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyStationModel" /> class.
        /// </summary>
        public AssemblyStationModel() : this((AssemblyStationModel)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyStationModel" /> class.
        /// </summary>
        /// <param name="template">The template.</param>
        public AssemblyStationModel(AssemblyStationModel template) : base(template)
        {
        }
        #endregion

        #region Public Properties

        #endregion
    }
    #endregion



}
