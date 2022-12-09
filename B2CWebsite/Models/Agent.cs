using System;
using System.Collections.Generic;

namespace B2CWebsite.Models;

public partial class Agent
{
    public int AgentId { get; set; }

    public string? AgentName { get; set; }

    public string? AgentAddress { get; set; }

    public string? AgentEmail { get; set; }

    public int? AgentPhone { get; set; }
}
