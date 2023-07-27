using Buider;

OrgChartMember member = OrgChartMember.Create("122", "Eduardo")
    .AddSubordinate("124", "Lorran", b => b
        .AddSubordinate("235", "João Alencar")
    )
    .AddSubordinate("125", "JP");
