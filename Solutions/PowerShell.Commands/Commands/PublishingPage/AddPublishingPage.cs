﻿using OfficeDevPnP.PowerShell.Commands.Base;
using Microsoft.SharePoint.Client;
using System.Management.Automation;
using Microsoft.SharePoint.Client.WebParts;
using OfficeDevPnP.Core;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "SPOPublishingPage")]
    public class AddPublishingPage : SPOWebCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("Name")]
        public string PageName = string.Empty;

        [Parameter(Mandatory = true)]
        public string PageTemplateName = null;

        [Parameter(Mandatory = false, ParameterSetName = "WithTitle")]
        public string Title;

        [Parameter(Mandatory = false, HelpMessage = "Publishes the page. Also Approves it if moderation is enabled on the Pages library.")]
        public SwitchParameter Publish;

        protected override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case "WithTitle":
                    {
                        this.SelectedWeb.AddPublishingPage(PageName, PageTemplateName, Title, publish: Publish);
                        break;
                    }
                default:
                    {
                        this.SelectedWeb.AddPublishingPage(PageName, PageTemplateName, publish: Publish);
                        break;
                    }
            }
        }
    }
}
