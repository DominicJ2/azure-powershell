﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.DeploymentManager.Commands
{
    using System.Management.Automation;

    using Microsoft.Azure.Commands.DeploymentManager.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    [CmdletDeprecationWithVersion("12.0.0", "2.0.0")]
    [Cmdlet(
        VerbsCommon.Set, 
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerServiceTopology",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DeploymentManagerBaseCmdlet.InputObjectParamSetName),
     OutputType(typeof(PSServiceTopologyResource))]
    public class SetServiceTopology : DeploymentManagerBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true, 
            ValueFromPipeline = true, 
            HelpMessage = "The service topology object.")]
        [ValidateNotNullOrEmpty]
        public PSServiceTopologyResource InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.InputObject.Name, Messages.UpdateServiceTopology))
            {
                var topologyResource = this.DeploymentManagerClient.PutServiceTopology(this.InputObject);
                this.WriteObject(topologyResource);
            }
        }
    }
}
