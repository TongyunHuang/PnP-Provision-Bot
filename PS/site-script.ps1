$site_script = @'
{
    "$schema": "schema.json", 
    "actions": [
		{
				"verb": "triggerFlow",
				"url": "https://prod-143.westus.logic.azure.com:443/workflows/6064ffa49ed84ba7853bd78672acac1f/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=ynuba3V0-kjYuaoA3Bt2B-GLju8TJQgS-ZAddRYcqYM",
				"name": "Apply PnP Template",
				"parameters": {
					"event":"",
					"product":""
				}
		}
    ],
    "bindata": {},
    "version": 1
}
'@

Add-PnPSiteScript -Title "Trigger Contoso landing provisioning" -Content $site_script -Description "Applies Contoso landing site template via azure web job"