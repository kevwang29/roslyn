﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.VisualStudio.LanguageServices.Implementation.ProjectSystem;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.VisualStudio.LanguageServices.Telemetry
{
    [ExportWorkspaceService(typeof(IHostContextService), ServiceLayer.Host), Shared]
    internal class HostContextService : IHostContextService
    {
        public string GetProjectType(Workspace workspace, ProjectId projectId)
        {
            if (workspace == null || projectId == null)
            {
                return string.Empty;
            }

            var vsWorkspace = workspace as VisualStudioWorkspaceImpl;
            return vsWorkspace?.GetHostProject(projectId)?.ProjectType ?? string.Empty;
        }
    }
}
