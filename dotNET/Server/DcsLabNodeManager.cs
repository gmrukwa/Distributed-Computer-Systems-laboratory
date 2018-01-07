/******************************************************************************
**
** <auto-generated>
**     This code was generated by a tool: UaModeler
**     Runtime Version: 1.5.2, using .NET Server 2.5.0 template (version 3)
**
**     This is a template file that was generated for your convenience.
**     This file will not be overwritten when generating code again.
**     ADD YOUR IMPLEMTATION HERE!
**
**     Generated by Grzegorz Mrukwa <Grzegorz.Mrukwa@polsl.pl>
** </auto-generated>
**
** Copyright (c) 2006-2017 Unified Automation GmbH All rights reserved.
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
** Created: 12.12.2017
**
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;
using PolslMacrocourse.DcsLab.Abstraction;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;
namespace PolslMacrocourse.DcsLab
{
    internal partial class DcsLabNodeManager : BaseNodeManager
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the index of the instance namespace.
        /// </summary>
        /// <value>
        /// The index of the instance namespace.
        /// </value>
        public ushort InstanceNamespaceIndex { get; set; }
        /// <summary>
        /// Gets or sets the index of the type namespace.
        /// </summary>
        /// <value>
        /// The index of the type namespace.
        /// </value>
        public ushort TypeNamespaceIndex { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DcsLabNodeManager(ServerManager server) : base(server)
        {
            _directory = new DirectoryManager(this);
            _factory = new AssemblyStationFactory(this);
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TBD
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Called when the node manager is started.
        /// </summary>
        public override void Startup()
        {
            try
            {
                Console.WriteLine("Starting DcsLabNodeManager.");

                base.Startup();
                DefaultNamespaceIndex = AddNamespaceUri(PolslMacrocourse.DcsLab.Namespaces.DcsLab);

                Console.WriteLine("Loading the DcsLab Model.");
                ImportUaNodeset(Assembly.GetEntryAssembly(), "dcs-lab.xml");

                Console.WriteLine("Loading the DcsLab hardcoded instances.");
                InstanceNamespaceIndex = DefaultNamespaceIndex;
                TypeNamespaceIndex = DefaultNamespaceIndex;

                var controllers = _directory.Get(ObjectIds.Controllers);
                var station1 = _factory.Create("AS1_1_1", controllers);
                var station2 = _factory.Create("AS21_1_1", controllers);
                var station3 = _factory.Create("AS2_1_1", controllers);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to start DcsLabNodeManager " + e.Message);
            }
        }

        /// <summary>
        /// Called when the node manager is stopped.
        /// </summary>
        public override void Shutdown()
        {
            try
            {
                Console.WriteLine("Stopping DcsLabNodeManager.");

                // TBD
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to stop DcsLabNodeManager " + e.Message);
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Fields

        private readonly DirectoryManager _directory;
        private readonly AssemblyStationFactory _factory;

        #endregion
    }
}

