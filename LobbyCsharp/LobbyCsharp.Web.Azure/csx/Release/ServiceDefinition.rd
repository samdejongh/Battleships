<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="LobbyCsharp.Web.Azure" generation="1" functional="0" release="0" Id="5a5d607a-912d-44fe-abc4-20cfaca6dad6" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="LobbyCsharp.Web.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="LobbyCsharp.Web:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/LB:LobbyCsharp.Web:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="LobbyCsharp.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/MapLobbyCsharp.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="LobbyCsharp.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/MapLobbyCsharp.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:LobbyCsharp.Web:Endpoint1">
          <toPorts>
            <inPortMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/LobbyCsharp.Web/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapLobbyCsharp.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/LobbyCsharp.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapLobbyCsharp.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/LobbyCsharp.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="LobbyCsharp.Web" generation="1" functional="0" release="0" software="C:\Users\Martyna\Documents\Battleships\LobbyCsharp\LobbyCsharp.Web.Azure\csx\Release\roles\LobbyCsharp.Web" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;LobbyCsharp.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;LobbyCsharp.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/LobbyCsharp.WebInstances" />
            <sCSPolicyUpdateDomainMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/LobbyCsharp.WebUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/LobbyCsharp.WebFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="LobbyCsharp.WebUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="LobbyCsharp.WebFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="LobbyCsharp.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="3265cb0b-ff71-4495-b742-b95dec33beff" ref="Microsoft.RedDog.Contract\ServiceContract\LobbyCsharp.Web.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="12be3a1b-fe1f-4bcb-ba3d-987e93169771" ref="Microsoft.RedDog.Contract\Interface\LobbyCsharp.Web:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/LobbyCsharp.Web.Azure/LobbyCsharp.Web.AzureGroup/LobbyCsharp.Web:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>